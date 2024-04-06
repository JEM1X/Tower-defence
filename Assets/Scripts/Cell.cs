using System.Collections;
using System.Collections.Generic;
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
  public MasterTower tower;
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
            tower = Mtower;
            Instantiate(Mtower.Tower, transform.position, Quaternion.Euler(-90, Random.Range(0, 360), 0)).GetComponent<Tower>();
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
        if (tower)
        {
            item = Instantiate(IM.ItemPrefab, Input.mousePosition, Quaternion.identity, GameObject.Find("MainInventory").transform);
            item.GetComponent<InventoryItem>().InitialiseMasterTowerItem(tower);
            Debug.Log(Input.mousePosition);
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //item.GetComponent<InventoryItem>().parentAfterDrag = IM.GetFreeSlot().transform;
            item.GetComponent<InventoryItem>().OnBeginDrag(eventData);
            item.transform.position = Input.mousePosition;
        }
    }
    private void OnMouseDrag()
    {
        
        if (tower)
        {
            //item.transform.position = Input.mousePosition;
        }
    }



    private void OnMouseUp()
    {
        Debug.Log("draged");
    }

}