using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader sceneFader;

    public Button[] levelButtons;

    int levelReached;

    void Start()
    {
        levelReached = GameManager.instance.maxLevelReach;

        for(int i = 0; i < levelButtons.Length; i++)
        {
            if (i+1 > levelReached)
            {
                levelButtons[i].interactable = false;
                levelButtons[i].GetComponent<Image>().color = Color.grey;
            }
        }
    }

    public void Select(string levelName)
    {
        sceneFader.FadeTo(levelName);
        Time.timeScale = 1f;
    }
}
