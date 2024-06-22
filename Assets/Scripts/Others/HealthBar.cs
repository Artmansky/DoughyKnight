using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MADD;

[Docs("HealthBar slider")]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [Docs("Update health bar with current health and max health")]
    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        slider.value = currentHealth/maxHealth;
    }
}
