using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler // ���������� ������ InventorySlot, ������� ����������� �� MonoBehaviour � ��������� ��������� IDropHandler
{
    InventoryManager IM; // ���� ��� ������ �� �������� ���������

    public void Start() // ����� Start, ���������� ��� ������ �������
    {
        IM = FindObjectOfType<InventoryManager>(); // ���������� � ���������� ������ �� �������� ���������
    }

    public void OnDrop(PointerEventData eventData) // ����� ��������� ������� "�������������� � ����������" �� ���� ������
    {
        InventoryItem DraggedItem = eventData.pointerDrag.GetComponent<InventoryItem>(); // ��������� ��������, ������� ��� ���������

        if (transform.childCount == 0) // ��������, ��� � ����� ��� ������ ���������
        {
            InventoryItem inventoryItem = DraggedItem; // ������������ ���������������� �������� � �������� �����
            inventoryItem.parentAfterDrag = transform; // ��������� �������� ��� �������� ����� ��������������
            return; // ����� �� ������
        }

        GameObject child = transform.GetChild(0).gameObject; // ��������� ������� ��������� ������� �����
        InventoryItem childclass = child.GetComponent<InventoryItem>(); // ��������� ���������� InventoryItem �� ��������� �������

        if (DraggedItem.tower.ID % 3 != 0) // �������� ������� �� ID ��������
        {
            if (DraggedItem.tower == transform.GetChild(0).GetComponent<InventoryItem>().tower) // �������� �� ���������� ����� ���������
            {
                Destroy(child); // ����������� ��������� �������
                IM.AddItemToSlot(IM.GetTower(DraggedItem.tower.ID + 1), gameObject.GetComponent<InventorySlot>()); // ���������� ������ �������� � ����
                Destroy(eventData.pointerDrag); // ����������� �������, ������� ��� ���������
            }
        }
    }
}
