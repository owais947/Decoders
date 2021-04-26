using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle4 : MonoBehaviour
{
    public GameObject puzzle_4, myJoyStick, king, station4, map;
    private int numberOfarrows, pos, attempts;
    public GameObject[] inputs;
    public GameObject[] inputButtons;
    private float startTime, attemptTime;
    private string attemptData;
    private bool infected, key_taken;

    private void OnTriggerEnter(Collider other)
    {
        infected = false;
        key_taken = false;

        attemptData = "";
        attempts++;
        puzzle_4.SetActive(true);
        KingsMovementScript.puzzleActive = true;
        map.SetActive(false);
        pos = 4;
        numberOfarrows = 0;
        for(int i = 0; i < 6; i++)
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
        if (numberOfarrows < 6)
        {
            inputs[numberOfarrows].SetActive(true);
            numberOfarrows++;
            pos -= 4;
            attemptData += "Left ";
        }

    }

    public void OnRightInput()
    {
        if (numberOfarrows < 6)
        {
            inputs[numberOfarrows].SetActive(true);
            inputs[numberOfarrows].transform.Rotate(0, 0, 180);
            numberOfarrows++;
            pos += 4;
            attemptData += "Right ";
        }
    }

    public void OnUpInput()
    {
        if (numberOfarrows < 6)
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
        if (numberOfarrows < 6)
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

        puzzle_4.SetActive(false);
        KingsMovementScript.puzzleActive = false;
        map.SetActive(true);

        if (pos == 13 && infected == false && key_taken == true)
        {
            KingsMovementScript.tasksDone++;
            station4.SetActive(false);
            attemptData += ": CORRECT";
        }
        else if (attempts == 3)
        {
            KingsMovementScript.tasksfailed++;
            station4.SetActive(false);
            attemptData += ": INCORRECT";
        }
        else
        {
            attemptData += ": INCORRECT";
        }

        if (KingsMovementScript.tasksDone + KingsMovementScript.tasksfailed == 4)
        {
            inputButtons[5].SetActive(true);
        }

        Phase1Data.pre_puzzle_Data[attempts + 8] = "Puzzle_4_attempt_" + attempts.ToString() + ": " + attemptData + "    Time taken: " + attemptTime.ToString() + " seconds.";
    }
    // Start is called before the first frame update
    void Start()
    {
        puzzle_4.SetActive(false);
        numberOfarrows = 0;
        KingsMovementScript.puzzleActive = false;
        attempts = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfarrows >= 6)
        {
            inputButtons[0].SetActive(false);
            inputButtons[1].SetActive(false);
            inputButtons[2].SetActive(false);
            inputButtons[3].SetActive(false);
            inputButtons[4].SetActive(true);
            KingsMovementScript.puzzleActive = false;
        }

        if (pos == 2) infected = true;
        if (pos == 10) key_taken = true;
    }
}
