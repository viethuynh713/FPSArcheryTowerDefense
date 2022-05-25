using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth = 1000f;

    void Start()
    {
        healthBar.maxValue = maxHealth;
        healthBar.minValue = 0;
        healthBar.value = GameManager.instance.castleHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy hit");
            GameManager.instance.castleHealth -= other.gameObject.GetComponent<Enemy>().hitDamage;

            healthBar.value = GameManager.instance.castleHealth;
            if (GameManager.instance.castleHealth <= 0)
            {
                GameManager.instance.EndGame();
            }
        }
    }
}
