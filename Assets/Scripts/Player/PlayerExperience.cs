using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour
{
    private int currentExp = 0;
    private int maxExp = 100;
    public Image expBar;

    void Update()
    {
        expBar.fillAmount = Mathf.Clamp(currentExp/maxExp, 0, 1);
    }
}
