using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool cursorLocked = true;

    public string menuSceneName = "MainMenu";

    public GameObject UI;
    public GameObject ShopUI;

    public SceneFader sceneFader;

    public GameObject sceneFaderGO;

    [HideInInspector]
    public BowScript bs;

    private Motion mt;

    private void Start()
    {
        bs = FindObjectOfType<BowScript>();

        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;

        sceneFader = FindObjectOfType<SceneFader>();

    }

    void Update()
    {
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ShopUI.SetActive(true);
        UI.SetActive(false);
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

        bs.isTimeStopped = cursorLocked;

    }

    public void UpdateCusorLock2()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (cursorLocked)
            {
                UI.SetActive(false);

                Time.timeScale = 1f;

                Cursor.lockState = CursorLockMode.Locked;

                Cursor.visible = true;

                cursorLocked = false;

                bs.isTimeStopped = cursorLocked;
            }
            else
            {
                UI.SetActive(true);

                Time.timeScale = 0f;

                Cursor.lockState = CursorLockMode.None;

                Cursor.visible = false;

                cursorLocked = true;

                bs.isTimeStopped = cursorLocked;
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
}
