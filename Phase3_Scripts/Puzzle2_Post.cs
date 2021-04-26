using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle2_Post : MonoBehaviour
{
    public GameObject puzzle_2, myJoyStick, king, puzzle_station, map;
    private int numberOfarrows, pos, attempts;
    public GameObject[] inputs;
    public GameObject[] inputButtons;
    private float startTime, attemptTime;
    private string attemptData;

    private void OnTriggerEnter(Collider other)
    {
        attemptData = "";
        attempts++;
        puzzle_2.SetActive(true);
        KingsMovementScript.puzzleActive = true;
        map.SetActive(false);
        pos = 40;
        numberOfarrows = 0;
        for (int i = 0; i < 8; i++)
        {
            inputs[i].SetActive(false);
            inputs[i].transform.localRotation = new Quaternion(0, 0, 0, 0);
        }

        inputButtons[0].SetActive(true);
        inputButtons[1].SetActive(true);
        inputButtons[2].SetActive(true);
        inputButtons[3].SetActive(true);
        inputButtons[4].SetActive(false);

        startTime = Time.time;
    }

    public void OnLeftInput()
    {
        if (numberOfarrows < 8)
        {
            inputs[numberOfarrows].SetActive(true);
            numberOfarrows++;
            pos -= 8;
            attemptData += "Left ";
        }

    }

    public void OnRightInput()
    {
        if (numberOfarrows < 8)
        {
            inputs[numberOfarrows].SetActive(true);
            inputs[numberOfarrows].transform.Rotate(0, 0, 180);
            numberOfarrows++;
            pos += 8;
            attemptData += "Right ";
        }
    }

    public void OnUpInput()
    {
        if (numberOfarrows < 8)
        {
            inputs[numberOfarrows].SetActive(true);
            inputs[numberOfarrows].transform.Rotate(0, 0, -90);
            numberOfarrows++;
            pos -= 1;
            attemptData += "Up ";
        }
    }

    public void OnDownInput()
    {
        if (numberOfarrows < 8)
        {
            inputs[numberOfarrows].SetActive(true);
            inputs[numberOfarrows].transform.Rotate(0, 0, 90);
            numberOfarrows++;
            pos += 1;
            attemptData += "Down ";
        }

    }

    public void OnProceedInput()
    {
        attemptTime = Time.time - startTime;

        puzzle_2.SetActive(false);
        KingsMovementScript.puzzleActive = false;
        map.SetActive(true);

        if (pos == 50)
        {
            KingsMovementScript.tasksDone++;
            puzzle_station.SetActive(false);
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

        Phase3Data.post_puzzle_Data[attempts + 2] = "Puzzle_2_attempt_" + attempts.ToString() + ": " + attemptData + "    Time taken: " + attemptTime.ToString() + " seconds.";
    }
    // Start is called before the first frame update
    void Start()
    {
        puzzle_2.SetActive(false);
        numberOfarrows = 0;
        KingsMovementScript.puzzleActive = false;
        attempts = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfarrows >= 8)
        {
            inputButtons[0].SetActive(false);
            inputButtons[1].SetActive(false);
            inputButtons[2].SetActive(false);
            inputButtons[3].SetActive(false);
            inputButtons[4].SetActive(true);
            KingsMovementScript.puzzleActive = false;
        }

    }
}
