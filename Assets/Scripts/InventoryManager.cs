using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour // Объявление класса InventoryManager, который наследуется от MonoBehaviour
{
    public InventorySlot[] inventorySlots; // Публичное поле массива слотов инвентаря
    public GameObject ItemPrefab; // Публичное поле для префаба предмета
    public MasterTower[] towerarr; // Публичное поле массива объектов MasterTower

    public bool AddItemToFreeSlot(MasterTower tower) // Метод для добавления предмета в свободный слот инвентаря
    {
        InventorySlot slot = GetFreeSlot(); // Получение свободного слота
        if (slot != null) // Проверка наличия свободного слота
        {
            AddItemToSlot(tower, slot); // Добавление предмета в слот
            return true; // Возвращение успешного результата
        }

        return false; // Возвращение неудачного результата
    }

    public InventorySlot GetFreeSlot() // Метод для получения свободного слота
    {
        for (int i = 0; i < inventorySlots.Length; i++) // Цикл по всем слотам инвентаря
        {
            InventorySlot slot = inventorySlots[i]; // Получение текущего слота
            InventoryItem iteminslot = slot.GetComponentInChildren<InventoryItem>(); // Получение предмета в слоте
            if (iteminslot == null) // Проверка наличия предмета в слоте
            {
                return slot; // Возвращение свободного слота
            }
        }
        return null; // Возвращение null, если свободный слот не найден
    }

    public void AddItemToSlot(MasterTower tower, InventorySlot slot) // Метод для добавления предмета в указанный слот
    {
        GameObject newitemobject = Instantiate(ItemPrefab, slot.transform); // Создание нового объекта предмета в указанном слоте
        InventoryItem NewInvItem = newitemobject.GetComponent<InventoryItem>(); // Получение компонента InventoryItem из нового объекта
        NewInvItem.InitialiseMasterTowerItem(tower); // Инициализация нового объекта предмета с переданным объектом MasterTower
    }

    public MasterTower GetTower(int ID) // Метод для получения объекта MasterTower по ID
    {
        return towerarr[ID - 1]; // Возвращение объекта MasterTower из массива по указанному ID
    }
}
