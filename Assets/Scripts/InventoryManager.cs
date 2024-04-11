using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour // ���������� ������ InventoryManager, ������� ����������� �� MonoBehaviour
{
    public InventorySlot[] inventorySlots; // ��������� ���� ������� ������ ���������
    public GameObject ItemPrefab; // ��������� ���� ��� ������� ��������
    public MasterTower[] towerarr; // ��������� ���� ������� �������� MasterTower

    public bool AddItemToFreeSlot(MasterTower tower) // ����� ��� ���������� �������� � ��������� ���� ���������
    {
        InventorySlot slot = GetFreeSlot(); // ��������� ���������� �����
        if (slot != null) // �������� ������� ���������� �����
        {
            AddItemToSlot(tower, slot); // ���������� �������� � ����
            return true; // ����������� ��������� ����������
        }

        return false; // ����������� ���������� ����������
    }

    public InventorySlot GetFreeSlot() // ����� ��� ��������� ���������� �����
    {
        for (int i = 0; i < inventorySlots.Length; i++) // ���� �� ���� ������ ���������
        {
            InventorySlot slot = inventorySlots[i]; // ��������� �������� �����
            InventoryItem iteminslot = slot.GetComponentInChildren<InventoryItem>(); // ��������� �������� � �����
            if (iteminslot == null) // �������� ������� �������� � �����
            {
                return slot; // ����������� ���������� �����
            }
        }
        return null; // ����������� null, ���� ��������� ���� �� ������
    }

    public void AddItemToSlot(MasterTower tower, InventorySlot slot) // ����� ��� ���������� �������� � ��������� ����
    {
        GameObject newitemobject = Instantiate(ItemPrefab, slot.transform); // �������� ������ ������� �������� � ��������� �����
        InventoryItem NewInvItem = newitemobject.GetComponent<InventoryItem>(); // ��������� ���������� InventoryItem �� ������ �������
        NewInvItem.InitialiseMasterTowerItem(tower); // ������������� ������ ������� �������� � ���������� �������� MasterTower
    }

    public MasterTower GetTower(int ID) // ����� ��� ��������� ������� MasterTower �� ID
    {
        return towerarr[ID - 1]; // ����������� ������� MasterTower �� ������� �� ���������� ID
    }
}
