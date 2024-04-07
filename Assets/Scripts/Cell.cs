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
  private InventoryManager IM;
  public GameObject tower;
  public MasterTower m_tower;
  public GameObject item;

  void Start()
  {
        IM = FindObjectOfType<InventoryManager>();
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

    public bool BuildTower(MasterTower Mtower)
    {
        if (CanBuild)
        {
            m_tower = Mtower;
            tower = Instantiate(Mtower.Tower, transform.position, Quaternion.Euler(-90, Random.Range(0, 360), 0)); //.GetComponent<Tower>();
            CanBuild = false;
            return true; 
        }
        else 
        { 
            return false; 
        }
        
    }

    private void OnMouseDown()
    {
        if (m_tower)
        {
            item = Instantiate(IM.ItemPrefab, Input.mousePosition, Quaternion.identity, GameObject.Find("MainInventory").transform);
            item.GetComponent<InventoryItem>().InitialiseMasterTowerItem(m_tower);
            item.GetComponent<InventoryItem>().ItemBeginDrag();
        }
    }
    private void OnMouseDrag()
    {
        
        if (m_tower)
        {
            item.GetComponent<InventoryItem>().ItemDrag();
        }
    }



    private void OnMouseUp()
    {
        if (m_tower)
        {
            item.GetComponent<InventoryItem>().parentAfterDrag = IM.GetFreeSlot().transform;
            item.GetComponent<InventoryItem>().ItemEndDrug();
            Destroy(tower);
            m_tower = null;
            item = null;
            CanBuild = true;
        }
    }

}