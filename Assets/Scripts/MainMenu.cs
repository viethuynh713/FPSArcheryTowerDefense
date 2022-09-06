using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Level1";

    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();

    }

    public void EnablePauseMenu()
    {
        PauseMenu.instance.enabled = true;
    }

    public void DisablePauseMenu()
    {
        PauseMenu.instance.enabled = false;
    }
}
