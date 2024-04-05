using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBullet : MonoBehaviour
{
  public float Speed, Damage; // скорость и урон снаряда

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
  }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Получаем компонент скрипта Enemy объекта, в который попал снаряд
            Enemy enemyScript = other.GetComponent<Enemy>();
            if (enemyScript != null)   
            {
                // Замедляем скорость объекта Enemy
                enemyScript.Speed /= 2;
                // Запускаем корутину для восстановления скорости через 3 секунды
                StartCoroutine(ResetSpeed(enemyScript));
            }
            Destroy(gameObject); // Уничтожаем снаряд после попадания
        }
    }

    IEnumerator ResetSpeed(Enemy enemy)
    {
        yield return new WaitForSeconds(1f); // Ждем 3 секунды
        // Восстанавливаем оригинальную скорость объекту Enemy
        enemy.Speed *= 2;
    }
}