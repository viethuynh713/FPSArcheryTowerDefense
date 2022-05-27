using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   
    public bool cursorLocked = true;

    public bool isShopOpen = false;

    public bool isGameOver = false;

    public string menuSceneName = "MainMenu";

    public GameObject UI;
    public GameObject ShopUI;

    public SceneFader sceneFader;

    // public GameObject sceneFaderGO;

    [HideInInspector]
    // public BowScript bs;

    private Motion mt;

    

    public void Start()
    {
        // bs = GameObject.FindGameObjectWithTag("Bow").GetComponent<BowScript>();
        // Debug.Log(bs);
        // Cursor.lockState = CursorLockMode.Locked;

        // Cursor.visible = false;

        sceneFader = FindObjectOfType<SceneFader>();

    }

    public void Update()
    {
        // Debug.Log("isShopOpen");
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
        //UpdateCusorLock();
        UpdateCusorLock2();

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
        isShopOpen = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        Cursor.visible = true;
        ShopUI.SetActive(true);
        UI.SetActive(false);
        GameObject.FindGameObjectWithTag("Bow").GetComponent<BowScript>().isTimeStopped = isShopOpen;
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

    public void Continue()
    {
        UI.SetActive(false);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = true;

        cursorLocked = false;

        GameObject.FindGameObjectWithTag("Bow").GetComponent<BowScript>().isTimeStopped = cursorLocked;

    }

    public void UpdateCusorLock2()
    {
            // Debug.Log("Escape");
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.isGameOver)
        {
            if (cursorLocked)
            {
                UI.SetActive(false);

                Time.timeScale = 1f;

                Cursor.lockState = CursorLockMode.Locked;

                Cursor.visible = true;

                cursorLocked = false;

                GameObject.FindGameObjectWithTag("Bow").GetComponent<BowScript>().isTimeStopped = cursorLocked;
            }
            else
            {
                UI.SetActive(true);

                Time.timeScale = 0f;

                Cursor.lockState = CursorLockMode.None;

                Cursor.visible = false;

                cursorLocked = true;

                GameObject.FindGameObjectWithTag("Bow").GetComponent<BowScript>().isTimeStopped = cursorLocked;
            }
        }

        /*public void UpdateCusorLock()
        {
            if (cursorLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;

                Cursor.visible = false;

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Toggle();
                    cursorLocked = false;
                }
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;

                Cursor.visible = true;

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Toggle();
                    cursorLocked = true;
                }
            }
        }*/
    }

    public void CloseShop()
    {
        isShopOpen = false;
        ShopUI.SetActive(false);
        UI.SetActive(true);
    }
}
