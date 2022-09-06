//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class CompletedLevel : MonoBehaviour
//{
//    public static CompletedLevel instance;

//    public string menuSceneName = "MainMenu";

//    public SceneFader sceneFader;

//    public string nextLevel;

//    private void Awake()
//    {
//        if (instance != null)
//            instance = this;
//    }

//    public void Continue()
//    {
//        // PlayerPrefs.SetInt("levelReached", levelToUnlock);
//        Time.timeScale = 1f;
//        nextLevel = LevelHolder.instance.nextLevel;
//        Debug.Log("Next Level:" + nextLevel);
//        GameManager.instance.level = 0;
//        GameManager.instance.isGameOver = false;
//        GameManager.instance.isWin = false;
//        sceneFader.FadeTo(nextLevel);
//        // Cursor.lockState = CursorLockMode.Locked;
//        // Cursor.visible = false;

//    }

//    public void Menu()
//    {
//        sceneFader.FadeTo(menuSceneName);
//    }
//}
