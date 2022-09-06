using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RankingRow : MonoBehaviour
{
    public TextMeshProUGUI ranknoText;
    public TextMeshProUGUI roundPassText;
    public TextMeshProUGUI usernameText;

    public void UpdateRow(int rank, string username, int roundpass)
    {
        ranknoText.text = (rank+1).ToString();
        roundPassText.text = roundpass.ToString();
        usernameText.text = string.IsNullOrEmpty(username) ? "No Name" : username;
    }
}
