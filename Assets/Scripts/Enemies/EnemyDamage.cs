using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using MADD;

public class EnemyDamage : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private Animator animator;
    private float lastAttackTime;
    public float damage = 2.0f;
    public float attackCooldown = 0.5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Attack");
            playerHealth.TakeDamage(damage);
            lastAttackTime = Time.time;
        }
    }

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
