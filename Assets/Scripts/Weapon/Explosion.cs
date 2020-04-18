using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Missile
{
    public float diameter = 5;
    void Start()
    {
        
    }
    public override void ReleaseMissile(Transform grenade)
    {
        base.ReleaseMissile(grenade);
        StartCoroutine( Scale());
    }

    IEnumerator Scale()
    {
        for (float timer = 0f; timer < lifetime; timer += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * diameter, timer / lifetime);
            yield return null;
        }
        //Debug.Log("Ready");
        transform.localScale = Vector3.one * 0.2f;
        DisableMissile();
    }
    public override void DisableMissile()
    {
        GrenadeMissile.DisableExplosion(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hittedObject = collision.gameObject;
        if (hittedObject.layer == Globals.enemyLayer)
        {
            EnemyHealth.objectEnemyHealthMap.TryGetValue(collision.gameObject, out EnemyHealth enemy);
            if (enemy) 
            { enemy.ApplyDamage(damage);}    
        }
        else if(hittedObject.layer == Globals.playerLayer)
        {
            Debug.Log("hit Player " + Globals.playerLayer);
            PlayerHealth.player.ApplyDamage(damage);
        }
    }

}
