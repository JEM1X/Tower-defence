using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;  // Ссылка на компонент Slider, отвечающий за отображение полосы здоровья

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;  // Устанавливаем максимальное значение полосы здоровья равным переданному значению
        slider.value = health;  // Устанавливаем текущее значение полосы здоровья равным переданному значению
    }

    public void SetHealth(int health)
    {
        slider.value = health;  // Устанавливаем текущее значение полосы здоровья равным переданному значению
    }
}

