using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public static List<Missile> bullets = new List<Missile>();
    public static List<Missile> bulletsInAir = new List<Missile>();

    public float bulletSpeed = 40;
    /*
    [SerializeField] int bulletsCount = 0;
    [SerializeField] int bulletsInAirCount = 0;
    */
    void Start()
    {
        CreateBullets();
    }

    new void Update()
    {
        base.Update();
        /*
        bulletsCount = bullets.Count;
        bulletsInAirCount = bulletsInAir.Count;
        */
    }
    void CreateBullets()
    {
        int NumberOfBullets = (int)(missilePrefab.lifetime / cooldawn) + 1;
        for(int i=0; i < NumberOfBullets; i++) 
        {
            Missile bullet = Instantiate(missilePrefab);
            bullet.gameObject.SetActive(false);
            bullets.Add(bullet);
        }
    }
    public override void SpecificFire()
    {
        CreateMissile(bullets, bulletsInAir, missilePrefab, this.transform);
    }

    public static void DisableBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bulletsInAir.Remove(bullet);
        bullets.Add(bullet);   
    }

    protected override void Reload()
    {
        state = WeaponState.Ready;
    }
}
