using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
     public Slider slider;
    public Gradient gradient;
    public Image fill;


    public void SetMaxHealth( int BossmaxHealth)
    {
        slider.maxValue = BossmaxHealth;
        slider.value = BossmaxHealth;

        fill.color = gradient.Evaluate(1f);
    }
    
    public void SetHealth(int Bosscurrenthealth)
    {
        slider.value = Bosscurrenthealth;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
