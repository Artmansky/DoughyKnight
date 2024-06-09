using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 10.0f;
    public GameOverScreen gameOverScreen;
    public Image healthBar;
    public Animator anime;

    void Start()
    {
        anime = GetComponent<Animator>();
        health = maxHealth;    
    }

    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        anime.SetTrigger("Hurt");
        health -= damage;
        if(health <= 0)
        {
            anime.SetTrigger("IsDying");
            gameOverScreen.Setup();
        }
    }
}
