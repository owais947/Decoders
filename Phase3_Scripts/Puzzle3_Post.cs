using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle3_Post : MonoBehaviour
{
    private string firstChoice, secondChoice, attemptData;
    int option1, option2, attempts;
    public GameObject Puzzle_3, proceedButton, puzzle_station;
    private float startTime, attemptTime;

    // Start is called before the first frame update
    void Start()
    {
        option1 = 0;
        option2 = 0;
        attempts = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        attempts++;
        Puzzle_3.SetActive(true);
        KingsMovementScript.puzzleActive = true;

        startTime = Time.time;
    }

    public void OnFirstChoice(int val)
    {
        option1 = val;
        if (val == 1)
        {
            firstChoice = "Straight ";
        }
        if (val == 2)
        {
            firstChoice = "Left ";
        }
        if (val == 3)
        {
            firstChoice = "Right ";
        }
    }

    public void OnSecondChoice(int val)
    {
        option2 = val;
        if (val == 1)
        {
            secondChoice = "Straight ";
        }
        if (val == 2)
        {
            secondChoice = "Left ";
        }
        if (val == 3)
        {
            secondChoice = "Right ";
        }
    }

    public void OnProceedButton()
    {
        attemptData = firstChoice + secondChoice;

        attemptTime = Time.time - startTime;

        KingsMovementScript.puzzleActive = false;
        proceedButton.SetActive(false);
        if (option1 == 1 && option2 == 2)
        {
            puzzle_station.SetActive(false);
            KingsMovementScript.tasksDone++;
            attemptData += ": CORRECT";
        }
        else if (attempts == 3)
        {
            KingsMovementScript.tasksfailed++;
            puzzle_station.SetActive(false);
            attemptData += ": INCORRECT";
        }
        else
        {
            attemptData += ": INCORRECT";
        }

        Phase3Data.post_puzzle_Data[attempts + 5] = "Puzzle_3_attempt_" + attempts.ToString() + ": " + attemptData + "    Time taken: " + attemptTime.ToString() + " seconds.";
    }

    // Update is called once per frame
    void Update()
    {
        if (option1 > 0 && option2 > 0)
        {
            proceedButton.SetActive(true);
        }
        else
        {
            proceedButton.SetActive(false);
        }

    }
}