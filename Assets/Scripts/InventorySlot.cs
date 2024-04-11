using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler // Объявление класса InventorySlot, который наследуется от MonoBehaviour и реализует интерфейс IDropHandler
{
    InventoryManager IM; // Поле для ссылки на менеджер инвентаря

    public void Start() // Метод Start, вызывается при старте объекта
    {
        IM = FindObjectOfType<InventoryManager>(); // Нахождение и присвоение ссылки на менеджер инвентаря
    }

    public void OnDrop(PointerEventData eventData) // Метод обработки события "перетаскивание и отпускание" на этот объект
    {
        InventoryItem DraggedItem = eventData.pointerDrag.GetComponent<InventoryItem>(); // Получение предмета, который был перетащен

        if (transform.childCount == 0) // Проверка, что в слоте нет других предметов
        {
            InventoryItem inventoryItem = DraggedItem; // Присваивание перетаскиваемого предмета к текущему слоту
            inventoryItem.parentAfterDrag = transform; // Установка родителя для предмета после перетаскивания
            return; // Выход из метода
        }

        GameObject child = transform.GetChild(0).gameObject; // Получение первого дочернего объекта слота
        InventoryItem childclass = child.GetComponent<InventoryItem>(); // Получение компонента InventoryItem из дочернего объекта

        if (DraggedItem.tower.ID % 3 != 0) // Проверка условия по ID предмета
        {
            if (DraggedItem.tower == transform.GetChild(0).GetComponent<InventoryItem>().tower) // Проверка на совпадение типов предметов
            {
                Destroy(child); // Уничтожение дочернего объекта
                IM.AddItemToSlot(IM.GetTower(DraggedItem.tower.ID + 1), gameObject.GetComponent<InventorySlot>()); // Добавление нового предмета в слот
                Destroy(eventData.pointerDrag); // Уничтожение объекта, который был перетащен
            }
        }
    }
}
