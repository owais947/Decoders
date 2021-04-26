using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KingsMovementScript : MonoBehaviour
{
    public static int tasksDone, tasksfailed;

    public Animation anim;
    public AnimationClip run, idle, walk;
    public Joystick joystick;
    public GameObject kingObj, camObj;
    private Rigidbody king;
    public static bool puzzleActive;
    public TMP_Text puzzlesRemaining;
    void Start()
    {
        tasksDone = 0;
        tasksfailed = 0;
        // Set the wrap mode of the idle animation to loop
        anim["idle"].wrapMode = WrapMode.Loop;
        king = kingObj.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        puzzlesRemaining.text = "Puzzles Remaining : " + (4 - tasksfailed - tasksDone).ToString();
        puzzlesRemaining.text = "Puzzles Remaining : " + (4 - tasksfailed - tasksDone).ToString();

        camObj.transform.position = new Vector3(kingObj.transform.position.x, camObj.transform.position.y, kingObj.transform.position.z - 12f);

        if(puzzleActive == true)
        {
            king.velocity = new Vector3(0, 0, 0);
            anim.clip = idle;
            anim.Play();
            king.freezeRotation = true;
        }
        else
        {
            if (joystick.Horizontal != 0 && joystick.Vertical != 0)
            {
                if (joystick.Horizontal >= 0.3f || joystick.Vertical >= 0.3f || joystick.Horizontal <= -0.3f || joystick.Vertical <= -0.3f)
                {
                    king.velocity = new Vector3(joystick.Horizontal * 10, 0, joystick.Vertical * 10);
                    kingObj.transform.LookAt(king.velocity * 100);
                    anim.clip = run;
                    anim.Play();
                }
                else
                {
                    king.velocity = new Vector3(joystick.Horizontal * 10, 0, joystick.Vertical * 10);
                    kingObj.transform.LookAt(king.velocity * 100);
                    anim.clip = walk;
                    anim.Play();
                }
            }
            else
            {
                if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
                {
                    king.velocity = new Vector3(0, 0, 0);
                    anim.clip = idle;
                    anim.Play();
                    king.freezeRotation = true;
                }
                else
                {
                    keyboardControl();
                    kingObj.transform.LookAt(king.velocity * 100);
                    anim.clip = run;
                    anim.Play();
                }
            }
        }           
    }

    private void keyboardControl()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            king.velocity = new Vector3(-8f, 0, king.velocity.z);
        }
        if (Input.GetKey(KeyCode.W))
        {
            king.velocity = new Vector3(king.velocity.x, 0, 8f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            king.velocity = new Vector3(king.velocity.x, 0, -8f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            king.velocity = new Vector3(8f, 0, king.velocity.z);
        }
        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            king.velocity = new Vector3(0, 0, 0);
        }
    }
}
