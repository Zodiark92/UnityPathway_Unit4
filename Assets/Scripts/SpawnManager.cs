using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    private int enemyCount;
    private int spawnWave = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(spawnWave);
        Instantiate(powerupPrefab, GenerateRandomPos(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            spawnWave++;
            SpawnEnemyWave(spawnWave);
            Instantiate(powerupPrefab, GenerateRandomPos(), powerupPrefab.transform.rotation);
        }
    }

    private void SpawnEnemyWave(int enemyToSpawn)
    {
        for(int i=0; i < enemyToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPos(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateRandomPos()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(spawnX, 0, spawnZ);

        return spawnPos;
    }
}
