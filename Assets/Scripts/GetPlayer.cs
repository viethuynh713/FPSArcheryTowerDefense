using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayer : MonoBehaviour
{
    public static GetPlayer instance;

    private void Awake()
    {
        if(instance != null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        GameManager.instance.playerGO = this.gameObject;
    }
}
