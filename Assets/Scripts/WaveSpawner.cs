using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner instance;

    public static int EnemiesAlive = 0;
    public Waves[] waves;

    public Transform[] spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 5f;

    public Text waveCountdownText;
    private int waveIndex = 0;

    public string nextLevel;

    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
        }
    }

    void Start()
    {

        EnemiesAlive = 0;
        oldPosIndex = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameManager.instance.nextLevel = nextLevel;
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
            enabled = false;
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
        EnemiesAlive = waves[waveIndex].enemyPerWave;
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
        if(spawnPoint.Length != 1)
        {
            do
            {
                index = Random.Range(0, spawnPoint.Length);
            }
            while (index == oldPosIndex);
        }
        else
        {
            index = 0;
        }
        
        oldPosIndex = index;
        Instantiate(enemy, spawnPoint[index].position, spawnPoint[index].rotation);
    }

}
