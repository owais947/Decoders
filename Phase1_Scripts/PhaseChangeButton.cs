using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhaseChangeButton : MonoBehaviour
{
    public void OnPhaseChangeButton()
    {
        SceneManager.LoadScene("Phase2");
    }
}
