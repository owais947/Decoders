using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{
    private bool dataCollected = false;
    public GameObject pauseButton, myJoystick, mapButton, puzzlesRemaining, GameOver;

    private void Start()
    {
        dataCollected = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (KingsMovementScript.tasksDone + KingsMovementScript.tasksfailed == 4 && dataCollected == false)
        {
            Phase3Data.PostSaveData();
            GameOver.SetActive(true);
            pauseButton.SetActive(false);
            mapButton.SetActive(false);
            myJoystick.SetActive(false);
            puzzlesRemaining.SetActive(false);
            dataCollected = true;
        }
    }
}
