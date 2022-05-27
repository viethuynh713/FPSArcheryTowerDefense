using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandleUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider healthBarOfCastle;
    [Header("Ice Arrows")]
    public TMP_Text IceQuantityText;

    public TMP_Text IceRateSlowText;
    public TMP_Text IceTimeSlowDurationText;
    [Header("Fire Arrows")]
    public TMP_Text FireQuantityText;
        public TMP_Text FireTimeBurnDurationText;
        public TMP_Text FireDamBurnText;
    void Start()
    {
        healthBarOfCastle.maxValue = 1000f;
        healthBarOfCastle.minValue = 0;
        healthBarOfCastle.value = GameManager.instance.castleHealth;

        // Ice Arrows
        IceQuantityText.text = GameManager.instance.ToString();
        IceRateSlowText.text = GameManager.instance.IceRateSlow.ToString() + "%";
        IceTimeSlowDurationText.text = GameManager.instance.IceTimeSlowDuration.ToString() + "s";
        // Fire Arrows
        FireQuantityText.text = GameManager.instance.FireQuantity.ToString();
        FireTimeBurnDurationText.text = GameManager.instance.FireTimeBurnDuration.ToString() + "s";
        FireDamBurnText.text = GameManager.instance.FireDamBurn.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
