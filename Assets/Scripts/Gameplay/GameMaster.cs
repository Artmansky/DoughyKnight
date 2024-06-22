using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MADD;
using UnityEngine.Timeline;

[Docs("This class is responsible for managing the player's upgrades.")]
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

    [Docs("This method is called when the object becomes enabled and active.")]
    void Awake()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    [Docs("This method is called when the object becomes enabled and active.")]
    private void OnEnable()
    {
        enableAttack();
        enableHealth();
        enableKnockback();
    }

    [Docs("This method adds more knockback strength to the player.")]
    public void addKnockback()
    {
        playerMovement.knockbackForce += 0.1f;
        adjustHealth();
        knockbackUpgrade++;
        Time.timeScale = 1;
    }

    [Docs("This method adds more health to the player.")]
    public void addHealth()
    {
        playerHealth.maxHealth += 100;
        adjustHealth();
        healthUpgrade++;
        Time.timeScale = 1;
    }

    [Docs("This method adds more attack damage to the player.")]
    public void addAttack()
    {
        playerMovement.damage += 2;
        adjustHealth();
        attackUpgrade++;
        Time.timeScale = 1;
    }

    [Docs("This method adjusts the player's health.")]
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

    [Docs("This method enables the attack upgrade.")]
    public void enableAttack()
    {
        if (attackUpgrade == 10)
        {
            attackButton[0].SetActive(false);
            attackButton[1].SetActive(false);
        }
    }

    [Docs("This method enables the health upgrade.")]
    public void enableHealth()
    {
        if (healthUpgrade == 10)
        {
            healthButton[0].SetActive(false);
            healthButton[1].SetActive(false);
        }
    }

    [Docs("This method enables the knockback upgrade.")]
    public void enableKnockback()
    {
        if (knockbackUpgrade == 10)
        {
            knockbackButton[0].SetActive(false);
            knockbackButton[1].SetActive(false);
        }
    }
}
