using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;
using System;

public class LeaderboardPlayFab : MonoBehaviour
{
    public static LeaderboardPlayFab instance;

    public GameObject viewArea;
    public GameObject rowPrefab;
    public TextMeshProUGUI header;
    public TextMeshProUGUI myRank;

    private void Awake()
    {
        if(instance != this)
        {
            instance = this;
        }
    }

    private void Start()
    {
        GetLeaderboard();
        GetMyRank();
    }

    public void SendHighScore(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate
                {
                    StatisticName = "HighestRound",
                    Value = score
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnHighScoreUpdate, OnError);

    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error!");
        Debug.Log(error.GenerateErrorReport());
    }

    void OnHighScoreUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Send Highscore Successful!");
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "HighestRound",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    public void GetMyRank()
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "HighestRound",
            
            MaxResultsCount = 1,
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnSuccess, OnError);
    }

    private void OnSuccess(GetLeaderboardAroundPlayerResult result)
    {
        foreach (var myStat in result.Leaderboard)
            myRank.text = "My Rank: " + (myStat.Position + 1) + " | " + "Max Score: " + myStat.StatValue;

    }

    public void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (Transform item in viewArea.transform)
        {
            GameObject.Destroy(item.gameObject);
        }

        header.text = "RANKING";

        foreach(var card in result.Leaderboard)
        {
            GameObject rankingCard = Instantiate(rowPrefab, viewArea.transform.position, Quaternion.identity, viewArea.transform);
            RankingRow thisRankingRow = rankingCard.GetComponent<RankingRow>();
            thisRankingRow.UpdateRow(card.Position, card.DisplayName, card.StatValue);
        }
    }
}
