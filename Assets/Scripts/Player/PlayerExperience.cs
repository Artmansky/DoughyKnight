using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MADD;

[Docs("Class that manages the player experience")]
public class PlayerExperience : MonoBehaviour
{
    [SerializeField] private GameObject levelUpPanel;
    private float currentExp = 0;
    public float maxExp = 50;
    public int level = 0;
    public Image expBar;

    [Docs("Updates the experience bar")]
    void Update()
    {
        expBar.fillAmount = Mathf.Clamp(currentExp/maxExp, 0, 1);
    }

    [Docs("Adds experience to the player, if it hits the cap stays on max level")]
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
            level++;
            currentExp = 0;
            maxExp += (level*10);
            levelUpPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
