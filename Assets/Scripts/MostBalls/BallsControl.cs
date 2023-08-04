using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BallsControl : MonoBehaviour
{
    public static BallsControl Instance;
    //public string scoreKey1 = "Score1";
    //public string scoreKey2 = "Score2";

    //Data transferred from the number of shapes selection screen with static keyword
    //ButtonBehavior scoreSystem;

    //(07/07): FINALLY, correct numbers showed up with the public integers
    public int numBalls1; //<-- (07/04) Got the correct number once transferred, but the circles won't show up... (public or private)
    public int numBalls2;

    public static GameObject shapeObject; //Data transferred from the type of shape selection screen
    public Rigidbody2D shapeObjectRB;
    public Transform shape;

    Vector2 newPos1;
    Vector2 newPos2;
    float xVal1;
    float xVal2;
    float yVal;

    void Start()
    {
        xVal1 = Random.Range(59.1f, 705.9f);
        xVal2 = Random.Range(822.9f, 1474.4f);
        yVal = Random.Range(62.7f, 800.0f);

        //For transferring variables from the selection screen
        //scoreSystem = FindObjectOfType<ButtonBehavior>(); //<-- Initially commented out, but it worked
        //numBalls1 = scoreSystem.CurrentScore1;
        //numBalls2 = scoreSystem.CurrentScore2;

        BallPosition1();
        BallPosition2();
    }

    public void BallPosition1()
    {
        //numBalls1 = scoreSystem.CurrentScore1;
        //for (int i = 0; i < MostBallsManager.Instance.players[0].score; i++) //please don't change!!! (it will CRASH)
        //PlayerPrefs.GetInt(scoreKey1)
        for (int i = 0; i < numBalls1; i++)
        {
            //Debug.Log("Ball1 " + i);
            newPos1 = new Vector2(xVal1, yVal);
            shape.position = newPos1;

            Rigidbody2D shapeInstance1;
            shapeInstance1 = Instantiate(shapeObjectRB, shape.position, Quaternion.identity) as Rigidbody2D;
            shapeInstance1.AddForce(shape.right * 40f);

            MostBallsManager.Instance.AddScore(1, 1);
            //MostBallsManager.Instance.AddScore(0, 1); //Do NOT, this will CRASH
        }
    }

    public void BallPosition2()
    {
        //numBalls2 = scoreSystem.CurrentScore2;
        //for (int i = 0; i < MostBallsManager.Instance.players[1].score; i++) //please don't change this!!! (it will CRASH)
        //PlayerPrefs.GetInt(scoreKey2)
        for (int i = 0; i < numBalls2; i++) 
        {
            //Debug.Log("Ball2 " + i);
            newPos2 = new Vector2(xVal2, yVal);
            //Instantiate(shapeObject, newPos2, Quaternion.identity);

            shape.position = newPos2;

            Rigidbody2D shapeInstance2;
            shapeInstance2 = Instantiate(shapeObjectRB, shape.position, Quaternion.identity) as Rigidbody2D;
            shapeInstance2.AddForce(shape.right * -40f);

            MostBallsManager.Instance.AddScore(0, 1);
            //MostBallsManager.Instance.AddScore(1, 1);  //Do NOT, this will CRASH
        }
    }

    //IEnumerator doesn't change anything, only delays the instantiation by a second
    /*IEnumerator randomShapeSpawn()
    {
        newPos1 = new Vector2(xVal1, yVal);
        yield return new WaitForSeconds(1f);
        Instantiate(shapeObject, newPos1, Quaternion.identity);
    }*/

    /*public GameObject balls;
    private int ball_count = 11;
    public float speed = 100.0f;

    void Move()
    {
        //Random movement of the circles
        for (int i = 0; i < ball_count; i++)
        {
            Vector3 pos = GetRandomPosition();
            transform.position += pos * Time.deltaTime * speed;
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(64.7f, 702.6f), Random.Range(66.2f, 958.6f), 0);
        Vector3 direction = (randomPosition - transform.position).normalized;
        //Vector3 direction = Vector3.Distance(randomPosition, transform.position);
        return randomPosition;
    }*/
}
