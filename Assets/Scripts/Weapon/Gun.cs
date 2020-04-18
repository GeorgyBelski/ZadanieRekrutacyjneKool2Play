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
        if(timerCooldown > 0 || state != WeaponState.Ready) { return; }

        state = WeaponState.Cooldawn;
        timerCooldown = cooldawn;
        
        Bullet bullet;
        if(bullets.Count > 0)
        {
            bullet = bullets[0];
            bullets.Remove(bullet);
          //  bullet.transform.rotation = this.transform.rotation;
         //   bullet.transform.position = this.transform.position; 
        }
        else
        {
            bullet = Instantiate(bulletPrefab);
        }
        bulletsInAir.Add(bullet);
        bullet.ShootABullet(this.transform);
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
