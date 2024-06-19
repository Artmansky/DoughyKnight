using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

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
        if (anime.GetCurrentAnimatorStateInfo(0).IsName("Die") && anime.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            gameOverScreen.Setup();
        }
    }

    public void TakeDamage(float damage)
    {
        anime.SetTrigger("Hurt");
        health -= damage;
        if(health <= 0)
        {
            anime.SetTrigger("isDying");
            GetComponent<PlayerMovement>().isDying = true;
        }
    }
}
