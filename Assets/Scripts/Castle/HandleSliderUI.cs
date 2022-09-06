using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleSliderUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider healthBarOfCastle;
    public Image healthBarUI;
    void Start()
    {
        healthBarOfCastle.maxValue = 1000f;
        healthBarOfCastle.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        healthBarOfCastle.value = GameManager.instance.castleHealth;
        healthBarUI.fillAmount = GameManager.instance.castleHealth/1000;


    }
}
