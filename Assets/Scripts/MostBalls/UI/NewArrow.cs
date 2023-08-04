using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewArrow : MonoBehaviour
{
    //[SerializeField] Text number; 
    //so I have no idea why SerializeField won't work even though it says it will update on screen during runtime

    [SerializeField] Text numObjects1, numObjects2;
    public static int numbers1, numbers2; //makes the scores consistent 
    //public static NewArrow Instance;

    public GameObject upArrow;
    public GameObject downArrow;

    public void Update()
    {
        MostBallsManager.Instance.players[0].scoreDisplay.text = MostBallsManager.Instance.players[0].score.ToString();
        MostBallsManager.Instance.players[1].scoreDisplay.text = MostBallsManager.Instance.players[1].score.ToString();
        //numObjects1.text = numbers1.ToString();
        //numObjects2.text = numbers2.ToString();
    }

    public void AddScore()
    {
        if (upArrow.transform.position.x <= 500)
        //if (upArrow.transform.position.x <= 0)
        //if (GameObject.Find("RightUpArrow") == upArrow)
        {
            MostBallsManager.Instance.players[0].score++;
            //numbers1++;
            StartCoroutine(Scoring(1.0F));
            Debug.Log("Up Click for left: " + numbers1);
        }

        else
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MostBallsManager.Instance.players[1].score++;
            //numbers2++;
            StartCoroutine(Scoring(1.0F));
            Debug.Log("Up Click for right: " + numbers2);
        }

    }

    public void SubtractScore()
    {
        if (downArrow.transform.position.x <= 500)
        //if (downArrow.transform.position.x <= 0)
        {
            if (MostBallsManager.Instance.players[0].score <= 1)
            {
                MostBallsManager.Instance.players[0].score = 0;
            }
            else
            {
                MostBallsManager.Instance.players[0].score--;
            }
            //numbers1--;
            StartCoroutine(Scoring(1.0F));
            Debug.Log("Down Click left: " + numbers1);
        }

        else
        {
            if (MostBallsManager.Instance.players[1].score <= 1)
            {
                MostBallsManager.Instance.players[1].score = 0;
            }
            else
            {
                MostBallsManager.Instance.players[1].score--;
            }
            //numbers2--;
            StartCoroutine(Scoring(1.0F));
            Debug.Log("Down Click right: " + numbers2);
        }
    }

    IEnumerator Scoring(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
