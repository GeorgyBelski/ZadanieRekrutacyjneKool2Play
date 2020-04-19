using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public float speed = 9;
    public float reactionTime = 0.2f;
    float timerReactionTime; 
    void Start()
    {
        
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
            transform.LookAt(PlayerHealth.player.transform.position);
        }
        transform.position += transform.rotation * Vector3.forward * speed * Time.deltaTime;
    }
}
