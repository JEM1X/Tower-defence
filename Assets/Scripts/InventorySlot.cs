using System.Collections;
using System. Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{ 
    public void OnDrop(PointerEventData eventData)
    {
        Transform child = transform.GetChild(0);
        InventoryItem childclass = child.GetComponent<InventoryItem>();
        if (child == null)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
            Debug.Log(eventData.pointerDrag);
        }
        if (eventData.pointerDrag.GetComponent<InventoryItem>().tower == childclass.tower) 
        {
            Debug.Log("смешать");
        }
    }
}
