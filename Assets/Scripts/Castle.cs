using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour
{
    public int MaxHP;
    public int HP;
    public HealthBar healthBar;
    private bool isCastleDestroyed = false;
    void Start()
    {   
        HP = MaxHP;
        healthBar.SetMaxHealth(MaxHP);
    }

    public void TakeDamage(int damageAmount)
    {   
        if(!isCastleDestroyed) {
            HP -= damageAmount;
            healthBar.SetHealth(HP);
            if (HP <= 0)
            {
                isCastleDestroyed = true;
                SceneManager.LoadScene(2, LoadSceneMode.Additive);
            
            }
        }
        
    }
   
}
