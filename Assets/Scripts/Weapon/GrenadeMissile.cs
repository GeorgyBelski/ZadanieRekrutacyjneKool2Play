using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeMissile : Missile
{
    public static List<Missile> explosionsInReserve = new List<Missile>();
    public static List<Missile> explosionsInAir = new List<Missile>();

    public Missile explosion;
    public new Rigidbody rigidbody;

    Vector3 targe;
    float speedForvard, speedUp;
    float distance;
    
    void Start()
    {
        
    }
    void LateUpdate()
    {
        Move();
    }
    void Move()
    {
      //  transform.position += direction * speedForvard * Time.deltaTime;

        previousPosition = transform.position;
    }

    public override void ReleaseMissile(Transform hand)
    {
        
        base.ReleaseMissile(hand);
        transform.position += Vector3.down * 0.3f;
        CalculateSpeed();
    }
    void CalculateSpeed()
    {
        targe = PlayerMovementController.groundPoint;
        distance = (targe - this.transform.position).magnitude;
        speedUp = Mathf.Sqrt(Globals.gravity * distance/2);
        speedForvard = speedUp;

        rigidbody.velocity = direction * speedForvard + Vector3.up * speedUp + PlayerMovementController.velocity;
    }


    public override void DisableMissile()
    {
        Grenade.DisableGrenade(this);
        Weapon.CreateMissile(explosionsInReserve, explosionsInAir, explosion, transform);
    }
    public static void DisableExplosion(Missile missile)
    {
        missile.gameObject.SetActive(false);
        explosionsInAir.Remove(missile);
        explosionsInReserve.Add(missile);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == Globals.enemyLayer)
        { DisableMissile(); }
    }
}
