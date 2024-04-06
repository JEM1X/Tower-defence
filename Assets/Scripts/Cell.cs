using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
  public Material MainMaterial;	// исходный материал (материал по умолчанию)
  public Material CanMaterial;	// материал, если можем строить (при наведении курсора на объект)
  public Material CantMaterial;	// материал, если не можем строить (при наведении курсора на объект)
  public bool CanBuild;			// можем ли строить
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

    public bool BuildTower(MasterTower Mtower)
    {
        if (CanBuild)
        {
            Tower tower = Instantiate(Mtower.Tower, transform.position, Quaternion.Euler(-90, Random.Range(0, 360), 0)).GetComponent<Tower>();
            CanBuild = false;
            return true;
        }
        else 
        { 
            return false; 
        }
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("draging");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("draged");
    }

}