using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Missile : MonoBehaviour
{
    public int damage = 10;
    public float lifetime = 1;
    protected float timerLifeTime;
    protected Vector3 previousPosition;
    protected Vector3 direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        ReduseTimer();
    }
    void ReduseTimer()
    {
        timerLifeTime -= Time.deltaTime;
        if (timerLifeTime <= 0)
        {
            DisableMissile();
        }
    }
    public virtual void ReleaseMissile(Transform gun)
    {
        timerLifeTime = lifetime;
        gameObject.SetActive(true);
        transform.rotation = gun.rotation;
        transform.position = gun.position;
        previousPosition = transform.position;
        direction = transform.rotation * Vector3.forward;
    }
    protected virtual void CheckHit(Vector3 direction, float distance, int layerMask)
    {
        if (Physics.Raycast(previousPosition, direction, out RaycastHit hit, distance, layerMask))
        {
            /*
            Debug.DrawLine(previousPosition, transform.position, Color.red);
            Debug.DrawLine(transform.position, hit.collider.gameObject.transform.position, Color.green);
            */
            ApplyHitEffect(hit.collider.gameObject);
            /*
            EnemyHealth.objectEnemyHealthMap.TryGetValue(hit.collider.gameObject, out EnemyHealth enemyhealth);
            if (enemyhealth)
            {
                enemyhealth.ApplyDamage(damage);
            }
            */
            DisableMissile();
        }
        else
        {
            Debug.DrawLine(previousPosition, transform.position, Color.yellow);
        }
    }
    public virtual void ApplyHitEffect(GameObject hittedObject) { }
    public abstract void DisableMissile();
}
