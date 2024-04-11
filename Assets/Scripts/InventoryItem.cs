using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler // ���������� ������ InventoryItem, ������� ����������� �� MonoBehaviour � ����������� IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")] // ��������� ��� ����� � ����������
    public Image image; // ��������� ���� ��� �����������
    public MasterTower tower; // ��������� ���� ��� ������� MasterTower

    [HideInInspector] public Transform parentAfterDrag; // ������� ���� ��� �������� �������� ����� ��������������

    public void Start() // �����, ���������� ��� ������ �������
    {
        InitialiseMasterTowerItem(tower); // ����� ������ ��� ������������� ������� MasterTower
    }

    public void InitialiseMasterTowerItem(MasterTower newtower) // ����� ��� ������������� ������� MasterTower
    {
        tower = newtower; // ������������ ������ ������� MasterTower
        image.sprite = newtower.TowerIcon; // ��������� ������� ����������� ������� MasterTower
        transform.GetChild(0).gameObject.GetComponent<Text>().text = (tower.ID % 3).ToString(); // ��������� ��������� ������� � ��������� ������

        if (tower.ID % 3 == 0) // �������� �������
        {
            transform.GetChild(0).gameObject.GetComponent<Text>().text = 3.ToString(); // ��������� ������ ������� 3
        }
    }

    public void ItemBeginDrag() // ����� ������ �������������� ��������
    {
        parentAfterDrag = transform.parent; // ���������� �������� �� ��������������
        transform.SetParent(transform.root); // ��������� �������� �� �������� ������
        transform.SetAsLastSibling(); // ��������� ������� ������ ���������
        image.raycastTarget = false; // ���������� ����������� �������������� � ������������
    }

    public void ItemDrag() // ����� �������������� ��������
    {
        transform.position = Input.mousePosition; // ��������� ������� ������� �� ������� ����
    }

    public void ItemEndDrug() // ����� ���������� �������������� ��������
    {
        RaycastHit hit; // ���������� ��� �������� ���������� � ��������� ����
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // �������� ���� �� ������ � ������� ����

        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // �������� ��������� ���� �� ������
        {
            if (hit.collider.gameObject.GetComponent<Cell>()) // �������� ������� ���������� Cell � �������
            {
                if (hit.collider.gameObject.GetComponent<Cell>().BuildTower(tower)) // ������� ��������� ����� �� ������
                {
                    Destroy(gameObject); // ����������� ������� ��������
                }
            }
        }

        transform.SetParent(parentAfterDrag); // ������� ������� � ����������� ��������
        image.raycastTarget = true; // ��������� ����������� �������������� � ������������
    }

    public void OnBeginDrag(PointerEventData eventData) // ���������� ������ ���������� IBeginDragHandler
    {
        ItemBeginDrag(); // ����� ������ ������ �������������� ��������
    }

    public void OnDrag(PointerEventData eventData) // ���������� ������ ���������� IDragHandler
    {
        ItemDrag(); // ����� ������ �������������� ��������
    }

    public void OnEndDrag(PointerEventData eventData) // ���������� ������ ���������� IEndDragHandler
    {
        ItemEndDrug(); // ����� ������ ���������� �������������� ��������
    }
}
