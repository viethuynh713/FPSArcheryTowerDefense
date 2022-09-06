using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
   
    [SerializeField] private bool cursorLocked;

    [SerializeField] private bool isShopOpen = false;

    public bool isGameOver = false;

    public string menuSceneName = "MainMenu";

    public GameObject UI;
    public GameObject ShopUI;

    public SceneFader sceneFader;

    // public GameObject sceneFaderGO;

    [HideInInspector]
    // public BowScript bs;

    private Motion mt;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cursorLocked = true;

        Cursor.visible = false;

        //sceneFader = FindObjectOfType<SceneFader>();
    }



    public void Update()
    {
        if (isGameOver)
            return;

        if (isShopOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CloseShop();
            }
            return;
        }
        UpdateCusorLock();

    }

    /*public void Toggle()
    {
        

        if (UI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }*/
    
    public void ShopButton(){
        GameManager.instance.ShopUIRefresh();

        isShopOpen = true;

        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;

        Cursor.visible = true;

        ShopUI.SetActive(true);

        UI.SetActive(false);

        //BowScript.instance.enabled = false;
        //GameObject.FindGameObjectWithTag("Bow").GetComponent<BowScript>().isTimeStopped = isShopOpen;
    }

    public void RetryButton()
    {
        UI.SetActive(false);
        //sceneFaderGO.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;

        Debug.Log(SceneManager.GetActiveScene().name.ToString());

        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    

    public void MenuButton()
    {
        UI.SetActive(false);
        //sceneFaderGO.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log(menuSceneName);
        sceneFader.FadeTo(menuSceneName);

    }


    public void UpdateCusorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.isGameOver)
        {
            if(cursorLocked)
            {
                UI.SetActive(true);

                Time.timeScale = 0f;

                Cursor.lockState = CursorLockMode.None;

                Cursor.visible = true;

                cursorLocked = !cursorLocked;

                BowScript.instance.enabled = false;

                //GameObject.FindGameObjectWithTag("Bow").GetComponent<BowScript>().isTimeStopped = cursorLocked;

            }
            else
                Continue();          
        }            
    }

    public void Continue()
    {
        UI.SetActive(false);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;

        cursorLocked = !cursorLocked;

        BowScript.instance.enabled = true;

        Debug.Log(BowScript.instance.enabled);

        //GameObject.FindGameObjectWithTag("Bow").GetComponent<BowScript>().isTimeStopped = cursorLocked;
    }
    public void CloseShop()
    {
        isShopOpen = false;
        ShopUI.SetActive(false);
        UI.SetActive(true);
    }
}
