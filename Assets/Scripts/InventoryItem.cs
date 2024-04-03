using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;
    public ScriptableObject Tower;

    [HideInInspector] public Transform parentAfterDrag;
    public void Start()
    {
       // GetComponent<Image>().sprite = Tower.BaseTower.TowerIcon;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData) 
    {
        Debug.Log("drag");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
