using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public GameOverScreen gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;    
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            gameOverScreen.Setup();
        }
    }
}
