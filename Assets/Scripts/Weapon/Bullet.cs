using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public float lifetime = 1;
    public int damage = 10;
    float timerLifeTime;
    public TrailRenderer trail;
    Vector3 previousPosition;
    void Start()
    {
        if (!trail) { trail = GetComponent<TrailRenderer>(); }
    }

    void FixedUpdate()
    {
        Move();
        ReduseTimer();
    }
    public void ShootABullet(Transform gun)
    {
        timerLifeTime = lifetime;
        trail.emitting = true;
        //Vector3 trailPosition = trail.GetPosition(trail.positionCount -1);
        if (trail.positionCount > 0)
        { trail.SetPosition(trail.positionCount - 1, gun.position); }
        gameObject.SetActive(true);
        transform.rotation = gun.rotation;
        transform.position = gun.position;
        previousPosition = transform.position;
        //rigidbody.velocity = transform.rotation * Vector3.forward * speed;
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
        float distance = speed * Time.deltaTime;
        Vector3 direction = transform.rotation * Vector3.forward;
        transform.position += direction * distance;
        CheckHit(direction, distance);
        previousPosition = transform.position;

    }
    void CheckHit(Vector3 direction, float distance)
    {
        if (Physics.Raycast(previousPosition, direction, out RaycastHit hit, distance, Globals.enemyMask))
        {
            /*
            Debug.DrawLine(previousPosition, transform.position, Color.red);
            Debug.DrawLine(transform.position, hit.collider.gameObject.transform.position, Color.green);
            */
            EnemyHealth.objectEnemyHealthMap.TryGetValue(hit.collider.gameObject, out EnemyHealth enemyhealth);
            if (enemyhealth)
            {
                enemyhealth.ApplyDamage(damage);
            }

            DisableBullet();
        }
        else
        {
            Debug.DrawLine(previousPosition, transform.position, Color.yellow);
        }
    }
    public void DisableBullet()
    {
        trail.emitting = false;
        Gun.DisableBullet(this);
    }



}
