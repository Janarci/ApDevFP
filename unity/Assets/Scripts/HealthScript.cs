using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] Slider slider;

    public void setHealthMax(float healthMax)
    {
        slider.maxValue = healthMax;

    }
    public void updateHealth(float currentHealth)
    {
        slider.value = currentHealth;

    }
}
