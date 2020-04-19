using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    public Text startKilledEnemis;
    public static Text killedEnemis;
    public static int killedEnemisNumber;

    public GameObject satrtGun;
    public GameObject startGrenade;

    public static GameObject gun;
    public static GameObject grenade;

    static float gunScale, disableGunScale;
    static float grenadeScale, disableGrenadeScale;

    static Vector3 gunPosition, disableGunPosition;
    static Vector3 grenadePosition, disableGrenadePosition;

    static Vector3 UIDirection;

    void Awake()
    {
        killedEnemis = startKilledEnemis;
        gun = satrtGun;
        grenade = startGrenade;
        gunScale = gun.transform.localScale.x;
        grenadeScale = grenade.transform.localScale.x;
        disableGunScale = gunScale * 0.6f;
        disableGrenadeScale = grenadeScale * 0.6f;

        gunPosition = gun.transform.localPosition;
        grenadePosition = grenade.transform.localPosition;

        UIDirection = Vector3.forward * 30;
        disableGunPosition = gunPosition + UIDirection;
        disableGrenadePosition = grenadePosition + UIDirection;

        SelectUIWeapon(WeaponType.Gun);

        
    }


    public static void AddKilledEnemy()
    {
        killedEnemisNumber++;
        killedEnemis.text = killedEnemisNumber.ToString();
    }

    public static void SelectUIWeapon(WeaponType type)
    {
        if(type == WeaponType.Gun)
        {
            gun.transform.localScale = Vector3.one * gunScale;
         //   gun.transform.localPosition = gunPosition;

            grenade.transform.localScale = Vector3.one * disableGrenadeScale;
         //   grenade.transform.localPosition = disableGrenadePosition;
        }
        else
        {
            grenade.transform.localScale = Vector3.one * grenadeScale;
          //  grenade.transform.localPosition = grenadePosition ;

            gun.transform.localScale = Vector3.one * disableGunScale;
          //  gun.transform.localPosition = disableGunPosition;
        }
    }
}
