//code for Incentive Button

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncentiveButtonScript : MonoBehaviour
{
    public GameObject mandate, incentive;
    int incentiveOdds;
    public static bool taskDone2, incentiveClicked;

    //function to be run when Incentive button is clicked
    public void OnIncentiveButton()
    {
        incentiveClicked = true;
        incentive.SetActive(false);     //Incentive button is deactived after tapping on it 

        if (MandateButtonScript.taskDone1 == false)
        {
            mandate.SetActive(true);
            MandateButtonScript.mandateClicked = false;     //Mandate button remains on the screen if user changes mind to choose the other tool
        }
          
        incentiveOdds = Random.Range(1, 4);     //Incentive probability
    }

    private void Start()
    {
        taskDone2 = false;      //shows attempt to quarantine infected person using Incentive Button
        incentiveClicked = false;       //indicates if incentive button is clicked
    }
    void Update()
    {
        if (incentiveClicked == true && taskDone2 == true)      //condition is true when quarantine is attempted using incentive button
        {
            incentiveClicked = false;
            incentive.SetActive(true);
            taskDone2 = false;
        }

        //code for raycasting to detect touch on the screen
        if (Input.GetMouseButtonDown(0))
        {
                Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHit;

            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.tag == "Infected" && incentiveClicked == true && taskDone2 == false && UIText.budget >= 50)
                {
                   // Handheld.Vibrate();
                    taskDone2 = true;                       //indicates that quarantine was attempted
                    UIText.budget = UIText.budget - 50;     //deducts 50 coins for quarantine attempt

                    if (incentiveOdds == 1)
                    {
                        raycastHit.collider.gameObject.SetActive(false);    //deactivates the person tapped
                        VirusSpread.infectedInMarket--;                     //decrease count of infected people on the screen by 1
                    }
                    else
                    {
                        //Debug.Log("Try Again");
                    }
                }
            } 
        }
    }
}
