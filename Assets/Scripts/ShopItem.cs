using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour // Объявление класса ShopItem, который наследуется от MonoBehaviour
{
    public MasterTower tower; // Публичное поле для ссылки на объект MasterTower
    public Image image; // Публичное поле для ссылки на компонент Image
    public InventoryManager invman; // Публичное поле для ссылки на объект InventoryManager
    public ResourceManager resman; // Публичное поле для ссылки на объект ResourceManager

    public void Start() // Метод Start, вызывается при старте объекта
    {
        InitialiseShopItem(tower); // Вызов метода InitialiseShopItem с передачей объекта tower в качестве аргумента
    }

    public void InitialiseShopItem(MasterTower tower) // Метод для инициализации элемента магазина
    {
        image.sprite = tower.TowerIcon; // Установка спрайта изображения башни в компонент Image
    }

    public void BuyItem() // Метод для покупки предмета
    {
        if (resman.Gold > resman.TowerCost) // Проверка достаточности золота для покупки
        {
            if (invman.AddItemToFreeSlot(tower)) // Попытка добавить предмет в инвентарь
            {
                resman.BuildTower(); // Построить башню
            }
        }
    }
}
