using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Missile
{
    public float speed = 20;


    public TrailRenderer trail;
    void Start()
    {
        if (!trail) { trail = GetComponent<TrailRenderer>(); }
    }

    void FixedUpdate()
    {
        Move();
    }
    public override void ReleaseMissile(Transform gun)
    {
        
        trail.emitting = true;
        if (trail.positionCount > 0)
        { trail.SetPosition(trail.positionCount - 1, gun.position); }
        
        base.ReleaseMissile(gun);
    }

    
    void Move()
    {
        float deltaDistance = speed * Time.deltaTime;
        transform.position += direction * deltaDistance;
        CheckHit(direction, deltaDistance, Globals.enemyMask);
        previousPosition = transform.position;

    }
    
    public override void DisableMissile()
    {
        trail.emitting = false;
        Gun.DisableBullet(this);
    }

    public override void ApplyHitEffect(GameObject hittedObject)
    {
        EnemyHealth.objectEnemyHealthMap.TryGetValue(hittedObject, out EnemyHealth enemyhealth);
        if (enemyhealth)
        {
            enemyhealth.ApplyDamage(damage);
        }
    }
}
