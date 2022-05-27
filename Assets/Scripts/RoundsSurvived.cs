using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RoundsSurvived : MonoBehaviour
{
    [SerializeField]
    public Text roundsText;

    void OnEnable()
    {
        StartCoroutine(AnimatedText());
    }

    IEnumerator AnimatedText()
    {
        roundsText.text = "0";
        int round = 0;
        

        yield return new WaitForSeconds(0.7f);

        while(round < GameManager.instance.level)
        {
            round++;
            // Debug.Log(round);
            roundsText.text = GameManager.instance.level.ToString();

            yield return new WaitForSeconds(0.05f);
        }
    }
}

