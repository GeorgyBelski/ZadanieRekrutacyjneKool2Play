using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static List<EnemyHealth> enemiesInReserve = new List<EnemyHealth>();
    public static List<EnemyHealth> enemiesOnScene = new List<EnemyHealth>();

    public float spawnRadius = 9;
    public float spawnCooldown = 3;
    float timerSpewnCooldown = 0;

    public GameObject enemyPrefab;

    Quaternion directionFromPlayer;
    Vector3 vectorFromPlayer;
    bool isGameOver = false;
    

    void Start()
    {
        PlayerHealth.playerDeathEvent += GameOver;
        UIController.restartLevel += Restart;
    }

    void Update()
    {
        Spawn();
    }
    void Spawn()
    {
        if(isGameOver == true) { return; }

        if(timerSpewnCooldown > 0)
        {
            timerSpewnCooldown -= Time.deltaTime;
            return;
        }

        timerSpewnCooldown = spawnCooldown;
        CreateEnemy(ChoosePosition());

    }
    Vector3 ChoosePosition()
    {
        Vector3 playerpositoin = PlayerHealth.player.transform.position;
        directionFromPlayer = Quaternion.Euler(0, Random.Range(0, 360), 0);
        vectorFromPlayer = directionFromPlayer * Vector3.forward;
        Vector3 spawnPosition = playerpositoin + vectorFromPlayer * spawnRadius;

        for(int i =0; i< 3; i++)
        {
            
            if (CheckGround(spawnPosition))
            {
                break;
            }
            vectorFromPlayer = Quaternion.Euler(0, 90, 0) * vectorFromPlayer;
            spawnPosition = playerpositoin + vectorFromPlayer * spawnRadius;
        }

        return spawnPosition;
    }

    bool CheckGround(Vector3 position)
    {
        if(Physics.Raycast(position + Vector3.up, Vector3.down, 1.1f, Globals.groundMask))
        {
            return true;
        }
        else {
            return false; 
        }
    }
    void CreateEnemy(Vector3 position)
    {
        if(enemiesInReserve.Count > 0)
        {
            EnemyHealth enemy = enemiesInReserve[0];
            enemy.Spawn(position);
            enemiesInReserve.Remove(enemy);
            enemiesOnScene.Add(enemy);
        }
        else
        {
            Instantiate(enemyPrefab, position, directionFromPlayer);
        } 
    }

    void GameOver()
    {
        isGameOver = true;
    }

    void Restart()
    {
        isGameOver = false;
        enemiesInReserve.ForEach(enemy => Destroy(enemy.gameObject));
        enemiesInReserve.Clear();
        enemiesOnScene.ForEach(enemy => Destroy(enemy.gameObject));
        enemiesOnScene.Clear();
    }
}
