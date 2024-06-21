using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour
{
    private float currentExp = 0;
    private float maxExp = 100;
    private int level = 1;
    public Image expBar;

    void Update()
    {
        expBar.fillAmount = Mathf.Clamp(currentExp/maxExp, 0, 1);
    }

    public void AddExp(float exp)
    {
        currentExp += exp;
        if (currentExp >= maxExp)
        {
            level++;
            currentExp = 0;
            maxExp += 50;
        }
    }
}
