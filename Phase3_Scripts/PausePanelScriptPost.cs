using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanelScriptPost : MonoBehaviour
{
    
    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void OnRestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Phase1");
    }

    public void OnQuitButton()
    {
        Phase3Data.PostSaveData();
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            SceneManager.LoadScene("Phase1");
        }
        else
        {
            Application.Quit();
        }
    }

    public void OnPauseButton()
    {
        Time.timeScale = 0f;
    }

    public void OnResumeButton()
    {
        Time.timeScale = 1f;        //time of the game is set back to normal
    }

    private void Update()
    {
        
    }
}
