using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float range;

    Vector2 wayPoint;
    public float forceMagnitude;
    private Rigidbody2D rigidbody;
    int shapeType;

    public GameObject myLine;

    //Vector3 shapePosition = GameObject.FindGameObjectsWithTag("Shape").transform.position;

    void Start()
    {
        InitialDestination();
        BallsControl.Instance.BallPosition1();
        BallsControl.Instance.BallPosition2();

        //animator = this.GetComponent<Animator>();
        //spriterender = GetComponent<SpriteRenderer>();
        //spriterender.color = new Color(1f, 1f, 1f, 0f);

        //Attempt to randomize the position of the circles
        /*float xVal = Random.Range(Random.Range(59.1f, 705.9f), Random.Range(822.9f, 1474.4f));
        float yVal = Random.Range(62.7f, 800.0f);

        wayPoint = new Vector2(xVal, yVal);
        this.transform.position = wayPoint;*/

        //Works when I manually place the circles
        if (this.transform.position.x >= 59.1f && transform.position.x <= 705.9f)
        {
            MostBallsManager.Instance.AddScore(1, 1); //initial
        }
        else if (this.transform.position.x >= 822.9f && transform.position.x <= 1474.4f)
        {
            MostBallsManager.Instance.AddScore(0, 1); //initial
        }

        //Worry aobut this later, I have no idea if this improves the frequent stickings like a glue
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(5f, 5f);

        Vector2 force = wayPoint * forceMagnitude;
        GetComponent<Rigidbody2D>().AddForce(force);
    }

    void SetNewDestination()
    {
        //if (this.transform.position.x >= 59.1f && transform.position.x <= 705.9f)
        //Actual left side, when the right ball crosses to the left side
        //if (transform.position.x >= 719.0f && transform.position.x <= 728.0f) //One that worked better previously

        //crossing the left line
        if (transform.position.x >= 717.0f && transform.position.x <= 725.0f) //initial upper bound = 725.0f
        {
            wayPoint = new Vector2(Random.Range(822.9f, 1474.4f), Random.Range(62.7f, 800.0f));
            //spriterender.color = new Color(1f, 1f, 1f, 0.3f);

            MostBallsManager.Instance.AddScore(1, 1);
            MostBallsManager.Instance.AddScore(0, -1);
            MostBallsAudio.Instance.PlayBoundaryAudio(GameObject.Find("field").transform.position);
            Instantiate(myLine);
            StartCoroutine(EnableBox(1.0F));
        }

        //else if (this.transform.position.x >= 822.9f && transform.position.x <= 1474.4f)
        //Actual right side, when the left ball crosses to the right side
        //else if (transform.position.x >= 804.0f && transform.position.x <= 825.0f) //One that worked better previously

        //crossing the right line
        else if (transform.position.x >= 810.0f && transform.position.x <= 818.0f) //initial lower bound = 810.0f
        {
            wayPoint = new Vector2(Random.Range(59.1f, 705.9f), Random.Range(62.7f, 800.0f));
            //spriterender.color = new Color(255f, 255f, 255f, 0.3f);

            MostBallsManager.Instance.AddScore(0, 1);
            MostBallsManager.Instance.AddScore(1, -1);
            MostBallsAudio.Instance.PlayBoundaryAudio(transform.position);
            Instantiate(myLine);
            StartCoroutine(EnableBox(1.0F));

        }
    }

    void InitialDestination()
    {
        //Randomize the ball positions
        //Do not need to limit oneself to 11 balls 

        /*float xVal = Random.Range(Random.Range(59.1f, 705.9f), Random.Range(822.9f, 1474.4f));
        float yVal = Random.Range(62.7f, 800.0f);

        wayPoint = new Vector2(xVal, yVal);

        this.transform.position = wayPoint;*/

        //The code that works when I manually place the balls in random positions
        if (this.transform.position.x >= 59.1f && transform.position.x <= 705.9f)
        {
            wayPoint = new Vector2(Random.Range(59.1f, 705.9f), Random.Range(62.7f, 800.0f));
        }
        else if (this.transform.position.x >= 822.9f && transform.position.x <= 1474.4f)
        {
            wayPoint = new Vector2(Random.Range(822.9f, 1474.4f), Random.Range(62.7f, 800.0f));
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Line")
        {
            //Debug.Log("Collision with Player and Circle detected");
            SetNewDestination();
            //animator.SetBool(BLINKING_LINE, true);

            //anim.clip = clip;
            //anim.AddClip(clip, BLINKING_LINE);
            //anim.Play();

            //GameObject shape = shapesArray[shapeType];
            /*foreach (GameObject shape in shapesArray)
            {
                if(shape == GameObject.Find("Circle"))
                {
                    GetComponent<CircleCollider2D>().enabled = false;
                }
                if (shape == GameObject.Find("Square"))
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                }
            }*/

            GetComponent<CircleCollider2D>().enabled = false;
            //GetComponent<PolygonCollider2D>().enabled = false;
            StartCoroutine(EnableBox(1.0F));
        }
    }

    IEnumerator Scoring(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<CircleCollider2D>().enabled = true;

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
        //GetComponent<PolygonCollider2D>().enabled = true;
        //GetComponent<CircleCollider2D>().enabled = true;
    }

    IEnumerator EnableBox(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<CircleCollider2D>().enabled = true;

        /*foreach (GameObject shape in shapesArray)
        {
            if (shape == GameObject.Find("Circle"))
            {
                GetComponent<CircleCollider2D>().enabled = true;
            }
            if (shape == GameObject.Find("Square"))
            {
                GetComponent<BoxCollider2D>().enabled = true;
            }
        }*/


        //GetComponent<PolygonCollider2D>().enabled = true;
        //GetComponent<CircleCollider2D>().enabled = true;
    }

    void Update()
    {
        //This code doesn't update the position very well
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);

        //I only want the individual ball to just change movement direction
        //The code that works when I place the balls manually
        if (Vector2.Distance(this.transform.position, wayPoint) < range)
        {
            //Debug.Log("Vector2.Distance: " + Vector2.Distance(transform.position, wayPoint));
            InitialDestination();
        }
    }
}
