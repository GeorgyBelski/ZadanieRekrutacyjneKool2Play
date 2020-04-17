using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public Bullet bulletPrefab;
    public float bulletSpeed = 40;
    public static List<Bullet> bullets = new List<Bullet>();
    public static List<Bullet> bulletsInAir = new List<Bullet>();
    [SerializeField] int bulletsCount = 0;
    [SerializeField] int bulletsInAirCount = 0;
    void Start()
    {
        CreateBullers();
    }

    new void Update()
    {
        base.Update();
        bulletsCount = bullets.Count;
        bulletsInAirCount = bulletsInAir.Count;
    }
    void CreateBullers()
    {
        int NumberOfBullets = (int)(bulletPrefab.lifetime / cooldawn) + 1;
        for(int i=0; i < NumberOfBullets; i++) 
        { 
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.gameObject.SetActive(false);
            bullets.Add(bullet);
        }
    }
    public override void Fire()
    {
        if(timerCooldown > 0) { return; }
        timerCooldown = cooldawn;
        //Debug.Log("Gun Shooting");
        Bullet bullet;
        if(bullets.Count > 1)
        {
            bullet = bullets[0];
            bullets.Remove(bullet);
            bullet.transform.rotation = this.transform.rotation;
            bullet.transform.position = this.transform.position; 
        }
        else
        {
            bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        }
        bulletsInAir.Add(bullet);
        bullet.ShootABullet();
    }

    public static void DisableBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bulletsInAir.Remove(bullet);
        bullets.Add(bullet);
        
    }
}
