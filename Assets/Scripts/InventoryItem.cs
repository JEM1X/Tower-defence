using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;

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
    public void DeleteItem()
    {
        Destroy(gameObject);
    }
    public void InitialiseMasterTowerItem(MasterTower newtower)
    {
        tower = newtower;
        image.sprite = newtower.TowerIcon;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData) 
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ������� ��� �� ������ � �����, ��� ��� ������� �������

        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // ���������, ����� �� ��� �� �����-�� ������
        {
            Debug.Log(hit.collider.gameObject);
            if (hit.collider.gameObject.GetComponent<Cell>())
            {
                hit.collider.gameObject.GetComponent<Cell>().BuildTower(tower);
                Destroy(gameObject);
            }

        }
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
