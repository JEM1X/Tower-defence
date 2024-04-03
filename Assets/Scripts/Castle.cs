using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public int MaxHP;
    private int HP;

    void Start()
    {
        HP = MaxHP;
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            Destroy(gameObject); // Уничтожаем замок, если его здоровье меньше или равно нулю
        }
    }
}
