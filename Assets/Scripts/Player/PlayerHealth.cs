using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MADD;

[Docs("Class that manages the player's health and particle effects when the player takes damage.")]
public class PlayerHealth : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private AudioSource hitSound;
    public float health;
    public float maxHealth = 10.0f;
    public GameOverScreen gameOverScreen;
    public Image healthBar;
    public GameObject blood;
    public Animator anime;

    [Docs("Initializes the player's health and the particles that will be used when the player takes damage.")]
    void Start()
    {
        anime = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        hitSound = GetComponent<AudioSource>();
        health = maxHealth;    
    }

    [Docs("Updates the player's health bar and checks if the player's health is less than or equal to 0.")]
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        if (anime.GetCurrentAnimatorStateInfo(0).IsName("Die") && anime.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            gameOverScreen.Setup();
            Time.timeScale = 0;
        }
    }

    [Docs("Reduces the player's health when the player takes damage, initiates death animation")]
    public void TakeDamage(float damage)
    {
        anime.SetTrigger("Hurt");
        Instantiate(blood, transform.position, Quaternion.identity);
        health -= damage;
        hitSound.Play();
        if (health <= 0)
        {
            anime.SetTrigger("isDying");
            playerMovement.isDying = true;
        }
    }
}
