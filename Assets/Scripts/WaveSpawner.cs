using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public GameObject[] enemyPrefab;
    public int[] quantityOfEnemy;

    public Transform[] spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 5f;

    public Text waveCountdownText;
    private int waveIndex = 0;

    void Start()
    {

        EnemiesAlive = 0;
        oldPosIndex = 0;
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

        if (waveIndex == quantityOfEnemy.Length)
        {
            GameManager.instance.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }


        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = (waveIndex + 1).ToString() + " / " + quantityOfEnemy.Length.ToString();
    }

    IEnumerator SpawnWave()
    {
        // GameManager.instance.level++;

        EnemiesAlive = quantityOfEnemy[waveIndex];

        for (int i = 0; i < EnemiesAlive; i++)
        {
            float random = Random.Range(0f, 10f);

            SpawnEnemy(enemyPrefab[random > 7 ? 0 : 1]);
            yield return new WaitForSeconds(1f);
        }

        waveIndex++;

    }
    private int oldPosIndex;
    void SpawnEnemy(GameObject enemy)
    {
        int index;
        do
        {
            index = Random.Range(0, spawnPoint.Length);
        }
        while(index == oldPosIndex);
        oldPosIndex = index;
        Instantiate(enemy, spawnPoint[index].position, spawnPoint[index].rotation);
    }

}
