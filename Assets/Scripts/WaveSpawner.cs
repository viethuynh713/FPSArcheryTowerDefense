using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Waves[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 5f;

    public Text waveCountdownText;
    private int waveIndex = 0;

    void Start()
    {
        EnemiesAlive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver)
            return;

        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        { 
            GameManager.instance.WinLevel();
            this.enabled = false;
        }

        if ( countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }


        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        
        waveCountdownText.text = (waveIndex + 1).ToString() + " / " + waves.Length.ToString();
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Waves wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0;i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds( 1f / wave.rate);
        }
        
        waveIndex++;

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

}
