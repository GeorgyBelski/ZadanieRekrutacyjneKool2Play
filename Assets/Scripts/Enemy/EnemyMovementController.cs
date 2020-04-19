using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public float speed = 9;
    public float reactionTime = 0.2f;
    public Transform enemy;
    public float distanceToPlayer;
    float timerReactionTime;
    Transform player;
    void Start()
    {
        if (!enemy) { enemy = transform.Find("Enemy"); }
        if (PlayerHealth.player)
        { player = PlayerHealth.player.transform; }

        PlayerHealth.playerDeathEvent += GameOver;
    }

    void FixedUpdate()
    {
        ReduceTimer();
        Move();
    }

    void ReduceTimer()
    {
        if(timerReactionTime > 0)
        {
            timerReactionTime -= Time.deltaTime;
        }
    }
    void Move()
    {
        if (!player) { return; }

        if(timerReactionTime <= 0)
        {
            timerReactionTime = reactionTime;
            enemy.transform.LookAt(player.position);
        }
        distanceToPlayer = (transform.position - player.position).magnitude;

        if (distanceToPlayer > 2.1f)
        { 

            transform.position += enemy.transform.rotation * Vector3.forward * speed * Time.deltaTime; 
        }
    }

    void GameOver()
    {
        player = null;
        enemy.transform.LookAt(transform.position + new Vector3(Random.Range(-1,1), 0, Random.Range(-1, 1)));
    }
}
