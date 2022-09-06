using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerScoreTest : MonoBehaviour
{
    [SerializeField] private int scorePerClick;
    [SerializeField] private TextMeshProUGUI highscoreText;
    [SerializeField] private GameObject gameOverText;
    [HideInInspector]public int highScore;

    public LeaderboardPlayFab leaderboardPlayFab;

    void Update()
    {
        IncreaseScore();
        GameOver();
    }

    public void IncreaseScore()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            highScore += scorePerClick;
            highscoreText.text = "Highscore: " + highScore.ToString();
        }
    }

    public void GameOver()
    {
        if (Input.GetKeyDown(KeyCode.K)){
            Debug.Log("GameOver");

            if(gameOverText!= null)
                gameOverText.SetActive(true);

            leaderboardPlayFab.SendHighScore(highScore);
        }
    }
}
