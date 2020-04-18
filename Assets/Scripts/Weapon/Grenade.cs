using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Weapon
{
    public static List<Grenade> grenades = new List<Grenade>();
    public static List<Grenade> grenadesInAir = new List<Grenade>();
    public float reloadTime = 0.2f;
    Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
        cooldawn -= reloadTime;
    }

    new void Update()
    {
        base.Update();
    }

    public override void Fire()
    {
        if (timerCooldown > 0 || state != WeaponState.Ready) { return; }

        state = WeaponState.Cooldawn;
        timerCooldown = cooldawn;
        Debug.Log("Grenade is throwed");
    }
    protected override void Reload()
    {
        state = WeaponState.Reload;
        StartCoroutine(ShowUp());
    }

    IEnumerator ShowUp()
    {
        for (float timer = 0f; timer < reloadTime; timer += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(Vector3.zero, startScale, timer / reloadTime);
            yield return null;
        }
        state = WeaponState.Ready;
        Debug.Log("Ready");
    }
}
