using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  public Enemy EnemyPrefab;
  public float TimeToSpawn; // частота (промежуток времени) создания новых юнитов
  public Transform[] Points; // массив точек движения юнита
  private float timer;
  public float MainHP, IncreaseHP; // основное и дельта здоровья для следующих юнитов

  void Start()
  {
    timer = TimeToSpawn; // время создания 1-го юнита
  }

  void Update()
  {
    timer -= Time.deltaTime; // из "timer" вычитаем время рендеринга/отрисовки

    if (timer <= 0)
    {
      Enemy enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
	  // создаём объект (новый юнит)
	  // "EnemyPrefab" - что создаём/клонируем (исходный объект)
	  // "transform.position" - где создаём, в какой позиции (координаты об."Spawner")
	  // "Quaternion.identity" - как повёрнут, какой поворот/разворот кватерниона (поворот прф."Enemy")
      enemy.Points = Points; // передаём созданному объекту (новому юниту) массив точек маршрута движения

      timer = TimeToSpawn; // восстанавливаем время создания новых юнитов

      // реализация увеличения здоровья с новым юнитом
      enemy.SetHP (MainHP); // передаём "новое" здоровье экз.прф."Enemy"
      MainHP += IncreaseHP; // увеличиваем здоровье для каждого нового юнита
    }
  }

}