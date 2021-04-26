using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;


public class PostDataStorage
{
    public string name;
    public string[] data;

    public PostDataStorage(string[] data, string name)
    {
        this.data = data;
        this.name = name;
    }
}
public class Phase3Data : MonoBehaviour
{
    public static string[] post_puzzle_Data;

    private void Start()
    {
        post_puzzle_Data = new string[12];
    }

    public static void PostSaveData()
    {
        PostDataStorage PostPhaseData = new PostDataStorage(post_puzzle_Data, Phase1Data.nameOfUser);

        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {PlayFabMerger.loginTime + " POSTPHASE", JsonConvert.SerializeObject(PostPhaseData)}
            }
        };

        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    public static void OnDataSend(UpdateUserDataResult res)
    {
        Debug.Log("User Data Sent!");
    }

    public static void OnError(PlayFabError Error)
    {
        Debug.Log("Error!");
    }
}
