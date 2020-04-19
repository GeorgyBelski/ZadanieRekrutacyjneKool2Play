using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthController
{
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
        throw new System.NotImplementedException();
    }
}
