//code for all the UI text that appears during the game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    private GUIStyle labelStyle;
    private string currentTime;
    private int width, height;
    private Rect rect;
    private float timer;
    public Text money;
    public static int budget;
    public GameObject nextPhase;
    private bool dataCollected;

    public GameObject button1, button2, pausePanel;

    //this is called when games starts, values of some parameters are set here
    void Awake()
    {
        width = Screen.width;
        height = Screen.height;
        rect = new Rect(10, 10, width - 20, height - 20);
    }


    // Start is called before the first frame update
    void Start()
    {
        budget = 1000;      //initial budget is set
        dataCollected = false;
    }

    // Update is called once per frame
    void Update()
    {
        money.text = "Coins : "+ budget.ToString();       //budget is updated every frame
    }

    void OnGUI()
    {
        // Display the label at the center of the window.
        labelStyle = new GUIStyle(GUI.skin.GetStyle("label"));
        labelStyle.alignment = TextAnchor.UpperCenter;

        // Modify the size of the font based on the window.
        labelStyle.fontSize = 8 * (width / 200);

        timer = 120 + StartButtonScript.startTime - Time.time;      //timer value is calculated

        if (timer >= 0 && VirusSpread.numberOfInfected < 30 && VirusSpread.infectedInMarket != 0 && budget > 0)
        {
            // Obtain the current time.
            currentTime = (timer).ToString("F0");

            currentTime = "Timer: " + currentTime + " sec.";

            // Display the current time.
            GUI.Label(rect, currentTime, labelStyle);
        }

        if((timer < 0 || VirusSpread.numberOfInfected == 30 || budget <= 0) && pausePanel.activeSelf != true)      //this condition is satisfied when user loses the game
        {
            labelStyle.alignment = TextAnchor.MiddleCenter;
            currentTime = "YOU ARE ALREADY DEAD";
            GUI.Label(rect, currentTime, labelStyle);
            nextPhase.SetActive(true);

            button1.SetActive(false);
            button2.SetActive(false);

            collectData();
            Phase2Data.result = "FAILED";
        }

        if (VirusSpread.infectedInMarket == 0 && pausePanel.activeSelf != true)      //this condition is satisfied when user wins the game
        {
            labelStyle.alignment = TextAnchor.MiddleCenter;
            currentTime = "YOU ROCK!";
            GUI.Label(rect, currentTime, labelStyle);
            nextPhase.SetActive(true);

            button1.SetActive(false);
            button2.SetActive(false);

            collectData();
            Phase2Data.result = "PASSED";
        }

        if (pausePanel.activeSelf == true)
        {
            labelStyle.alignment = TextAnchor.MiddleCenter;
            currentTime = " ";
            GUI.Label(rect, currentTime, labelStyle);
        }
    }

    public void collectData()
    {
        if(dataCollected == false)
        {
            Phase2Data.timeLeft = (int)timer;
            Phase2Data.peopleQuarantined = VirusSpread.numberOfInfected - VirusSpread.infectedInMarket;
            Phase2Data.coinsLeft = budget;
            dataCollected = true;
        }
    }
}

