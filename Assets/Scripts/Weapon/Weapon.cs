using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState { Ready, Cooldawn, Reload }
public abstract class Weapon : MonoBehaviour
{
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

    public abstract void Fire();
    protected abstract void Reload();

}
