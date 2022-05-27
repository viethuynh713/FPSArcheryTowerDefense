using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    // public GameObject[] enemyPrefab;
    // public int[] quantityOfEnemy;
    public Waves[] waves;

    public Transform[] spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 5f;

    public Text waveCountdownText;
    private int waveIndex = 0;

    void Start()
    {

        EnemiesAlive = 0;
        oldPosIndex = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }


        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        if (waveIndex == waves.Length)
        {
            waveCountdownText.text = waveIndex.ToString() + " / " + waves.Length.ToString();
        }
        else
            waveCountdownText.text = (waveIndex + 1).ToString() + " / " + waves.Length.ToString();
    }

    IEnumerator SpawnWave()
    {

        EnemiesAlive = waves[waveIndex].waveOfLevel;
        for (int i = 0; i < waves[waveIndex].spawnEnemy.Length; i++)
        {
            for (int j = 0; j < waves[waveIndex].spawnEnemy[i].quantityOfEnemy; j++)
            {
                SpawnEnemy(waves[waveIndex].spawnEnemy[i].enemy);
                yield return new WaitForSeconds(1f);
            }

        }
        if (waveIndex < waves.Length)
            waveIndex++;

        if (GameManager.instance.level < waveIndex)
        {
            GameManager.instance.level++;
        }



    }
    private int oldPosIndex;
    void SpawnEnemy(GameObject enemy)
    {
        int index;
        do
        {
            index = Random.Range(0, spawnPoint.Length);
        }
        while (index == oldPosIndex);
        oldPosIndex = index;
        Instantiate(enemy, spawnPoint[index].position, spawnPoint[index].rotation);
    }

}
