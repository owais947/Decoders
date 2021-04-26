using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Puzzle1 : MonoBehaviour
{
    private string attemptData;
    public GameObject puzzle_1, myJoyStick, king, station1, map;
    private int numberOfarrows, pos, attempts;
    public GameObject[] inputs;
    public GameObject[] inputButtons;
    private float startTime, attemptTime;

    private void OnTriggerEnter(Collider other)
    {
        attemptData = "";
        attempts++;
        puzzle_1.SetActive(true);
        KingsMovementScript.puzzleActive = true;
        map.SetActive(false);
        pos = 1;
        numberOfarrows = 0;

        inputs[0].SetActive(false);
        inputs[1].SetActive(false);
        inputs[2].SetActive(false);

        inputs[0].transform.localRotation = new Quaternion(0, 0, 0, 0);
        inputs[1].transform.localRotation = new Quaternion(0, 0, 0, 0);
        inputs[2].transform.localRotation = new Quaternion(0, 0, 0, 0);

        inputButtons[0].SetActive(true);
        inputButtons[1].SetActive(true);
        inputButtons[2].SetActive(true);
        inputButtons[3].SetActive(true);
        inputButtons[4].SetActive(false);

        startTime = Time.time;
    }

    public void OnLeftInput()
    {
        if(numberOfarrows < 3)
        {
            inputs[numberOfarrows].SetActive(true);
            numberOfarrows++;
            pos -= 3;
            attemptData += "Left ";
        }
        
    }

    public void OnRightInput()
    {
        if (numberOfarrows < 3)
        {
            inputs[numberOfarrows].SetActive(true);
            inputs[numberOfarrows].transform.Rotate(0, 0, 180);
            numberOfarrows++;
            pos += 3;
            attemptData += "Right ";
        }
    }

    public void OnUpInput()
    {
        if (numberOfarrows < 3)
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
        if(numberOfarrows < 3)
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

        puzzle_1.SetActive(false);
        KingsMovementScript.puzzleActive = false;
        map.SetActive(true);

        if (pos == 8)
        {
            KingsMovementScript.tasksDone++;
            station1.SetActive(false);
            attemptData += ": CORRECT";
        }
        else if (attempts == 3)
        {
            KingsMovementScript.tasksfailed++;
            station1.SetActive(false);
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

        Phase1Data.pre_puzzle_Data[attempts - 1] = "Puzzle_1_attempt_" + attempts.ToString() + ": " + attemptData + "    Time taken: " + attemptTime.ToString() + " seconds.";
    }
    // Start is called before the first frame update
    void Start()
    {
        puzzle_1.SetActive(false);
        numberOfarrows = 0;
        KingsMovementScript.puzzleActive = false;
        attempts = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfarrows >= 3)
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
