using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TeamScore
{
    public int numbers;
    public Text numObjects;
    public GameObject upArrow;
    public GameObject downArrow;
}

public class NumberofObjects : MonoBehaviour
{
    public bool isSelected;
    public static NumberofObjects Instance;
    [SerializeField] public TeamScore[] players;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        players[0].numObjects.text = players[0].numbers.ToString();
        players[1].numObjects.text = players[1].numbers.ToString();
    }

    private void changeNumbers(int side, int numbers)
    {
        players[side].numbers += numbers;
    }

    private void OnMouseDown()
    {
        //Up Arrow Activation
        if (players[0].upArrow == null)
        {
            players[0].upArrow.SetActive(false);
        }
        else
        {
            players[0].upArrow.SetActive(true);
            Debug.Log("upArrow clicked");
            changeNumbers(0, 1);
        }

        if (players[1].upArrow == null)
        {
            players[1].upArrow.SetActive(false);
        }
        else
        {
            players[1].upArrow.SetActive(true);
            changeNumbers(1, 1);
        }

        //Down Arrow Activation
        if (players[0].downArrow == null)
        {
            players[0].downArrow.SetActive(false);
        }
        else
        {
            players[0].downArrow.SetActive(true);
            changeNumbers(0, -1);
        }

        if (players[1].downArrow == null)
        {
            players[1].downArrow.SetActive(false);
        }
        else
        {
            players[1].downArrow.SetActive(true);
            changeNumbers(1, -1);
        }
    }
}
