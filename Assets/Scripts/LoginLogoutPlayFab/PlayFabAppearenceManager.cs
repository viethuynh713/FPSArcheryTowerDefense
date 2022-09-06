using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabAppearenceManager : MonoBehaviour
{
    public ChangeAppearance changeAppearance;

    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    public void GetAppearance()
    {

    }

    public void SaveAppearance()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {

            }
        };
    }


    void OnSuccess(LoginResult result)
    {
        Debug.Log("Login Successful");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Login/Register Error!");
        Debug.Log(error.GenerateErrorReport());
    }


    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Data send success!");
    }


    



}

