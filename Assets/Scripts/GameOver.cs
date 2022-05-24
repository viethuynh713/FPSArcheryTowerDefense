using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text roundText;

    public SceneFader sceneFader;

    public GameObject GOUI;

    public string menuSceneName = "MainMenu";

    private void OnEnable()
    {
        roundText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        GOUI.SetActive(false);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;

        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        GOUI.SetActive(false);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;

        sceneFader.FadeTo(menuSceneName);
    }
}
