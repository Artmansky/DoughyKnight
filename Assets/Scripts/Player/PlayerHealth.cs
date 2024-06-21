using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerHealth : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private float health;
    public float maxHealth = 10.0f;
    public GameOverScreen gameOverScreen;
    public Image healthBar;
    public GameObject blood;
    public Animator anime;

    void Start()
    {
        anime = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
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
        Instantiate(blood, transform.position, Quaternion.identity);
        health -= damage;
        if(health <= 0)
        {
            anime.SetTrigger("isDying");
            playerMovement.isDying = true;
        }
    }
}
