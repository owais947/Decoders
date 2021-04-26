using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle2 : MonoBehaviour
{
    private string firstChoice, secondChoice, thirdChoice, attemptData;
    int option1, option2, option3, attempts;
    public GameObject Puzzle_2, proceedButton, puzzle_station, nextPhase;
    private float startTime, attemptTime;

    // Start is called before the first frame update
    void Start()
    {
        option1 = 0;
        option2 = 0;
        option3 = 0;
        attempts = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        attempts++;
        Puzzle_2.SetActive(true);
        KingsMovementScript.puzzleActive = true;

        startTime = Time.time;
    }

    public void OnFirstChoice(int val)
    {
        option1 = val;
        if(val == 1)
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

    public void OnThirdChoice(int val)
    {
        option3 = val;
        if (val == 1)
        {
            thirdChoice = "Left ";
        }
        if (val == 2)
        {
            thirdChoice = "Right ";
        }
    }

    public void OnProceedButton()
    {
        attemptData = firstChoice + thirdChoice + secondChoice;

        attemptTime = Time.time - startTime;

        KingsMovementScript.puzzleActive = false;
        proceedButton.SetActive(false);
        if(option1 == 1 && option2 == 3 && option3 == 1)
        {
            puzzle_station.SetActive(false);
            KingsMovementScript.tasksDone++;
            attemptData += ": CORRECT";
        }
        else if(attempts == 3)
        {
            KingsMovementScript.tasksfailed++;
            puzzle_station.SetActive(false);
            attemptData += ": INCORRECT";
        }
        else
        {
            attemptData += ": INCORRECT";
        }

        if (KingsMovementScript.tasksDone + KingsMovementScript.tasksfailed == 4)
        {
            nextPhase.SetActive(true);
        }

        Phase1Data.pre_puzzle_Data[attempts + 2] = "Puzzle_2_attempt_" + attempts.ToString() + ": " + attemptData + "    Time taken: " + attemptTime.ToString() + " seconds.";
    }

    // Update is called once per frame
    void Update()
    {
        if(option1 > 0 && option2 > 0 && option3 > 0)
        {
            proceedButton.SetActive(true);
        }
        else
        {
            proceedButton.SetActive(false);
        }

    }
}
