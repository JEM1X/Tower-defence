using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject ItemPrefab;
    public MasterTower[] towerarr;

   public bool AddItemToFreeSlot(MasterTower tower)
    {
        InventorySlot slot = GetFreeSlot();
            if (slot != null)
            {
                AddItemToSlot(tower, slot);
                return true;
            }
        
        return false;
    }

    public InventorySlot GetFreeSlot()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem iteminslot = slot.GetComponentInChildren<InventoryItem>();
            if (iteminslot == null)
            {
                return slot;
            }
        }
        return null;
    }

    public void AddItemToSlot(MasterTower tower, InventorySlot slot)
    {
        GameObject newitemobject = Instantiate(ItemPrefab, slot.transform);
        InventoryItem NewInvItem = newitemobject.GetComponent<InventoryItem>();
        NewInvItem.InitialiseMasterTowerItem(tower);
    }

    public MasterTower GetTower(int ID)
    {
        return towerarr[ID - 1];
    }
}
