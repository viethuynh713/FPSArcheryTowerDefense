using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver;
    public bool isWin;
    public int level = 0;
    public int money = 0;
    public float castleHealth = 1000f;

    [Header("UI Objects")]
    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    public Slider healthBarOfCastle;

    public SceneFader sceneFader;
    private BowScript bs;
    private Look look;


    private void Awake() 
    {
        healthBarOfCastle.maxValue = 1000f;
        healthBarOfCastle.minValue = 0;
        healthBarOfCastle.value = castleHealth;

        isGameOver = false;
        isWin = false;
        bs = FindObjectOfType<BowScript>();
        look = FindObjectOfType<Look>();
        if (instance == null)
        {
            instance = this;
        }
        
    }

    public void Update()
    {
        if (isWin)
        {
            return;
        }

        if (castleHealth <= 0)
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
    public void CastleTakeDamage(float damage)
    {
        castleHealth -= damage;
        healthBarOfCastle.value = castleHealth;
        if (castleHealth <= 0)
        {
            EndGame();
        }
    }
}
