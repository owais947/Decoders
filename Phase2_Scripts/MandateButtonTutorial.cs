//code for Mandate Button

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MandateButtonTutorial : MonoBehaviour
{
    public TMP_Text result;
    public GameObject mandate, next;
    private bool taskDone1, mandateClicked;
    float buttonDisableTime1;
    private int quarantined;

    //function to be run when Mandate button is clicked
    public void OnMendateButton()
    {
        result.text = " ";
        mandateClicked = true;
        mandate.SetActive(false);           //mandate button is not shown on the screen
        buttonDisableTime1 = Time.time;     //records time when mandate button was clicked
    }

    private void Start()
    {
        taskDone1 = false;
        mandateClicked = false;
        buttonDisableTime1 = -3f;
        quarantined = 0;
    }

    void Update()
    {
        if (Time.time > buttonDisableTime1 + 3 && mandateClicked == true)       //checks if button was clicked and activates button after 3 seconds
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

                if (raycastHit.collider.tag == "Infected" && mandateClicked == true && taskDone1 == false)
                {
                    taskDone1 = true;                                       //indicates that quarantine was attempted
                    raycastHit.collider.gameObject.SetActive(false);        //deactivates the person tapped
                    quarantined++;
                    result.text = "The infected person was sent to quarantine immediately.";
                }
            }
        }

        if(quarantined > 1)
        {
            mandate.SetActive(false);
            next.SetActive(true);
        }
    }
}
