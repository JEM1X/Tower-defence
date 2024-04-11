using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour
{
    public int MaxHP;  // Максимальное количество здоровья замка
    public int HP;      // Текущее количество здоровья замка
    public HealthBar healthBar;  // Ссылка на HealthBar для отображения здоровья
    private bool isCastleDestroyed = false;  // Флаг, указывающий, уничтожен ли замок

    void Start()
    {
        HP = MaxHP;  // Устанавливаем текущее здоровье равным максимальному
        healthBar.SetMaxHealth(MaxHP);  // Устанавливаем максимальное значение здоровья на healthBar
    }

    public void TakeDamage(int damageAmount)
    {
        if (!isCastleDestroyed)
        {  // Проверяем, не был ли замок уже уничтожен
            HP -= damageAmount;  // Уменьшаем количество здоровья на величину урона
            healthBar.SetHealth(HP);  // Обновляем отображение здоровья на healthBar
            if (HP <= 0)  // Если здоровье стало меньше или равно нулю
            {
                isCastleDestroyed = true;  // Устанавливаем флаг, что замок уничтожен
                SceneManager.LoadScene(2, LoadSceneMode.Additive);  // Загружаем сцену с индексом 2
            }
        }
    }
}

