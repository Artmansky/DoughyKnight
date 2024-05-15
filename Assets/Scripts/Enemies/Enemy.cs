using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private float currentHealth;
    [SerializeField] private HealthBar healthBar;
    public float maxHealth = 10f;
    public float speed = 3f;
    public int experience;

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
        transform.position = Vector3.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
    }

    void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
