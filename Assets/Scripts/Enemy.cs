using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum collisionType { head, body };
public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    public float speed;

    public float slowTime = 3;
    public float currentSlowTime;
    public float slowPercent;

    private Transform target;
    private int wavepointIndex = 0;

    public Image healthBar;

    public float startHealth = 100f;
    private float health;

    public int dropMoney = 50;

    public GameObject deathEffect;

    private bool isDead = false;

    private bool isSlowed = false;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    void Update()
    {
        if (isSlowed)
        {
            speed = speed * (100 - slowPercent) / 100;
            currentSlowTime -= Time.deltaTime;

        }

        if (currentSlowTime == 0)
        {
            speed = startSpeed;

            isSlowed = false;
        }
    }

    public void TakeDamage(float damage, bool isHead)
    {
        Debug.Log("TakeDam");
        Debug.Log(damage);
        if (isHead)
        {
            // float newDamage = damage * 1.5f;
            // health -= newDamage;
            health = 0;
            healthBar.fillAmount = health / startHealth;
        }
        else
        {
            health -= damage;

            healthBar.fillAmount = health / startHealth;

        }
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    // public void TakeDamageHead(float damage)
    // {
    //     float headDmg = (float)(damage * 1.5);

    //     health -= headDmg;

    //     healthBar.fillAmount = health / startHealth;

    //     if (health <= 0 && !isDead)
    //     {
    //         Die();
    //     }
    // }

    public void Slowdown()
    {
        currentSlowTime = slowTime;
        isSlowed = true;
    }

    void Die()
    {
        isDead = true;

        PlayerStats.Money += dropMoney;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(effect, 2f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

}
