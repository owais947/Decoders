//code for resume button

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeButtonScript : MonoBehaviour
{
    public void OnResumeButton()
    {
        Time.timeScale = 1f;        //time of the game is set back to normal
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene("Phase1");        //scene is loaded back with all the variables set to their initial values
        Time.timeScale = 1f;        //time of the game is set back to normal
    }

    public void OnMidQuitButton()
    {
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
