using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MADD;

[Docs("This class is responsible for the enemy's behavior, such as taking damage, dying, and moving towards the player.")]
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

    [Docs("This method is called when the object is created. It gets the player object, the player's experience, and the death sound.")]
    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerExperience = player.GetComponent<PlayerExperience>();
        deathSound = GameObject.Find("DeathSoundEnemy").GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
    }

    [Docs("This method is called when the object is created. It sets the current health to the max health, updates the health bar, and gets the target.")]
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth,maxHealth);
        GetTarget();
    }

    [Docs("This method is called every frame. It moves the enemy towards the player and flips the sprite if needed.")]
    void FixedUpdate()
    {
        float positionChange = transform.position.x;
        transform.position = Vector3.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
        positionChange -= transform.position.x;
        FlipSprite(positionChange);
    }

    [Docs("This method gets the target of the enemy, which is the player.")]
    void GetTarget()
    {
        target = player.transform;
    }

    [Docs("This method flips the sprite of the enemy.")]
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

    [Docs("This method is called when the enemy takes damage. It decreases the current health, plays the audio, instantiates blood, and checks if the enemy is dead.")]
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

    [Docs("This method is called when the enemy dies. It adds experience to the player, plays the death sound, triggers the die animation, and destroys the object.")]
    void Die()
    {
        playerExperience.AddExp(experience);
        deathSound.Play();
        animator.SetTrigger("Die");
        Destroy(gameObject,0.5f);
    }
}
