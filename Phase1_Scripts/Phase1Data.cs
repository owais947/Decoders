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


public class PreDataStorage
{
    public string name;
    public string[] data;

    public PreDataStorage(string[] data, string name)
    {
        this.data = data;
        this.name = name;
    }
}
public class Phase1Data : MonoBehaviour
{
    public static string[] pre_puzzle_Data;
    public TMP_InputField userName;
    public static string nameOfUser;

    private void Start()
    {
        pre_puzzle_Data = new string[12];
    }

    public void onNextButton()
    {
        nameOfUser = userName.text;
    }

    public static void PreSaveData()
    {
        PreDataStorage PrePhaseData = new PreDataStorage(pre_puzzle_Data, nameOfUser);

        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {PlayFabMerger.loginTime + " PREPHASE", JsonConvert.SerializeObject(PrePhaseData)}
            }
        };

        PlayFabClientAPI.UpdateUserData(request, Phase3Data.OnDataSend, Phase3Data.OnError);
    }
}
