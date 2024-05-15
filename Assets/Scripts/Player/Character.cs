using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentExperience;
    [SerializeField] private float maxExperience;
    [SerializeField] private int currentLevel;

    private void OnEnable()
    {
        ExperienceManager.Instance.OnExperienceChange += HandleExperienceChange;
    }

    private void OnDisable()
    {
        ExperienceManager.Instance.OnExperienceChange -= HandleExperienceChange;
    }

    private void HandleExperienceChange(int newExp)
    {
        currentExperience += newExp;
        if(currentExperience > maxExperience)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        if (currentHealth >= 0.75 * maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth = currentHealth + (float)(0.25 * maxHealth);
        }
        currentLevel++;
        currentExperience = 0;
        maxExperience += 100;
    }
}
