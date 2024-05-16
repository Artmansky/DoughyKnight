using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private Animator animator;
    public float damage = 2.0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.SetBool("Attack", true);
            playerHealth.TakeDamage(damage);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (animator.GetBool("Attack"))
        {
            animator.SetBool("Attack", false);
        }
    }
}
