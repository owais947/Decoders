using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using SimpleJSON;

public class PlayFabMerger : MonoBehaviour
{
    public static string loginTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }
    void OnSuccess(LoginResult result)
    {
        Debug.Log("Successful Login/ Account Create!");
        loginTime = result.LastLoginTime.ToString();
    }

    void OnError(PlayFabError Error)
    {
        Debug.Log("Error while logging in/ Creating Account!");
        Debug.Log(Error.GenerateErrorReport());
    }
}
