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
    Gold -= TowerCost;
  }

  public void EnemyKill() // убили юнита
  {
    Gold += EnemyCost;
  }

}