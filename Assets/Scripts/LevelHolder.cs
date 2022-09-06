using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHolder : MonoBehaviour
{
    public static LevelHolder instance;

    public string nextLevel;

    private void Awake()
    {
        if (instance != null)
            instance = this;
        //Debug.Log("NextLevel" + nextLevel);

    }

    //public void Start()
    //{
    //    CompletedLevel.instance.nextLevel = nextLevel;
    //}
}
