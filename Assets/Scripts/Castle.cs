using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour
{
    public int MaxHP;
    public int HP;
    public HealthBar healthBar;
    void Start()
    {
        HP = MaxHP;
        healthBar.SetMaxHealth(MaxHP);
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        healthBar.SetHealth(HP);
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
