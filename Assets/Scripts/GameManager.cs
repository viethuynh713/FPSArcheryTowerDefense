using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool isGameOver;
    public bool isWin;

    [Header("UI Objects")]
    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    public SceneFader sceneFader;
    private BowScript bs;
    private Look look;


    void Start()
    {
        isGameOver = false;
        isWin = false;
        bs = FindObjectOfType<BowScript>();
        look = FindObjectOfType<Look>();
        
    }

    public void Update()
    {
        if (isWin)
        {
            return;
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

        

        
    }

    public void EndGame()
    {
        isGameOver = true;

        isWin = isGameOver;

        Time.timeScale = 1f;

        gameOverUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;

        bs.isTimeStopped = isGameOver;

        look.isTimeStopped = isGameOver;
    }

    public void WinLevel()
    {
        isGameOver = true;

        isWin = isGameOver;

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;

        completeLevelUI.SetActive(true);

        bs.isTimeStopped = isGameOver;

        look.isTimeStopped = isGameOver;
        
    }
}
