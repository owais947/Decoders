//code for pause button

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonScript : MonoBehaviour
{
    public void OnPauseButton()
    {
        Time.timeScale = 0f;        //time in the game is stopped
    }
    
    public void OnNextPhase()
    {
        SceneManager.LoadScene("Phase3");
    }
}
