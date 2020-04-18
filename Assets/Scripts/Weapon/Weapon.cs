using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState { Ready, Cooldawn, Reload }
public abstract class Weapon : MonoBehaviour
{
    public Missile missilePrefab;
    public float cooldawn = .5f;
    public float timerCooldown = 0f;
    public WeaponState state = WeaponState.Ready;
    void Start()
    {
        
    }
    protected void Update()
    {
        ReduceTimer();
    }

    void ReduceTimer()
    {
        if (timerCooldown > 0)
        {
            timerCooldown -= Time.deltaTime;
        }
        else {
            if (state == WeaponState.Cooldawn)
            {   
                Reload();
            }
            return; 
        }
    }

    public virtual void Fire()
    {
        if (timerCooldown > 0 || state != WeaponState.Ready) { return; }

        state = WeaponState.Cooldawn;
        timerCooldown = cooldawn;

        SpecificFire();
    }

    public static void CreateMissile(List<Missile> missiles, List<Missile> missilesInAir, Missile missilePrefab, Transform weapon)
    {
        Missile missile;
        if (missiles.Count > 0)
        {
            missile = missiles[0];
            missiles.Remove(missile);
        }
        else
        {
            missile = Instantiate(missilePrefab);
        }
        missilesInAir.Add(missile);
        missile.ReleaseMissile(weapon);
    }
    public abstract void SpecificFire();
    protected abstract void Reload();

}
