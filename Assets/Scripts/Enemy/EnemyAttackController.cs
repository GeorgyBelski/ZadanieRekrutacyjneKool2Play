using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState { Move, CloseToPlayer, Attacking}
public class EnemyAttackController : MonoBehaviour
{
    public int damage = 10;
    public float distanceToAttack = 2.5f;
    public float attackCooldown = 1f;
    float timerAttackCooldown = 0.5f;
    public EnemyState state = EnemyState.Move;
    
    public EnemyMovementController movementController;
    public Animator animator;
    public List<GameObject> eyes;
    List<Material> eyeMaterials = new List<Material>();
    Color startEyeColor;
    void Start()
    {
        if (!movementController) { movementController = GetComponent<EnemyMovementController>(); }
        if (!animator) { animator = GetComponent<Animator>(); }
        for (int i = 0; i < eyes.Count; i++) 
        {
            eyeMaterials.Add(eyes[i].GetComponent<MeshRenderer>().material);
        }
        if (eyeMaterials.Count > 0)
        { startEyeColor = eyeMaterials[0].color; }
    }

    void Update()
    {
        // CheckDistanceToPlayer();
        ReduseTimer();
    }
    void CheckDistanceToPlayer()
    {
        if(movementController.distanceToPlayer <= distanceToAttack)
        {
            eyeMaterials.ForEach(material => material.color = Color.red);
        }
        else
        {
            eyeMaterials.ForEach(material => material.color = Color.white);
        }
    }

    void ReduseTimer()
    {
        if(state == EnemyState.CloseToPlayer)
        {
            timerAttackCooldown -= Time.deltaTime;
            if(timerAttackCooldown <= 0)
            {
                timerAttackCooldown = attackCooldown;
                animator.SetBool("Attack", true);
            }
        }
        
    }
    void Attack() // Call from Animation
    {
        PlayerHealth.player.ApplyDamage(damage);
    }
    void FinishAttack()// Call from Animation
    {
        animator.SetBool("Attack", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Globals.playerLayer)
        {
            state = EnemyState.CloseToPlayer;
            eyeMaterials.ForEach(material => material.color = Color.red);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == Globals.playerLayer)
        {
            RestartState();
        }
    }

    public void RestartState()
    {
        animator.SetBool("Attack", false);
        state = EnemyState.Move;
        eyeMaterials.ForEach(material => material.color = startEyeColor);
    }
}
