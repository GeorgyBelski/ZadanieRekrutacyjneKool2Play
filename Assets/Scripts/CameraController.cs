using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public PositionConstraint constraint;
    Vector3 previousPlayerPosition;

    Vector3 focusPointOffset;
    void Start()
    {
        if (!constraint)
        {
            constraint = GetComponent<PositionConstraint>();
        }
        if (!player)
        {
            player = GameObject.Find("Player_parent").transform;
        }
        LookAtPlayer();
        previousPlayerPosition = player.position;
        
    }

    void Update()
    {
        //PositionConstraint();
    }

    void PositionConstraint()
    {
        focusPointOffset = player.position - previousPlayerPosition;
        transform.position += focusPointOffset;
        previousPlayerPosition = player.position;
    }

    void LookAtPlayer()
    {
        EnableConstraint(false);

        if ( Physics.Raycast( transform.position, transform.rotation * Vector3.forward, out RaycastHit groundHit, 100, Globals.groundMask))
        {
            Debug.DrawLine(transform.position, groundHit.point, Color.yellow);
            
            focusPointOffset = player.position - groundHit.point;
            transform.position += focusPointOffset;

            Vector3 cameraOffset = transform.position - player.position;
            constraint.translationOffset = cameraOffset;
            EnableConstraint(true);
        }
        
    }
    void EnableConstraint(bool enable)
    {
        constraint.constraintActive = enable;
        constraint.enabled = enable;
    }
}
