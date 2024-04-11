using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // добавить библиотеку "UI"

public class ResourceManager : MonoBehaviour
{
  public Text GoldTxt; // ссылка на переменную типа "Text"
  public int Gold, TowerCost, EnemyCost; // количество золота, стоимость постройки башни, вознаграждение за убитого юнита
  void Update()
  {
    GoldTxt.text = "Gold: " + Gold; // показываем текущее значение золота
  }

  public void BuildTower() // построили башню
  {
    Gold -= TowerCost; // снижаем количество монет на цену башни
  }

  public void EnemyKill() // убили юнита
  {
    Gold += EnemyCost; // добавляем количество монет на цену Enemy
  }

}