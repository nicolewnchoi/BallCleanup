using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehavior : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float range;

    Vector2 wayPoint;
    public float forceMagnitude;
    private Rigidbody2D rigidbody;
    int shapeType;
    //Vector3 shapePosition = GameObject.FindGameObjectsWithTag("Shape").transform.position;

    public GameObject myLine;

    void Start()
    {
        InitialDestination();
        BallsControl.Instance.BallPosition1();
        BallsControl.Instance.BallPosition2();

        if (this.transform.position.x >= 59.1f && transform.position.x <= 705.9f)
        {
            MostBallsManager.Instance.AddScore(1, 1);
        }
        else if (this.transform.position.x >= 822.9f && transform.position.x <= 1474.4f)
        {
            MostBallsManager.Instance.AddScore(0, 1);
        }

        //Worry aobut this later, I have no idea if this improves the frequent stickings like a glue
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(5f, 5f); //initially 5f 

        Vector2 force = wayPoint * forceMagnitude;
        GetComponent<Rigidbody2D>().AddForce(force);
    }

    void SetNewDestination() //When the objects cross the line (avoid the possibility of the objects "attempting" to go back, which happens sometimes)
        //Should there be some difficulty in having the objects across the line?
    {
        //Actual left side, when the right ball crosses to the left side
        if (transform.position.x >= 695.0f && transform.position.x <= 712.0f) //initial lower bound = 695.0f, initial upper bound = 702.0f
        {
            wayPoint = new Vector2(Random.Range(822.9f, 1474.4f), Random.Range(62.7f, 800.0f));

            MostBallsManager.Instance.AddScore(0, 1);
            MostBallsManager.Instance.AddScore(1, -1);
            MostBallsAudio.Instance.PlayBoundaryAudio(GameObject.Find("field").transform.position);
            Instantiate(myLine);
            StartCoroutine(EnableBox(1.0F));
        }

        //Actual right side, when the left ball crosses to the right side
        else if (transform.position.x >= 820.0f && transform.position.x <= 840.0f) //initial lower bound = 832.0f, initial upper bound = 840.0f
        {
            wayPoint = new Vector2(Random.Range(59.1f, 705.9f), Random.Range(62.7f, 800.0f));

            MostBallsManager.Instance.AddScore(1, 1);
            MostBallsManager.Instance.AddScore(0, -1);
            MostBallsAudio.Instance.PlayBoundaryAudio(transform.position);
            Instantiate(myLine);
            StartCoroutine(EnableBox(1.0F));
        }
        //StartCoroutine(EnableBox(1.0F));
    }

    void InitialDestination()
    {
        if (this.transform.position.x >= 59.1f && transform.position.x <= 705.9f) //initial upper bound = 705.9f
        {
            wayPoint = new Vector2(Random.Range(59.1f, 705.9f), Random.Range(62.7f, 800.0f)); //initial upper bound = 705.9f
            //MostBallsManager.Instance.AddScore(0, 1);
        }
        else if (this.transform.position.x >= 822.9f && transform.position.x <= 1474.4f)
        {
            wayPoint = new Vector2(Random.Range(822.9f, 1474.4f), Random.Range(62.7f, 800.0f));
            //MostBallsManager.Instance.AddScore(1, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Line")
        {
            Debug.Log("Collision with Player and Circle detected");
            SetNewDestination();

            GetComponent<PolygonCollider2D>().enabled = false;
            StartCoroutine(EnableBox(1.0F));
        }
    }

    IEnumerator Scoring(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //GetComponent<CircleCollider2D>().enabled = true;

        /*foreach (GameObject shape in shapesArray)
        {
            if (shape == GameObject.Find("Circle"))
            {
                GetComponent<CircleCollider2D>().enabled = true;
            }
            else if (shape == GameObject.Find("Square"))
            {
                GetComponent<BoxCollider2D>().enabled = true;
            }
        }*/

        GetComponent<PolygonCollider2D>().enabled = true;
    }

    IEnumerator EnableBox(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<PolygonCollider2D>().enabled = true;
    }

    void Update()
    {
        //This code doesn't update the position very well
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);

        //I only want the individual ball to just change movement direction
        if (Vector2.Distance(this.transform.position, wayPoint) < range)
        {
            //Debug.Log("Vector2.Distance: " + Vector2.Distance(transform.position, wayPoint));
            InitialDestination();
        }
    }
}
