using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthController
{
    
    new void Start()
    {
        base.Start();
    }

    void Update()
    {
        
    }
    
    public override void ApplyDeath()
    {
        throw new System.NotImplementedException();
    }
}
