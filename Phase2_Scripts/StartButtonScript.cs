//code for Start button

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    public static int citizenInfected;
    public static float startTime;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;        //time of the game is stopped when application starts and is set to normal when user decides to start
    }

    public void OnStartButton()
    {
        Time.timeScale = 1f;        //when start button is clicked time runs
        citizenInfected = Random.Range(0, 30);      // a random citizen is chosen to be infected
        startTime = Time.time;
    }

    public void OnPreQuitButton()
    {
        Phase1Data.PreSaveData();
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            SceneManager.LoadScene("Phase1");
        }
        else
        {
            Application.Quit();
        }
    }
}
