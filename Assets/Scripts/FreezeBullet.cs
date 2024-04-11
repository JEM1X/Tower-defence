using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBullet : MonoBehaviour
{
  public float Speed, Damage; // скорость и урон снаряда

  void Start()  // Метод Start вызывается при запуске сцены
    {
    Destroy (gameObject, 2); // удалить об."Bullet" ч-з 2 сек. после создания, чтобы не летела бесконечно долго
  }

  void Update() // Метод Update вызывается каждый кадр
    {
    transform.Translate (Vector3.forward * Speed * Time.deltaTime);
	// перемещение об."Bullet" на вектора
	// "Vector3.forward" - направление перемещения вектора, "вперёд"
	// "Speed*Time.deltaTime" - величина перемещения вектора
  }
    void OnTriggerEnter(Collider other) // Метод, вызываемый при столкновении с другим коллайдером
    {
        if (other.CompareTag("Enemy")) // Проверяем, что столкнулись с объектом, имеющим тег "Enemy"
        {
            Enemy enemyScript = other.GetComponent<Enemy>(); // Получаем компонент скрипта Enemy объекта, в который попал снаряд
            if (enemyScript != null)  // Проверяем, что компонент Enemy был найден
            {
                enemyScript.Speed /= 2; // Замедляем скорость объекта Enemy вдвое
                
                StartCoroutine(ResetSpeed(enemyScript)); // Запускаем корутину для восстановления скорости через 3 секунды
            }
            Destroy(gameObject); // Уничтожаем снаряд после попадания
        }
    }

    IEnumerator ResetSpeed(Enemy enemy) // Корутина для восстановления скорости объекта Enemy через определенное время
    {
        yield return new WaitForSeconds(1f); // Ждем 3 секунды
        
        enemy.Speed *= 2; // Восстанавливаем оригинальную скорость объекту Enemy
    }
}