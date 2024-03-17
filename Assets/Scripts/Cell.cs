using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
  public Material MainMaterial;	// исходный материал (материал по умолчанию)
  public Material CanMaterial;	// материал, если можем строить (при наведении курсора на объект)
  public Material CantMaterial;	// материал, если не можем строить (при наведении курсора на объект)
  public bool CanBuild;			// можем ли строить
  public GameObject TowerPrefab; // экземпляр башни
  private ResourceManager rm; // ссылка на скрипт "ResourceManager"

  void Start()
  {
    rm = FindObjectOfType<ResourceManager>(); // создаём указатель/ссылку на скрипт "ResourceManager"
  }

  private void OnMouseOver() // курсор находится над объектом (курсор наведён на объект)
  {
    if (CanBuild) // если строительство разрешено
    {
      GetComponent<Renderer>().material = CanMaterial;
	  // "GetComponent<Renderer>.material" - ссылка на материал (свойство "Materials") кмп."Mesh Renderer"
    }
    else // если строительство не разрешено
    {
      GetComponent<Renderer>().material = CantMaterial;
    }
  }

  private void OnMouseExit() // курсор покидает объект, выходит за его границы
  {
    GetComponent<Renderer>().material = MainMaterial; // возвратить объекту исходный материал
  }

  private void OnMouseUp() // отжата кнопка мыши над ячейкой игрового поля
  {
    if (CanBuild && rm.Gold >= rm.TowerCost) // если строительство разрешено и хватает золота для строительства
    {
      Tower tower = Instantiate (TowerPrefab, transform.position, Quaternion.Euler (-90, Random.Range(0, 360), 0)).GetComponent<Tower>();
	  // создаём объект "TowerPrefab" в центре текущей ячейки с координатами "transform.position"
	  // "Quaternion.Euler" - поворот со случайной координатой "Random.Range(0,360)" по оси "Y"
	  // ".GetComponent<Tower>()" - ссылка на экземпляр башни "TowerPrefab" (т.к. "TowerPrefab" типа "GameObject")

	  CanBuild = false; // запрещаем строительство текущей ячейки

      rm.BuildTower(); // уменьшаем значение золота
    }
  }

}