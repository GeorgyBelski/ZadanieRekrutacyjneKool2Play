using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthController
{
    public static Dictionary<GameObject, EnemyHealth> objectEnemyHealthMap = new Dictionary<GameObject, EnemyHealth>();

    public EnemyAttackController attackController;

    new void Start()
    {
        base.Start();
        objectEnemyHealthMap.Add(gameObject, this);
        EnemyManager.enemiesOnScene.Add(this);
        if (!attackController)
        {
            attackController = GetComponent<EnemyAttackController>();
        }
    }

    void Update()
    {
        
    }
    public void Spawn(Vector3 position)
    {
        health = maxHealth;
        CalculateRatio();
        transform.position = position;
        attackController.RestartState();
        gameObject.SetActive(true);
    }
    public override void ApplyDeath()
    {
        //objectEnemyHealthMap.Remove(gameObject);
        UIController.AddKilledEnemy();
        // Destroy(gameObject);
        EnemyManager.enemiesOnScene.Remove(this);
        EnemyManager.enemiesInReserve.Add(this);
        gameObject.SetActive(false);

    }
}
