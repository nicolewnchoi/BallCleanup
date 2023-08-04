using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowBehavior : MonoBehaviour
{
    public static ArrowBehavior Instance;
    //public GameObject arrow;
    public GameObject upArrow;
    public GameObject downArrow;

    public Text numObjects;
    public int numbers;

    void Start()
    {
        numbers = 0;
        //numObjects = GetComponent<Text>();
    }

    private void Update()
    {
        numObjects.text = numbers.ToString();

        /*if (GameObject.Find("UpArrow") == upArrow)
        {
            AddScore();
            //numObjects.text = numbers.ToString();
        }

        if (Input.GetButtonDown("Fire1") && GameObject.Find("UpArrow") == upArrow)
        {
            AddScore(1);
            numObjects.text = numbers.ToString();
        }*/

        /*if (Input.GetButtonDown("Fire1") && GameObject.Find("DownArrow") == downArrow)
        {
            numbers--;
            numObjects.text = numbers.ToString();
        }*/
    }

    /*public void AddScore()
    {
        numbers++;
    }*/

    /*void OnMouseDown()
    {
        //Only works for up arrows, but not down arrows
        /*if (GameObject.Find("UpArrow") == upArrow)
        {
            numbers += 1;
            //AddScore();
            numObjects.text = numbers.ToString();
            Debug.Log("Up Click");
        }

        if (GameObject.Find("DownArrow") == downArrow)
        {
            numbers -= 1;
            numObjects.text = numbers.ToString();
            Debug.Log("Down Click");
        }
    }*/
}
