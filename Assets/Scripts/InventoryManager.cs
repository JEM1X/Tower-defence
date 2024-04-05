using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject ItemPrefab;
    public ScriptableObject DraggedItem;
   public bool AddItemToFreeSlot(MasterTower tower)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem iteminslot = slot.GetComponentInChildren<InventoryItem>();
            if (iteminslot == null)
            {
                AddItemToSlot(tower, slot);
                return true;
            }
        }
        return false;
    }

    public void AddItemToSlot(MasterTower tower, InventorySlot slot)
    {
        GameObject newitemobject = Instantiate(ItemPrefab, slot.transform);
        InventoryItem NewInvItem = newitemobject.GetComponent<InventoryItem>();
        NewInvItem.InitialiseMasterTowerItem(tower);
    }
}
