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
    }

    void Update()
    {
        
    }
    
    public override void ApplyDeath()
    {
        Debug.Log("Player Death");
        playerDeathEvent.Invoke();
        gameObject.SetActive(false);
    }
}
