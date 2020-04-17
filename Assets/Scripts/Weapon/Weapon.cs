using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float cooldawn = .5f;
    public float timerCooldown = 0f;

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
        else { return; }
    }

    public abstract void Fire();

}
