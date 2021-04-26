using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScriptP1 : MonoBehaviour
{
   public void OnRestartButtonP1()
    {
        SceneManager.LoadScene("Phase1");
    }

    public void OnPauseButton()
    {
        Time.timeScale = 0f;
    }
}
