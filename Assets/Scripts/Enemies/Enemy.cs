using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private float currentHealth;
    private bool isFacingRight = false;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Animator animator;
    public float maxHealth = 10f;
    public float speed = 3f;

    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth,maxHealth);
        GetTarget();
    }

    void FixedUpdate()
    {
        float positionChange = transform.position.x;
        transform.position = Vector3.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
        positionChange -= transform.position.x;
        FlipSprite(positionChange);
    }

    void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FlipSprite(float horizontal)
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
            Die();
        }
        else
        {
            animator.SetTrigger("Damage");
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }
    }

    void Die()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject,0.5f);
    }
}
