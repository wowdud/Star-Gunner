using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject rocketPowerup;
    public GameObject wideshotPowerup;

    public Transform left;
    public Transform right;

    public float delay;
    public float powerupSpawnDelay;

    public static float timer = 0;
    public static float enemySpeed;

    public int spawnRockets = 0;
    public int spawnWideshot = 0;

    void Start()
    {
        spawnRockets = PlayerPrefs.GetInt("areRocketsBought");
        spawnWideshot = PlayerPrefs.GetInt("isWideshotBought");
        timer = 0;
        delay = Random.Range(0.3f, 0.75f);
        powerupSpawnDelay = Random.Range(15, 60);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(delay <= 0)
        {
            SpawnEnemy();
        }
        else
        {
            delay -= Time.deltaTime;
        }

        if (powerupSpawnDelay <= 0)
        {
            SpawnPowerup();
        }
        else
        {
            powerupSpawnDelay -= Time.deltaTime;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = Vector3.Lerp(left.position, right.position, Random.Range(0f, 1f));
        Instantiate(enemy, spawnPos, Quaternion.identity);
        if (timer <= 30)
        {
            delay = Random.Range(0.5f, 0.3f);
            enemySpeed = Random.Range(-3.5f , -2.5f);
        }
        else if (timer >= 30 && timer < 60)
        {
            delay = Random.Range(0.05f, 0.2f);
            enemySpeed = Random.Range(-5.5f, -4.5f);
        }
        else if (timer >= 60 && timer < 90)
        {
            delay = Random.Range(0.01f, 0.1f);
            enemySpeed = Random.Range(-6.5f, -4f);
        }
        else if (timer >= 90)
        {
            delay = Random.Range(0.01f, 0.05f);
            enemySpeed = Random.Range(-7f, -6.7f);
        }
    }
    public void SpawnPowerup()
    {
        Vector3 spawnPos = Vector3.Lerp(left.position, right.position, Random.Range(0f, 1f));
        int powerupToSpawn = Random.Range(0,2);
        if (spawnRockets == 1 && powerupToSpawn == 0)
        {
            Instantiate(rocketPowerup, spawnPos, Quaternion.identity);
            powerupSpawnDelay = Random.Range(15, 60);
        }
        if (spawnWideshot == 1 && powerupToSpawn == 1)
        {
            Instantiate(wideshotPowerup, spawnPos, Quaternion.identity);
            powerupSpawnDelay = Random.Range(20, 50);
        }
    }
}
