using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    [Header("Ice Arrows")]
    public int IceQuantity = 0;
    public TMP_Text IceQuantityText;
    public float IceRateSlow = 5f;
    public TMP_Text IceRateSlowText;
    public float IceTimeSlowDuration = 1;
    public TMP_Text IceTimeSlowDurationText;

    [Header("Fire Arrows")]
    public int FireQuantity = 0;
    public TMP_Text FireQuantityText;
    public float FireTimeBurnDuration = 1;
    public TMP_Text FireTimeBurnDurationText;
    public float FireDamBurn = 5f;
    public TMP_Text FireDamBurnText;
    public SceneFader sceneFader;
    private BowScript bs;
    private Look look;


    private void Awake() 
    {
        healthBarOfCastle.maxValue = 1000f;
        healthBarOfCastle.minValue = 0;
        healthBarOfCastle.value = castleHealth;

        // Ice Arrows
        IceQuantityText.text = IceQuantity.ToString();
        IceRateSlowText.text = IceRateSlow.ToString() + "%";
        IceTimeSlowDurationText.text = IceTimeSlowDuration.ToString() + "s";
        // Fire Arrows
        FireQuantityText.text = FireQuantity.ToString();
        FireTimeBurnDurationText.text = FireTimeBurnDuration.ToString() + "s";
        FireDamBurnText.text = FireDamBurn.ToString();
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
    public void BuyIceArrow()
    {
        if (money >= 50)
        {
            money -= 50;
            IceQuantity++;
            IceQuantityText.text = IceQuantity.ToString();
        }
    }
    public void DecsIceArrow()
    {
            IceQuantity--;
            IceQuantityText.text = IceQuantity.ToString();
    }
    public void DecsFireArrow()
    {
        FireQuantity--;
        FireQuantityText.text = FireQuantity.ToString();
    }
    public void BuyFireArrow()
    {
        if (money >= 50)
        {
            money -= 100;
            FireQuantity++;
            FireQuantityText.text = FireQuantity.ToString();
        }
    }
    public void IncreaseIceRateSlow()
    {
        if (money >= 100 && IceRateSlow < 100)
        {
            money -= 100;
            IceRateSlow += 1;
            IceRateSlowText.text = IceRateSlow.ToString() + "%";
        }

    }
    public void IncreaseIceTimeSlowDuration()
    {
        if (money >= 100)
        {
            money -= 100;
            IceTimeSlowDuration += 1;
            IceTimeSlowDurationText.text = IceTimeSlowDuration.ToString() + "s";
        }
    }
    public void IncreaseFireTimeBurnDuration()
    {
        if (money >= 100)
        {
            money -= 100;
            FireTimeBurnDuration += 1;
            FireTimeBurnDurationText.text = FireTimeBurnDuration.ToString() + "s";
        }
    }
    public void IncreaseFireDamBurn()
    {
        if (money >= 100)
        {
            money -= 100;
            FireDamBurn += 5;
            FireDamBurnText.text = FireDamBurn.ToString();
        }
    }

}
