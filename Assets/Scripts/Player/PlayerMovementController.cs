using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public static Vector3 groundPoint = Vector3.zero;
    public static Vector3 velocity;

    public float speed = 10;
    public Transform player;
    new Camera camera;

    void Start()
    {
        camera = Camera.main;
        if (!player)
        {
            player = transform.Find("Player");
        }
    }
    private void FixedUpdate()
    {
        Moving();
    }
    void LateUpdate()
    {   
        Turning();
    }
    void Moving()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 inputAxisVector =  new Vector3(x, 0, z).normalized;
        velocity = inputAxisVector * speed;
        transform.position += velocity * Time.deltaTime;

    }
    void Turning()
    {
        Ray camRay = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(camRay, out RaycastHit groundHit, 30, Globals.groundMask))
        {
            groundPoint = groundHit.point;
            player.transform.LookAt(new Vector3(groundHit.point.x, transform.position.y, groundHit.point.z));
        }
    }
}
