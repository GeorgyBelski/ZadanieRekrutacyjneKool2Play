using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 10;

    new Camera camera;

    void Start()
    {
        camera = Camera.main;
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
        transform.position += inputAxisVector * speed * Time.deltaTime;

    }
    void Turning()
    {
        Ray camRay = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(camRay, out RaycastHit groundHit, 30, Globals.groundMask))
        {
            transform.LookAt(new Vector3(groundHit.point.x, transform.position.y, groundHit.point.z));
        }
    }
}
