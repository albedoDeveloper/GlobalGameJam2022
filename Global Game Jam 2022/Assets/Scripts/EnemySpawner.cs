using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Animator animator;

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
            if (countDownTimer < 1)
            {
                animator.SetBool("Spawning", true);
            }
        }
        else
        {
            //animator.SetBool("Spawning", true);
            SpawnWave();
            countDownTimer = spawnInterval;
        }
    }

    void SpawnWave()
    {
        Debug.Log("SPawn all enemies");

        if (enemies.Count < maxEnemies)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            AddToList(newEnemy.GetComponent<EnemyBehaviour>());
        }
        animator.SetBool("Spawning", false);
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
