//code for Mandate Button

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MandateButtonScript : MonoBehaviour
{
    public GameObject mandate, incentive;
    public static bool taskDone1, mandateClicked;
    float buttonDisableTime1;

    //function to be run when Mandate button is clicked
    public void OnMendateButton()
    {
        mandateClicked = true;
        mandate.SetActive(false);           //mandate button is not shown on the screen
        buttonDisableTime1 = Time.time;     //records time when mandate button was clicked

        if (IncentiveButtonScript.taskDone2 == false)
        {
            incentive.SetActive(true);      //activates incentive button in case user changes mind
            IncentiveButtonScript.incentiveClicked = false;     
        }
    }

    private void Start()
    {
        taskDone1 = false;
        mandateClicked = false;
        buttonDisableTime1 = -3f;
    }

    void Update()
    {
        if (Time.time > buttonDisableTime1 + 3 && mandateClicked == true)       //checks if button was clicked and activates button after 5 seconds
        {
            mandateClicked = false;
            mandate.SetActive(true);
            taskDone1 = false;
        }

        //code for raycasting to detect touch on the screen
        if (Input.GetMouseButtonDown(0))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit raycastHit;

            if (Physics.Raycast(raycast, out raycastHit))
            {

                if (raycastHit.collider.tag == "Infected" && mandateClicked == true && taskDone1 == false && UIText.budget >= 100)
                {
                   // Handheld.Vibrate();
                    taskDone1 = true;                                       //indicates that quarantine was attempted
                    raycastHit.collider.gameObject.SetActive(false);        //deactivates the person tapped
                    VirusSpread.infectedInMarket--;                         //decreases count of infected people on the screen by 1
                    UIText.budget = UIText.budget - 100;                    //deducts 100 coins from the budget
                }
            }
        }
    }
}
