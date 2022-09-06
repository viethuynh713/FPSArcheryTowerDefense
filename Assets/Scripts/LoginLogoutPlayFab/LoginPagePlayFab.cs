using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.SceneManagement;

public class ConfigPlayerDefault {
    public static string defaultLevel = "1";
    public static string defaultMoney = "100000";
    public static string defaultIcedArrowLeft = "5";  
    public static string defaultIcedArrowPer = "20";  
    public static string defaultIcedArrowDur = "1";
    public static string defaultBompArrowLeft = "5";
    public static string defaultBompArrowDOT = "20";
    public static string defaultBompArrowDur = "1";
}


public class LoginPagePlayFab : MonoBehaviour
{
    public static LoginPagePlayFab instance;
    [SerializeField] private GameObject[] leaderboardUI;
    [SerializeField] private GameObject loginPageUI;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject loginStatus;

    [SerializeField] TextMeshProUGUI TopText;
    [SerializeField] TextMeshProUGUI MessageText;

    [Header("Login")]
    [SerializeField] TMP_InputField EmailLoginIF;
    [SerializeField] TMP_InputField PasswordIF;
    [SerializeField] GameObject loginPage;

    [Header("Register")]
    [SerializeField] TMP_InputField UsernameRegisterIF;
    [SerializeField] TMP_InputField EmailRegisterIF;
    [SerializeField] TMP_InputField PasswordRegisterIF;
    [SerializeField] GameObject registerPage;


    [Header("Forgot")]
    [SerializeField] TMP_InputField EmailRecoveryIF;
    [SerializeField] GameObject recoveryPage;

    [Header("Welcome")]
    [SerializeField] TextMeshProUGUI welcomeText;
    [SerializeField] GameObject welcomeGO;

    private string playerId;
    private Animator loginStatusAnim;

    private void Awake()
    {
        if(instance != this)
        {
            instance = this;
        }
        DontDestroyOnLoad(instance);

        loginStatusAnim = loginStatus.GetComponent<Animator>();
    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = EmailLoginIF.text,
            Password = PasswordIF.text,

            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true,
            }
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginError);
    }

    private void OnLoginError(PlayFabError error)
    {
        MessageText.text = error.ErrorMessage;
        StartCoroutine(LoginStatus());
    }

    public void Logout()
    {
        PlayFabClientAPI.ForgetAllCredentials();
        
        loginPageUI.SetActive(true);
        foreach (var go in leaderboardUI)
        {
            
            go.SetActive(false);
        }
        menuUI.SetActive(false);
    }

    public IEnumerator LoginStatus()
    {
        loginStatus.SetActive(true);

        loginStatusAnim.Play("LoginStatus");

        yield return new WaitForSeconds(2f);

        loginStatus.SetActive(false);
    }

    private void OnLoginSuccess(LoginResult success)
    {
        string name = null;

        name = success.InfoResultPayload.PlayerProfile.DisplayName;

        playerId = success.PlayFabId;

        MessageText.text = "Login Successfully!";

        Debug.Log("Login Successfully!");

        StartCoroutine(LoginStatus());

        welcomeText.text = "Welcome, " + name;

        //GetPlayerData();

        GetPlayerData();

        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2.5f);
        loginPageUI.SetActive(false);

        //foreach(var go in leaderboardUI)
        //    go.SetActive(true);
        menuUI.SetActive(true);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenLeaderboardUI()
    {
        foreach (var go in leaderboardUI)
        {
            var activeStat = go.activeSelf;
            go.SetActive(!activeStat);
        }
        LeaderboardPlayFab.instance.GetLeaderboard();
        LeaderboardPlayFab.instance.GetMyRank();

    }

    public void GoToGame()
    {
        foreach(var ui in leaderboardUI)
        {
            ui.SetActive(false);
        }
        loginPageUI.SetActive(false);
        menuUI.SetActive(false);

        SceneManager.LoadScene("MainMenu");
    }

    public void RecoverUser()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = EmailRecoveryIF.text,
            TitleId = "493F3",
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoverySuccess, OnErrorRecoveryEmail); 
    }

    private void OnErrorRecoveryEmail(PlayFabError obj)
    {
        MessageText.text = "Unvalid Email Address!";
    }

    private void OnRecoverySuccess(SendAccountRecoveryEmailResult obj)
    {
        OpenLoginPage();
        MessageText.text = "Recovery Email Sent!";
    }

    public void RegisterUser()
    {
        var request = new RegisterPlayFabUserRequest
        {
            DisplayName = UsernameRegisterIF.text,
            Email = EmailRegisterIF.text,
            Password = PasswordRegisterIF.text,

            RequireBothUsernameAndEmail = false,
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    private void OnError(PlayFabError error)
    {
        MessageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult success)
    {
        MessageText.text = "Account Register Successfully!";
        StartCoroutine(LoginStatus());
        OpenLoginPage();
    }

    public void GetPlayerData()
    {
        var request = new GetUserDataRequest
        {
            PlayFabId = playerId,
            Keys = null,
        };
        PlayFabClientAPI.GetUserData(request, OnGetDataSuccess, OnGetDataError);
    }

    public static string defaultLevel = "1";

    public void SendPlayerData()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>()
            {
                 {"maxLevelReach", GameManager.instance.maxLevelReach.ToString() },
                 {"Money",GameManager.instance.money.ToString() },
                 {"IcedArrowLeft", GameManager.instance.IceQuantity.ToString() },
                 {"IcedArrowPer",GameManager.instance.IceRateSlow.ToString() },
                 {"IcedArrowDur", GameManager.instance.IceTimeSlowDuration.ToString() },
                 {"BompArrowLeft", GameManager.instance.FireQuantity.ToString() },
                 {"BompArrowDOT", GameManager.instance.FireDamBurn.ToString() },
                 {"BompArrowDur", GameManager.instance.FireTimeBurnDuration.ToString() },
            }
        };

        PlayFabClientAPI.UpdateUserData(request, OnSentSuccess, OnError);
    }

    public void SetPlayerDefaultData()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>()
            {
                 {"maxLevelReach", ConfigPlayerDefault.defaultLevel },
                 {"Money",ConfigPlayerDefault.defaultMoney },
                 {"IcedArrowLeft", ConfigPlayerDefault.defaultIcedArrowLeft },
                 {"IcedArrowPer",ConfigPlayerDefault.defaultIcedArrowPer },
                 {"IcedArrowDur", ConfigPlayerDefault.defaultIcedArrowDur },
                 {"BompArrowLeft", ConfigPlayerDefault.defaultBompArrowLeft },
                 {"BompArrowDOT", ConfigPlayerDefault.defaultBompArrowDOT },
                 {"BompArrowDur", ConfigPlayerDefault.defaultBompArrowDur },

       
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnSentSuccess, OnError);
       
    }

    private void OnSentSuccess(UpdateUserDataResult result)
    {
        Debug.Log("Send Data Success!");
    }

    private void OnGetDataSuccess(GetUserDataResult result)
    {
        if (result.Data == null || !result.Data.ContainsKey("Money"))
        {
            Debug.Log("No data, set default!");
            SetPlayerDefaultData();
            
            GetPlayerData();
        }
        else
        {
            Debug.Log("Getting Data ...");
            GameManager.instance.money = int.Parse(result.Data["Money"].Value);
            GameManager.instance.maxLevelReach = int.Parse(result.Data["maxLevelReach"].Value);
            GameManager.instance.IceQuantity = int.Parse(result.Data["IcedArrowLeft"].Value);
            GameManager.instance.IceRateSlow = int.Parse(result.Data["IcedArrowPer"].Value);
            GameManager.instance.IceTimeSlowDuration = int.Parse(result.Data["IcedArrowDur"].Value);
            GameManager.instance.FireQuantity = int.Parse(result.Data["BompArrowLeft"].Value);
            GameManager.instance.FireDamBurn = int.Parse(result.Data["BompArrowDOT"].Value);
            GameManager.instance.FireTimeBurnDuration = int.Parse(result.Data["BompArrowDur"].Value);
        }
    }

    private void OnGetDataError(PlayFabError obj)
    {
        throw new NotImplementedException();
    }

    #region Button
    public void OpenLoginPage()
    {
        loginPage.SetActive(true);
        registerPage.SetActive(false);
        recoveryPage.SetActive(false);
        TopText.text = "LOGIN";
    }

    public void OpenRegisterPage()
    {
        loginPage.SetActive(false);
        registerPage.SetActive(true);
        recoveryPage.SetActive(false);
        TopText.text = "REGISTER";
    }

    public void OpenRecoveryPage()
    {
        loginPage.SetActive(false);
        registerPage.SetActive(false);
        recoveryPage.SetActive(true);
        TopText.text = "RECOVERY";
    }
    #endregion
}
