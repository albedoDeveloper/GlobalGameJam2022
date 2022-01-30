using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class EnemySpawner : NetworkBehaviour
{

    public GameObject enemyPrefab;

    public List<EnemyBehaviour> enemies = new List<EnemyBehaviour>();
    public float maxEnemies;

    public float spawnInterval;
    public float countDownTimer;

    // Start is called before the first frame update
    void Start()
    {
        countDownTimer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void Timer()
    {
        if (countDownTimer > 0)
        {
            countDownTimer -= Time.deltaTime;
        }
        else
        {
            SpawnWave();
            countDownTimer = spawnInterval;
        }
    }

    [Command(requiresAuthority = false)]
    void SpawnWave()
    {
        Debug.Log("SPawn all enemies");

        if (enemies.Count < maxEnemies)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            AddToList(newEnemy.GetComponent<EnemyBehaviour>());
            NetworkServer.Spawn(newEnemy);
        }

    }

    void AddToList(EnemyBehaviour enemy)
    {
        enemies.Add(enemy);
        enemy.parentSpawner = this;
    }

    public void RemoveFromList(EnemyBehaviour enemy)
    {
        enemies.Remove(enemy);
    }
}
