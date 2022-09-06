using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum collisionType { head, body };
public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    public float hitDamage = 10f;
    [SerializeField]
    public float speed;

    private Transform target;
    private int wavepointIndex = 0;

    public Image healthBar;

    public float startHealth = 100f;
    private float health;

    public int dropMoney = 50;

    public GameObject deathEffect;

    private bool isDead = false;

    [Header("Slow Effect")]
    // public float slowTime = 3;
    public float currentSlowTime ;
    // [SerializeField]
    // public float slowPercent;
    private bool isSlowed = false;
    [Header("Fire Effect")]
    [SerializeField]
    private GameObject burnEffect;
    private bool isBurning = false;
    // [SerializeField]
    // private float damBurn = 10;
    [SerializeField]
    // private float burnTime = 3f;
    private float currentBurnTime;

    [Header("Take Dmg Counter")]
    int takeDmgCount = 0;


    void Start()
    {
        speed = startSpeed;
        health = startHealth;
        
    }

    void Update()
    {
        

        if (isSlowed && currentSlowTime > 0)
        {
            currentSlowTime -= Time.deltaTime;

        }
        if (isBurning && currentBurnTime > 0)
        {
            health -= Time.deltaTime * GameManager.instance.FireDamBurn;
            healthBar.fillAmount = health / startHealth;
            currentBurnTime -= Time.deltaTime;
            if (health <= 0 && !isDead)
            {
                Die();
            }

        }

        if (currentSlowTime <= 0)
        {
            speed = startSpeed;

            isSlowed = false;
        }
        if (currentBurnTime <= 0)
        {
            isBurning = false;
        }
    }

    public void TakeDamage(float damage, bool isHead)
    {


        if (isHead)
        {
            health = 0;
            healthBar.fillAmount = health / startHealth;
        }
        else
        {
            health -= damage;

            healthBar.fillAmount = health / startHealth;

            takeDmgCount++;
            Debug.Log(takeDmgCount);
            if(takeDmgCount >= 2)
            {
                gameObject.GetComponent<EnemyMovement>().AttackPlayer();
                Debug.Log("run AtkPlayer!");
            }

        }
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }


    public void Slowdown() { 

        speed = speed * (100 - GameManager.instance.IceRateSlow) / 100;
        currentSlowTime = GameManager.instance.IceTimeSlowDuration;
        // Debug.Log("After change speed: " + speed);
        isSlowed = true;
    }
    public void BurnEffect()
    {

        currentBurnTime = GameManager.instance.FireTimeBurnDuration;
        Quaternion rot = Quaternion.Euler(-90, 0, 0);
        GameObject burn = Instantiate(burnEffect, transform.position, rot, gameObject.transform);
        isBurning = true;
        Destroy(burn, GameManager.instance.FireTimeBurnDuration);

    }

    void Die()
    {
        isDead = true;

        GameManager.instance.money += dropMoney;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(effect, 2f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

}
