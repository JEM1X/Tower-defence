using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour
{
  public Material MainMaterial;	// исходный материал (материал по умолчанию)
  public Material CanMaterial;	// материал, если можем строить (при наведении курсора на объект)
  public Material CantMaterial;	// материал, если не можем строить (при наведении курсора на объект)
  public bool CanBuild;			// можем ли строить
  private ResourceManager rm; // ссылка на скрипт "ResourceManager"
  private InventoryManager IM; // ссылка на скрипт "InventoryManager"
  public GameObject tower; // поле для хранения объекта башни
  public MasterTower m_tower; // поле для хранения мастер-башни
  public GameObject item; // Публичное поле для хранения item

  void Start()// Метод, вызываемый при старте объекта
    {
        IM = FindObjectOfType<InventoryManager>(); // создаём указатель/ссылку на скрипт "InventoryManager"
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

    public bool BuildTower(MasterTower Mtower) // Метод для построения башни
    {
        if (CanBuild) // Если можно строить
        { 
            m_tower = Mtower; // Установка мастер-башни
            tower = Instantiate(Mtower.Tower, transform.position, Quaternion.Euler(-90, Random.Range(0, 360), 0)); // Создание башни
            CanBuild = false; // Запрет строительства
            return true;  // Возвращаем true, если строительство выполнено успешно
        }
        else 
        { 
            return false; // Возвращаем false, если строительство не выполнено
        }
        
    }

    private void OnMouseDown() // Метод, вызываемый при нажатии кнопки мыши на объекте
    {
        if (m_tower) // Если есть мастер-башня
        {
            // Создание объекта инвентаря
            item = Instantiate(IM.ItemPrefab, Input.mousePosition, Quaternion.identity, GameObject.Find("MainInventory").transform); 
            item.GetComponent<InventoryItem>().InitialiseMasterTowerItem(m_tower); // Инициализация объекта инвентаря
            item.GetComponent<InventoryItem>().ItemBeginDrag(); // Начало перетаскивания объекта инвентаря
        }
    }

    private void OnMouseDrag() // Метод, вызываемый при перетаскивании объекта мышью
    {
        
        if (m_tower) // Если есть мастер-башня
        {
            item.GetComponent<InventoryItem>().ItemDrag(); // Перетаскивание объекта инвентаря
        }
    }

    private void OnMouseUp() // Метод, вызываемый при отпускании кнопки мыши
    {
        if (m_tower) // Если есть мастер-башня
        {
            // Установка нового родителя объекту инвентаря после перетаскивания
            item.GetComponent<InventoryItem>().parentAfterDrag = IM.GetFreeSlot().transform; 
            item.GetComponent<InventoryItem>().ItemEndDrug(); // Завершение перетаскивания объекта инвентаря
            Destroy(tower); // Уничтожение башни
            m_tower = null; // Сброс мастер-башни
            item = null; // Сброс объекта инвентаря
            CanBuild = true; // Разрешение строительства
        }
    }

}