using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public float lifetime = 1;
    float timerLifeTime;
    public TrailRenderer trail;
    void Start()
    {
        if (!trail) { trail = GetComponent<TrailRenderer>(); }
    }

    void FixedUpdate()
    {
        Move();
        ReduseTimer();
    }
    public void ShootABullet()
    {
        timerLifeTime = lifetime;
        trail.emitting = true;
        gameObject.SetActive(true);
    }

    void ReduseTimer()
    {
        timerLifeTime -= Time.deltaTime;
        if(timerLifeTime <= 0)
        {
            DisableBullet();
        }
    }
    void Move()
    {
        transform.position += transform.rotation * Vector3.forward * speed * Time.deltaTime;
    }

    public void DisableBullet()
    {
        trail.emitting = false;
        Gun.DisableBullet(this);
    }
   /* void OnBecameInvisible()
    {
        DisableBullet();
    }
    */


}
