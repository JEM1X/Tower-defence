using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour // Объявление класса MainMenu, который наследуется от MonoBehaviour
{
    private GameObject UIGold; // Приватное поле для ссылки на объект UIGold
    private GameObject healthBar; // Приватное поле для ссылки на объект healthBar
    private GameObject inventory; // Приватное поле для ссылки на объект inventory
    private GameObject shop; // Приватное поле для ссылки на объект shop
    private GameObject backpack; // Приватное поле для ссылки на объект backpack
    private GameObject castle; // Приватное поле для ссылки на объект castle

    void Start() // Метод Start, вызывается при старте объекта
    {
        GameObject canvasObject = GameObject.Find("Canvas"); // Поиск объекта Canvas в сцене
        if (canvasObject != null) // Проверка, что объект Canvas найден
        {
            Transform canvasTransform = canvasObject.transform; // Получение компонента Transform объекта Canvas
            UIGold = canvasTransform.Find("UIGold")?.gameObject; // Поиск объекта UIGold внутри Canvas и присвоение ссылки
            healthBar = canvasTransform.Find("Health bar")?.gameObject; // Поиск объекта Health bar внутри Canvas и присвоение ссылки
            inventory = canvasTransform.Find("MainInventory")?.gameObject; // Поиск объекта MainInventory внутри Canvas и присвоение ссылки
            shop = canvasTransform.Find("ShopButton")?.gameObject; // Поиск объекта ShopButton внутри Canvas и присвоение ссылки
            backpack = canvasTransform.Find("BackInventoryButton")?.gameObject; // Поиск объекта BackInventoryButton внутри Canvas и присвоение ссылки
        }

        if (UIGold != null)
            UIGold.SetActive(false); // Отключение объекта UIGold
        if (healthBar != null)
            healthBar.SetActive(false); // Отключение объекта healthBar
        if (inventory != null)
            inventory.SetActive(false); // Отключение объекта inventory
        if (shop != null)
            shop.SetActive(false); // Отключение объекта shop
        if (backpack != null)
            backpack.SetActive(false); // Отключение объекта backpack   

        castle = GameObject.Find("Castle"); // Поиск объекта Castle в сцене

        if (castle != null)
        {
            castle.SetActive(false); // Отключение объекта castle
        }
    }

    public void play() // Метод для обработки нажатия на кнопку Play
    {
        if (UIGold != null)
            UIGold.SetActive(true); // Включение объекта UIGold
        if (healthBar != null)
            healthBar.SetActive(true); // Включение объекта healthBar
        if (inventory != null)
            inventory.SetActive(true); // Включение объекта inventory
        if (shop != null)
            shop.SetActive(true); // Включение объекта shop
        if (backpack != null)
            backpack.SetActive(true); // Включение объекта backpack
        if (castle != null)
        {
            castle.SetActive(true); // Включение объекта castle
        }

        SceneManager.LoadScene(1); // Загрузка сцены с индексом 1
    }

    public void Quite() // Метод для выхода из игры
    {
        Application.Quit(); // Выход из приложения
    }
}
