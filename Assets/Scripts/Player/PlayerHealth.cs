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

    void Start()
    {
        health = maxHealth;    
    }

    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            gameOverScreen.Setup();
        }
    }
}
