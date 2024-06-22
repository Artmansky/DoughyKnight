using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerHealth : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private AudioSource hitSound;
    private GameObject finishSound;
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
        finishSound = GameObject.Find("Death Sound");
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
        hitSound.Play();
        Instantiate(blood, transform.position, Quaternion.identity);
        health -= damage;
        if(health <= 0)
        {
            anime.SetTrigger("isDying");
            finishSound.GetComponent<AudioSource>().Play();
            playerMovement.isDying = true;
        }
    }
}
