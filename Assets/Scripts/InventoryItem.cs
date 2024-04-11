using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;
    public MasterTower tower;

    [HideInInspector] public Transform parentAfterDrag;
    public void Start()
    {
        InitialiseMasterTowerItem(tower);
    }
    public void InitialiseMasterTowerItem(MasterTower newtower)
    {
        tower = newtower;
        image.sprite = newtower.TowerIcon;
        transform.GetChild(0).gameObject.GetComponent<Text>().text = (tower.ID % 3).ToString();

        if (tower.ID % 3 == 0)
        {
            transform.GetChild(0).gameObject.GetComponent<Text>().text = 3.ToString();
        }
    }

    public void ItemBeginDrag()
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void ItemDrag()
    {
        transform.position = Input.mousePosition;
    }

    public void ItemEndDrug()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Создаем луч от камеры к месту, где был отпущен предмет

        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // Проверяем, попал ли луч на какой-то объект
        {
            if (hit.collider.gameObject.GetComponent<Cell>())
            {
                if (hit.collider.gameObject.GetComponent<Cell>().BuildTower(tower))
                {
                    Destroy(gameObject);
                }

            }

        }
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ItemBeginDrag();
    }

    public void OnDrag(PointerEventData eventData)
    {
        ItemDrag();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ItemEndDrug();
    }
}
