using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth( int warriorCurrentHealth)
    {
        slider.maxValue = warriorCurrentHealth;
        slider.value = warriorCurrentHealth;

        fill.color = gradient.Evaluate(1f);
    }
    
    public void SetHealth(int warriorCurrentHealth)
    {
        slider.value = warriorCurrentHealth;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
