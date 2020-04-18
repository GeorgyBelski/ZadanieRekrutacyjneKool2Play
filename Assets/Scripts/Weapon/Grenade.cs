using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Weapon
{
    public static List<Missile> grenades = new List<Missile>();
    public static List<Missile> grenadesInAir = new List<Missile>();

    //public Missile missilePrefab;
    public float reloadTime = 0.2f;
    public LineRenderer trajectory;
    [Range(6, 24)]
    public int trajectoryPositions = 14;
    Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
        cooldawn -= reloadTime;
        trajectory.positionCount = trajectoryPositions;
    }

    void FixedUpdate()
    {
        base.Update();
        ShowTrajectory();
    }

    public override void SpecificFire()
    {
        CreateMissile(grenades, grenadesInAir, missilePrefab, this.transform);
        this.transform.localScale = Vector3.zero;
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
    void ShowTrajectory()
    {
        Vector3 target = PlayerMovementController.groundPoint;
        Vector3 start = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 direction = target - start;
        float distance = direction.magnitude;
        for (int i=0; i< trajectory.positionCount; i++)
        {
            Vector3 position = start + direction / trajectory.positionCount * (i+1);
            float deltaX = (position - start).magnitude;
            position.y = deltaX - deltaX * deltaX / distance;

            trajectory.SetPosition(i, position);
        }
    }
    public static void DisableGrenade(Missile missile)
    {
        missile.gameObject.SetActive(false);
        grenadesInAir.Remove(missile);
        grenades.Add(missile);
    }
}
