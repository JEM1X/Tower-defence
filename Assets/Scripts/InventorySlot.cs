using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    InventoryManager IM;

    public void Start()
    {
        IM = FindObjectOfType<InventoryManager>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        InventoryItem DraggedItem = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = DraggedItem;
            inventoryItem.parentAfterDrag = transform;
            Debug.Log(eventData.pointerDrag);
            return;
        }
        GameObject child = transform.GetChild(0).gameObject;
        InventoryItem childclass = child.GetComponent<InventoryItem>();
        Debug.Log(DraggedItem.tower.ID % 3);
        if (DraggedItem.tower.ID % 3 != 0)
        {
            if (DraggedItem.tower == transform.GetChild(0).GetComponent<InventoryItem>().tower)
            {
                Destroy(child);
                IM.AddItemToSlot(IM.GetTower(DraggedItem.tower.ID + 1), this.GetComponent<InventorySlot>());
                Destroy(eventData.pointerDrag);

            }
        }    
            
    }
}
