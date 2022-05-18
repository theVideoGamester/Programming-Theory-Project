using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxHealth(int maxHP,int hp)
    {
        slider = GetComponentInParent<Slider>();
        slider.maxValue = maxHP;
        slider.value = hp;
    }
    public void SetHealth(int hp)
    {
        slider.value = hp;
    }
}
