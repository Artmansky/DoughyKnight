using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class GameMaster : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;
    private int attackUpgrade = 0;
    private int healthUpgrade = 0;
    private int knockbackUpgrade = 0;
    [SerializeField] private GameObject thisPanel;
    [SerializeField] private GameObject[] attackButton;
    [SerializeField] private GameObject[] healthButton;
    [SerializeField] private GameObject[] knockbackButton;

    void Awake()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        enableAttack();
        enableHealth();
        enableKnockback();
    }

    public void addKnockback()
    {
        playerMovement.knockbackForce += 0.1f;
        adjustHealth();
        knockbackUpgrade++;
        Time.timeScale = 1;
    }

    public void addHealth()
    {
        playerHealth.maxHealth += 100;
        adjustHealth();
        healthUpgrade++;
        Time.timeScale = 1;
    }

    public void addAttack()
    {
        playerMovement.damage += 2;
        adjustHealth();
        attackUpgrade++;
        Time.timeScale = 1;
    }

    void adjustHealth()
    {
        if (playerHealth.health < playerHealth.maxHealth * 0.75f)
        {
            playerHealth.health += playerHealth.maxHealth * 0.25f;
        }
        else
        {
            playerHealth.health = playerHealth.maxHealth;
        }
        thisPanel.SetActive(false);
    }

    public void enableAttack()
    {
        if (attackUpgrade == 10)
        {
            attackButton[0].SetActive(false);
            attackButton[1].SetActive(false);
        }
    }

    public void enableHealth()
    {
        if (healthUpgrade == 10)
        {
            healthButton[0].SetActive(false);
            healthButton[1].SetActive(false);
        }
    }

    public void enableKnockback()
    {
        if (knockbackUpgrade == 10)
        {
            knockbackButton[0].SetActive(false);
            knockbackButton[1].SetActive(false);
        }
    }
}
