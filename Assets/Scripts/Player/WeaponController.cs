using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public static Weapon activeWeapon;
    public static int currentIndex;

    public List<Weapon> weaponPrefabsList;
    [SerializeField] List<Weapon> weaponList = new List<Weapon>();
    public Transform player, weaponPoint;
    void Start()
    {
        CreateWeapons();
        PutInHand(0);
    }

    void FixedUpdate()
    {
        Fire();
        ChengeWeapon();

        if (activeWeapon)
        {
            Vector3 groundPoint = PlayerMovementController.groundPoint;
            Vector3 lookAtpoint = new Vector3(groundPoint.x, activeWeapon.transform.position.y, groundPoint.z);
            activeWeapon.transform.LookAt(lookAtpoint);
        }
    }
    void Fire()
    {
        if (Input.GetButton("Fire1"))
        {
            //Debug.Log("Fire");
            activeWeapon.Fire();
        }
    }

    void CreateWeapons()
    {
        weaponPrefabsList.ForEach(prefab => {
                var weapon = Instantiate(prefab);
                weaponList.Add(weapon);
                weapon.gameObject.SetActive(false);
            });
    }
    void PutInHand(int index)
    {
        if(index < weaponList.Count)
        {
            if (activeWeapon)
            {
                activeWeapon.state = WeaponState.Cooldawn;
                activeWeapon.gameObject.SetActive(false);
            }
            activeWeapon = weaponList[index];
            activeWeapon.transform.parent = player;
            activeWeapon.transform.position = weaponPoint.transform.position;
            activeWeapon.gameObject.SetActive(true);
            currentIndex = index;
            UIController.SelectUIWeapon(activeWeapon.type);
        }
    }
    void ChengeWeapon()
    {
        if(Input.mouseScrollDelta.y >= 1 || Input.GetKeyDown(KeyCode.Tab))
        {
            currentIndex++;
            if(currentIndex >= weaponList.Count)
            {
                currentIndex = 0;
            }
        }
        else if(Input.mouseScrollDelta.y <= -1)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = weaponList.Count -1;
            }
        }
        else { return; }

        PutInHand(currentIndex);
    }

    
}
