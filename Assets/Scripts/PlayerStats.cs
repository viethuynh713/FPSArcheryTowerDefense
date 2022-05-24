using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
	public static int Money;
	public int startMoney = 400;

	public static int Lives;
	public int startLives = 1;

	public static int Rounds;

	public Text playerLivesT;

	void Start()
	{
		Money = startMoney;
		Lives = startLives;

		Rounds = 0;
	}

    void Update()
    {
		playerLivesT.text = Lives.ToString();
	}
}
