using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : MonoBehaviour
{
    public float Speed, Damage, ExplosionRadius; // скорость и урон снаряда
    public LayerMask enemyLayer; // слой, на котором находятся враги

    void Start()
    {
        Destroy (gameObject, 2); // удалить об."Bullet" ч-з 2 сек. после создания, чтобы не летела бесконечно долго
    }

    void Update()
    {
        transform.Translate (Vector3.forward * Speed * Time.deltaTime);
	    // перемещение об."Bullet" на вектора
	    // "Vector3.forward" - направление перемещения вектора, "вперёд"
	    // "Speed*Time.deltaTime" - величина перемещения вектора
	    CheckCollision(); // проверяем столкновение с врагом
    }
    void CheckCollision()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, ExplosionRadius, enemyLayer); // находим всех врагов в радиусе взрыва

        foreach (Collider enemy in hitEnemies) // проходимся по найденным врагам
        {
        
            Enemy enemyScript = enemy.GetComponent<Enemy>(); // получаем компонент Enemy у врага

            if (enemyScript != null) // проверяем, что компонент Enemy был найден
            {
                enemyScript.TakeDamage(Damage); // наносим урон каждому найденному врагу
                    
            }
            

        }
        Destroy(gameObject, 0.25f); // уничтожаем пулю при столкновении с врагом
    }

}