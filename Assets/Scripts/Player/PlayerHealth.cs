using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void Start()
    {
        anime = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        hitSound = GetComponent<AudioSource>();
        health = maxHealth;    
    }

    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        if (anime.GetCurrentAnimatorStateInfo(0).IsName("Die") && anime.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            gameOverScreen.Setup();
            Time.timeScale = 0;
        }
    }

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
