using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MADD;

public class PlayerExperience : MonoBehaviour
{
    private float currentExp = 0;
    private float maxExp = 50;
    public int level = 0;
    public Image expBar;

    void Update()
    {
        expBar.fillAmount = Mathf.Clamp(currentExp/maxExp, 0, 1);
    }

    public void AddExp(float exp)
    {
        if (level == 30)
        {
            currentExp = maxExp-1;
            return;
        }
        currentExp += exp;
        if (currentExp >= maxExp)
        {
            PlayerHealth player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            if(player.health < player.maxHealth * 0.75f)
            {
                player.health += player.maxHealth*0.25f;
            }
            else
            {
                player.health = player.maxHealth;
            }
            level++;
            currentExp = 0;
            maxExp += (level*25);
        }
    }
}
