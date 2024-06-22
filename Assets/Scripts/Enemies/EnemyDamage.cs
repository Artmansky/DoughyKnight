using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using MADD;

[Docs("This script is responsible for dealing damage to the player when the enemy collides with the player.")]
public class EnemyDamage : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private Animator animator;
    private float lastAttackTime;
    public float damage = 2.0f;
    public float attackCooldown = 0.5f;

    [Docs("This method is called when the object becomes enabled and active.")]
    private void Start()
    {
        animator = GetComponent<Animator>();
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
    }

    [Docs("This method is called when the Collider2D other enters the trigger and damaged the player.")]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Attack");
            playerHealth.TakeDamage(damage);
            lastAttackTime = Time.time;
        }
    }

    [Docs("This method is called when the Collider2D other stays in the trigger and damaged the player.")]
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Time.time - lastAttackTime < attackCooldown) return;
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Attack");
            playerHealth.TakeDamage(damage);
            lastAttackTime = Time.time;
        }
    }
}
