using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Level1";
    public string loadToMultiplayer = "Loading";

    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void MultiplayPlay()
    {
        sceneFader.FadeTo(loadToMultiplayer);
    }

    public void Quit()
    {

        Debug.Log("Exiting ...");
        Application.Quit();

    }
}
