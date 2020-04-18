using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthController
{
    public static Dictionary<GameObject, EnemyHealth> objectEnemyHealthMap = new Dictionary<GameObject, EnemyHealth>();

    new void Start()
    {
        base.Start();
        objectEnemyHealthMap.Add(gameObject, this);
    }

    void Update()
    {
        
    }

    public override void ApplyDeath()
    {
        objectEnemyHealthMap.Remove(gameObject);
        Destroy(gameObject);
    }
}
