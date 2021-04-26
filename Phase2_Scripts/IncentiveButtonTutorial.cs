//code for Incentive Button

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IncentiveButtonTutorial : MonoBehaviour
{
    public TMP_Text result;
    public GameObject incentive, next;
    int incentiveOdds;
    private bool taskDone2, incentiveClicked;
    private int quarantined;

    //function to be run when Incentive button is clicked
    public void OnIncentiveButton()
    {
        result.text = " ";
        incentiveClicked = true;
        incentive.SetActive(false);     //Incentive button is deactived after tapping on it 
        incentiveOdds = Random.Range(1, 4);     //Incentive probability
    }

    private void Start()
    {
        taskDone2 = false;      //shows attempt to quarantine infected person using Incentive Button
        incentiveClicked = false;       //indicates if incentive button is clicked
        quarantined = 0;
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
                if (raycastHit.collider.tag == "Infected" && incentiveClicked == true && taskDone2 == false)
                {
                    taskDone2 = true;                       //indicates that quarantine was attempted
                    if (incentiveOdds == 1)
                    {
                        result.text = "The person decided to get quarantined.";
                        raycastHit.collider.gameObject.SetActive(false);    //deactivates the person tapped
                        quarantined++;
                    }
                    else
                    {
                        result.text = "The person did not want to get quarantined.";
                    }
                }
            }
        }

        if(quarantined > 1)
        {
            next.SetActive(true);
            incentive.SetActive(false);
        }
    }
}
