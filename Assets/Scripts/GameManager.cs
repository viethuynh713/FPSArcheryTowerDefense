using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Game/Shop Manager

    public static GameManager instance;
    public bool isGameOver;
    public bool isWin;
    public int level;
    public int maxLevelReach;
    public int money = 0;
    public float castleHealth = 1000f;

    [SerializeField] float playerHealth;
    public GameObject playerGO;
    [SerializeField] float respawnTime;

    // [Header("UI Objects")]
    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    // public Slider healthBarOfCastle;

    [Header("Ice Arrows")]
    public int IceQuantity = 5;
    public TMP_Text IceQuantityText;
    public float IceRateSlow = 5f;
    public TMP_Text IceRateSlowText;
    public float IceTimeSlowDuration = 1;
    public TMP_Text IceTimeSlowDurationText;

    [Header("Fire Arrows")]
    public int FireQuantity = 5;
    public TMP_Text FireQuantityText;
    public float FireTimeBurnDuration = 1;
    public TMP_Text FireTimeBurnDurationText;
    public float FireDamBurn = 5f;
    public TMP_Text FireDamBurnText;

    public Camera mainCamera;

    private void Awake() 
    {
        level = 1;
        // healthBarOfCastle.maxValue = 1000f;
        // healthBarOfCastle.minValue = 0;
        // healthBarOfCastle.value = castleHealth;

        ShopUIRefresh();

        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(instance);
        
    }

    public void ShopUIRefresh()
    {
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

        if(playerHealth <= 0)
        {
            PlayerDie();
        }
    }

    public void PlayerTakeDamage(float damage)
    {
        playerHealth -= damage;
        // healthBarOfCastle.value = castleHealth;
        if (playerHealth <= 0)
        {
            PlayerDie();
        }
    }

    public void PlayerDie()
    {
        playerGO.SetActive(false);
        
        StartCoroutine(RespawnPlayer());
        
    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(respawnTime);
        mainCamera.gameObject.SetActive(false);
        playerGO.SetActive(true);
    }

    public void EndGame()
    {
        isGameOver = true;

        isWin = isGameOver;

        Time.timeScale = 1f;

        gameOverUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;

    }

    public void RestoreCastleHP()
    {
        castleHealth = 1000f;
    }
    
    public void RestorePlayerHP()
    {
        playerHealth = 1000f;
    }

    public void WinLevel()
    {
        isGameOver = true;

        isWin = isGameOver;

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;

        //if (nextLevel == null)
        //    nextLevel = LevelHolder.instance.nextLevel;
        //else
        //    nextLevel = LevelHolder.instance.nextLevel;

        completeLevelUI.SetActive(true); 
    }

    public void CastleTakeDamage(float damage)
    {
        castleHealth -= damage;
        // healthBarOfCastle.value = castleHealth;
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
            money -= 50;
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

    #endregion

    #region Complete Level

    [Header("CompleteLevel")]
    
    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    public string nextLevel;

    public void Continue()
    {
        
        Time.timeScale = 1f;
        level = 0;
        isGameOver = false;
        isWin = false;
        sceneFader.FadeTo(nextLevel);
        LoginPagePlayFab.instance.SendPlayerData();
    }

    

    public void Menu()
    {
        level = 0;
        isGameOver = false;
        isWin = false;
        completeLevelUI.SetActive(false);
        sceneFader.FadeTo(menuSceneName);
    }

    #endregion

    #region Game Over

    [Header("GameOver")]

    public Text roundText;

    public GameObject GOUI;

    public void Retry()
    {
        GOUI.SetActive(false);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;

        sceneFader.FadeTo(SceneManager.GetActiveScene().name);


        castleHealth = 1000f;

        isGameOver = false;

    }

    #endregion

}
