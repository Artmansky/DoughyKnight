using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Transform target;
    private float currentHealth;
    private bool isFacingRight = false;
    private PlayerExperience playerExperience;
    private AudioSource deathSound;
    private AudioSource audioSource;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject blood;
    public float maxHealth = 10f;
    public float speed = 3f;
    public float experience;

    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerExperience = player.GetComponent<PlayerExperience>();
        deathSound = GameObject.Find("DeathSoundEnemy").GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
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
        target = player.transform;
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
        audioSource.Play();
        Instantiate(blood, transform.position, Quaternion.identity);
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
        playerExperience.AddExp(experience);
        deathSound.Play();
        animator.SetTrigger("Die");
        Destroy(gameObject,0.5f);
    }
}
