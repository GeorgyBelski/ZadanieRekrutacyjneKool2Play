using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public float speed = 9;
    public float reactionTime = 0.2f;
    public Transform enemy;
    float timerReactionTime;
    Transform player;
    void Start()
    {
        if (!enemy) { enemy = transform.Find("Enemy"); }
        player = PlayerHealth.player.transform;
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
        if(timerReactionTime <= 0)
        {
            timerReactionTime = reactionTime;
            enemy.transform.LookAt(player.position);
        }
        float distanceToPlayer = (transform.position - player.position).magnitude;

        if (distanceToPlayer > 2.1f)
        { 

            transform.position += enemy.transform.rotation * Vector3.forward * speed * Time.deltaTime; 
        }
    }
}
