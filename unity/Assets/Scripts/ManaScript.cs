using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManaScript : MonoBehaviour
{
    [SerializeField] Slider slider;

    public void setManaMax(float manaMax)
    {
        slider.maxValue = manaMax;

    }
    public void updateMana(float currentMana)
    {
        slider.value = currentMana;

    }
  
}
