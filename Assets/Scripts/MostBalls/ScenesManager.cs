using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public GameObject player;
    //public NewSaveSystem saveSystem;

    public enum SceneName
    {
        CircleDemo,
        SquareDemo,
        StarDemo,
        CircleStage,
        SquareStage,
        StarStage,
        NumberOfBalls
    }

    public static ScenesManager Instance;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "CircleDemo")
        {
            BallsControl.shapeObject = GameObject.Find("Circle");
        }
        else if (sceneName == "SquareDemo")
        {
            BallsControl.shapeObject = GameObject.Find("Square");
        }
        else if (sceneName == "StarDemo")
        {
            BallsControl.shapeObject = GameObject.Find("Star");
        }
        //Debug.Log("ShapeObject" + BallsControl.shapeObject.name);

    }

    private void Awake()
    {
        Instance = this;
        //included these two below as of 06/21
        //SceneManager.sceneLoaded += Initialize;

        //DontDestroyOnLoad(gameObject);
    }

    /*public void LoadLevel()
    {
        if (saveSystem.LoadedData != null)
        {
            SceneManager.LoadScene(saveSystem.LoadedData.sceneIndex);
            return;
        }
        LoadNextLevel();
    }*/

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*public void SaveData()
    {
        saveSystem.SaveData(SceneManager.GetActiveScene().buildIndex + 1, MostBallsManager.Instance.players[0].score);
        saveSystem.SaveData(SceneManager.GetActiveScene().buildIndex + 1, MostBallsManager.Instance.players[1].score);

        /*if (player != null)
        {
            //The numbers won't show up at all. 
            //saveSystem.SaveData(MostBallsManager.Instance.players[0].score, MostBallsManager.Instance.players[1].score);

            saveSystem.SaveData(SceneManager.GetActiveScene().buildIndex + 1, MostBallsManager.Instance.players[0].score);
            saveSystem.SaveData(SceneManager.GetActiveScene().buildIndex + 1, MostBallsManager.Instance.players[1].score);
        }
    }*/

    public void NextScene(SceneName scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    /*public void LoadNewGame()
    {
        SceneManager.LoadScene(SceneName.NumberOfBalls.ToString());
    }

    public void LoadNextScene()
    {

    }*/
}
