using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BallsPlayer
{
    public int score = 0;
    public GameObject crown;
    public Text scoreDisplay;

    //Need for the SaveSystem class
    /*public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        BallsPlayer data = SaveSystem.LoadPlayer();

        score = data.score;
        scoreDisplay = data.scoreDisplay;
    }*/
}

public class MostBallsManager : MonoBehaviour
{
    public static MostBallsManager Instance;
    [SerializeField] public BallsPlayer[] players; //left: 0, right: 1
    //ButtonBehavior scoreSystem;
    //public MostBallsManager LoadedData { get; private set; }

    //public string scoreKey1 = "Score1";
    //public string scoreKey2 = "Score2";
    //public string savePresentKey = "SavePresent";
    //public int CurrentScore1 { get; set; }
    //public int CurrentScore2 { get; set; }

    /*void Start()
    {
        scoreSystem = FindObjectOfType<ButtonBehavior>();
        MostBallsManager.Instance.players[0].score = scoreSystem.CurrentScore1;
        MostBallsManager.Instance.players[1].score = scoreSystem.CurrentScore2;
    }*/

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); //important, do not delete!!!

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
        players[0].scoreDisplay.text = players[0].score.ToString();
        players[1].scoreDisplay.text = players[1].score.ToString();
    }

    public void AddScore(int side, int score)
    {
        players[side].score += score;
    }

    IEnumerator Scoring(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<CircleCollider2D>().enabled = true;
    }

    public IEnumerator WinGame()
    {
        if (players[0].score < players[1].score)
        {
            players[0].crown.SetActive(true);
        }
        else if (players[0].score > players[1].score)
        {
            players[1].crown.SetActive(true);
        }
        else
        {
            players[0].crown.SetActive(true);
            players[1].crown.SetActive(true);
        }
        
        //MostBallsAudio.Instance.PlayShapeWinAudio(GameObject.Find("field").transform.position);
        yield return new WaitForSeconds(5.0f);
        players[0].crown.SetActive(false);
        players[0].score = 0;
        players[1].crown.SetActive(false);
        players[1].score = 0;

        GameObject[] shapes = GameObject.FindGameObjectsWithTag("Shape");
        foreach (GameObject shape in shapes)
            Destroy(shape);

        //TimerMostBalls.Instance.timeRemaining = GetComponent<TimerMostBalls>().totalTime;
        //TimerMostBalls.Instance.timerIsRunning = true;
    }
}

