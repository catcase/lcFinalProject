using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //public GameManager gameManager;

    public GameObject enemies;

    public int enemyCount;
    public int waveNumber = 1;

    private float xSpawnRange = 13.0f;
    private float ySpawnPoint = 5.0f;

    //public GameObject[] meteors;
    //private Rigidbody2D meteorRb;
    //private float meteorSpeed = 3;
    //private float meteorDelay = 1;
    //private float meteorSpawnTime = 3;

    //public GameObject shield;
    //private float shieldSpawnTime = 3;
    //private float startDelay = 1;
    //private float yShield = 4;


    // Start is called before the first frame update
    void Start()
    {

        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        SpawnEnemy();
        SpawnEnemyWave(waveNumber);
        //InvokeRepeating("SpawnShield", startDelay, shieldSpawnTime);
        //InvokeRepeating("SpawnMeteor", meteorDelay, meteorSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemies, SpawnEnemy(), enemies.gameObject.transform.rotation);
        }
    }

    private Vector3 SpawnEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawnPoint);

        return spawnPos;

    }

    //private Vector3 SpawnMeteor()
    //{

    //    float randomX = Random.Range(-xSpawnRange, xSpawnRange);

    //    Vector3 spawnPos = new Vector3(randomX, ySpawnPoint);

    //    return spawnPos;
    //}


    //void SpawnShield()
    //{
    //    float randomX = Random.Range(-xSpawnRange, xSpawnRange);

    //    float randomY = Random.Range(-yShield, yShield);

    //    Vector3 spawnPos = new Vector3(randomX, randomY);

    //    Instantiate(shield, spawnPos, shield.gameObject.transform.rotation);
    //}
}