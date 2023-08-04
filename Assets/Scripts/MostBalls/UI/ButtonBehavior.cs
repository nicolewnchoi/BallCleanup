using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    /*public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }*/

    //Need to Use This Code Sometime:
    //int boundaryShapeType = (int)collision.gameObject.GetComponent<ShapeClass>().shape;
    //int shapeType = (int)GetComponent<ShapeClass>().shape;

    [SerializeField] Button shapeSelection;
    string scoreKey1 = "Score1";
    public int CurrentScore1 = 0;
    //public int CurrentScore1 { get; set; }
    string scoreKey2 = "Score2";
    public int CurrentScore2 = 0;
    //public int CurrentScore2 { get; set; }

    void Start()
    {
        shapeSelection.onClick.AddListener(Settings);
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "NumberOfBalls")
        {
            shapeSelection.onClick.AddListener(playGame);
        }
    }

    //Update to store the current number: 06/20
    /*private void Awake()
    {
        CurrentScore1 = PlayerPrefs.GetInt(scoreKey1);
        CurrentScore2 = PlayerPrefs.GetInt(scoreKey2);
    }*/

    //Update to store the current number: 06/20
    /*public void SaveNumber(int index)
    {
        if (index == 0)
        {
            PlayerPrefs.SetInt(scoreKey1, MostBallsManager.Instance.players[0].score);
        }
        else if (index == 1)
        {
            PlayerPrefs.SetInt(scoreKey2, MostBallsManager.Instance.players[1].score);
        }
    }*/

    //Optional function
    /*public int GetNumber(int index)
    {
        if (index == 0)
        {
            CurrentScore1 = PlayerPrefs.GetInt(scoreKey1);
            return CurrentScore1;
        }
        else
        {
            CurrentScore2 = PlayerPrefs.GetInt(scoreKey2);
            return CurrentScore2;
        }
    }*/

    private void Settings()
    {
        ScenesManager.Instance.NextScene(ScenesManager.SceneName.NumberOfBalls);
        Debug.Log("Button Clicked");
    }

    public void playGame()
    {
        if (BallsControl.shapeObject == GameObject.Find("Circle"))
        {
            ScenesManager.Instance.NextScene(ScenesManager.SceneName.CircleStage);
        }
        else if (BallsControl.shapeObject == GameObject.Find("Square"))
        {
            ScenesManager.Instance.NextScene(ScenesManager.SceneName.SquareStage);
        }
        else if (BallsControl.shapeObject == GameObject.Find("Star"))
        {
            ScenesManager.Instance.NextScene(ScenesManager.SceneName.SquareStage);
        }
        Debug.Log("ShapeObject" + BallsControl.shapeObject.name);
    }

    /*public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }*/
}