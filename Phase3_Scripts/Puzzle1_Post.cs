using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Puzzle1_Post : MonoBehaviour
{
    public GameObject puzzle_1, station1;
    private int attempts;
    private float startTime, attemptTime;
    private string attemptData;

    private void OnTriggerEnter(Collider other)
    {
        puzzle_1.SetActive(true);
        KingsMovementScript.puzzleActive = true;
        startTime = Time.time;
        attempts++;
    }

    public void OnButtonA()
    {
        KingsMovementScript.puzzleActive = false;

        attemptTime = Time.time - startTime;
        attemptData = "2 Times : INCORRECT";

        Phase3Data.post_puzzle_Data[attempts - 1] = "Puzzle_1_attempt_" + attempts.ToString() + ": " + attemptData + "    Time taken: " + attemptTime.ToString() + " seconds.";

        puzzle_1.SetActive(false);

        if(attempts == 3)
        {
            station1.SetActive(false);
            KingsMovementScript.tasksfailed++;
        }
    }

    public void OnButtonB()
    {
        KingsMovementScript.puzzleActive = false;

        attemptTime = Time.time - startTime;
        attemptData = "1 Time : INCORRECT";

        Phase3Data.post_puzzle_Data[attempts - 1] = "Puzzle_1_attempt_" + attempts.ToString() + ": " + attemptData + "    Time taken: " + attemptTime.ToString() + " seconds.";

        puzzle_1.SetActive(false);

        if (attempts == 3)
        {
            station1.SetActive(false);
            KingsMovementScript.tasksfailed++;
        }
    }

    public void OnButtonC()
    {
        KingsMovementScript.puzzleActive = false;

        attemptTime = Time.time - startTime;
        attemptData = "4 Times : INCORRECT";

        Phase3Data.post_puzzle_Data[attempts - 1] = "Puzzle_1_attempt_" + attempts.ToString() + ": " + attemptData + "    Time taken: " + attemptTime.ToString() + " seconds.";

        puzzle_1.SetActive(false);

        if (attempts == 3)
        {
            station1.SetActive(false);
            KingsMovementScript.tasksfailed++;
        }
    }

    public void OnButtonD()
    {
        KingsMovementScript.puzzleActive = false;
        KingsMovementScript.tasksDone++;

        attemptTime = Time.time - startTime;
        attemptData = "3 Times : CORRECT";

        Phase3Data.post_puzzle_Data[attempts - 1] = "Puzzle_1_attempt_" + attempts.ToString() + ": " + attemptData + "    Time taken: " + attemptTime.ToString() + " seconds.";

        puzzle_1.SetActive(false);

        station1.SetActive(false);
    }

    void Start()
    {
        puzzle_1.SetActive(false);
        attempts = 0;
        KingsMovementScript.puzzleActive = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}