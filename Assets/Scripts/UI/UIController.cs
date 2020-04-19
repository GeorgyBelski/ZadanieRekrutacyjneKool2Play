using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{

    public static UIController controller;
    public Text killedEnemis, gameOver;
    public int killedEnemisNumber;
    public GameObject gun;
    public GameObject grenade;

    static float gunScale, disableGunScale;
    static float grenadeScale, disableGrenadeScale;

    static Vector3 UIDirection;

    void Awake()
    {
        controller = this;
        gameOver.gameObject.SetActive(false);
        gunScale = gun.transform.localScale.x;
        grenadeScale = grenade.transform.localScale.x;
        disableGunScale = gunScale * 0.6f;
        disableGrenadeScale = grenadeScale * 0.6f;

        UIDirection = Vector3.forward * 30;


        SelectUIWeapon(WeaponType.Gun);

        PlayerHealth.playerDeathEvent += ShowGameOver;
    }


    public static void AddKilledEnemy()
    {
        controller.killedEnemisNumber++;
        controller.killedEnemis.text = controller.killedEnemisNumber.ToString();
    }

    public static void SelectUIWeapon(WeaponType type)
    {
        if(type == WeaponType.Gun)
        {
            controller.gun.transform.localScale = Vector3.one * gunScale;

            controller.grenade.transform.localScale = Vector3.one * disableGrenadeScale;
        }
        else
        {
            controller.grenade.transform.localScale = Vector3.one * grenadeScale;

            controller.gun.transform.localScale = Vector3.one * disableGunScale;
        }
    }

    void ShowGameOver()
    {
        gameOver.gameObject.SetActive(true);
    }
}
