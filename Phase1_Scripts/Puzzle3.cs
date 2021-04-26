using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : MonoBehaviour
{
    private string choice;
    private int option, attempts;
    public GameObject Puzzle_3, proceedButton, puzzle_station, nextPhase;
    private float startTime, attemptTime;

    // Start is called before the first frame update
    void Start()
    {
        option = 0;
        attempts = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        attempts++;
        Puzzle_3.SetActive(true);
        KingsMovementScript.puzzleActive = true;

        startTime = Time.time;
    }

    public void OnChoice(int val)
    {
        option = val;
        if (val == 1)
        {
            choice = "Straight : INCORRECT";
        }
        if (val == 2)
        {
            choice = "Left : CORRECT";
        }
        if (val == 3)
        {
            choice = "Right : INCORRECT";
        }
    }

    public void OnProceedButton()
    {
        attemptTime = Time.time - startTime;

        KingsMovementScript.puzzleActive = false;
        proceedButton.SetActive(false);
        if (option == 2)
        {
            puzzle_station.SetActive(false);
            KingsMovementScript.tasksDone++;
        }
        else if(attempts == 3)
        {
            KingsMovementScript.tasksfailed++;
            puzzle_station.SetActive(false);
        }
        if (KingsMovementScript.tasksDone + KingsMovementScript.tasksfailed == 4)
        {
            nextPhase.SetActive(true);
        }

        Phase1Data.pre_puzzle_Data[attempts + 5] = "Puzzle_3_attempt_" + attempts.ToString() + ": " + choice + "    Time taken: " + attemptTime.ToString() + " seconds.";
    }

    

    // Update is called once per frame
    void Update()
    {
        if (option > 0)
        {
            proceedButton.SetActive(true);
        }
        else
        {
            proceedButton.SetActive(false);
        }

    }
}
