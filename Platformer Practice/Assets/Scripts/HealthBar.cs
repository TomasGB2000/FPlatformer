using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/***************************************************************************************
* Title: Health Bar
* Author: Brackeys
* Date: 2020
* Code version: N/A
* Availability: https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=859s
***************************************************************************************/
public class HealthBar : MonoBehaviour
{
    public Slider hpSlider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        hpSlider.maxValue = health;
        hpSlider.value = health;

        gradient.Evaluate(1f);

        fill.color = gradient.Evaluate(1f);
    }
    
    public void SetHealth(int health)
    {
        hpSlider.value = health;

        fill.color = gradient.Evaluate(hpSlider.normalizedValue);
    }
}
