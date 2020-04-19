using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthController
{
    public delegate void PlayerDeath();
    public static event PlayerDeath playerDeathEvent;

    public static PlayerHealth player;
    void Awake()
    {
        base.Start();
        player = this;

        UIController.restartLevel += Restart;
    }

    void Update()
    {
        
    }
    
    public override void ApplyDeath()
    {
        playerDeathEvent.Invoke();
        gameObject.SetActive(false);
    }

    void Restart()
    {
        health = maxHealth;
        CalculateRatio();
        gameObject.SetActive(true);
    }
}
