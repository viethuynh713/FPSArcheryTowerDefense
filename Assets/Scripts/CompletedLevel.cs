using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    private string nextLevel;// = "Level"+(GameManager.instance.level+1).ToString();
    // public int levelToUnlock = 2;
    private void Start() {
        nextLevel = "Level"+(GameManager.instance.level+1).ToString();
    }

    public void Continue()
    {
        // PlayerPrefs.SetInt("levelReached", levelToUnlock);
        Time.timeScale = 1f;
        GameManager.instance.level++;
        GameManager.instance.isGameOver = false;
        GameManager.instance.isWin = false;
        sceneFader.FadeTo(nextLevel);
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;

    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
