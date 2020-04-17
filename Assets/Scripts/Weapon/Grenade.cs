using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Weapon
{
    void Start()
    {
        
    }

    new void Update()
    {
        base.Update();
    }

    public override void Fire()
    {
        if (timerCooldown > 0) { return; }
        timerCooldown = cooldawn;
        Debug.Log("Grenade is throwed");
    }
}
