using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler // Объявление класса InventoryItem, который наследуется от MonoBehaviour и интерфейсов IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")] // Заголовок для полей в инспекторе
    public Image image; // Публичное поле для изображения
    public MasterTower tower; // Публичное поле для объекта MasterTower

    [HideInInspector] public Transform parentAfterDrag; // Скрытое поле для хранения родителя после перетаскивания

    public void Start() // Метод, вызываемый при старте объекта
    {
        InitialiseMasterTowerItem(tower); // Вызов метода для инициализации объекта MasterTower
    }

    public void InitialiseMasterTowerItem(MasterTower newtower) // Метод для инициализации объекта MasterTower
    {
        tower = newtower; // Присваивание нового объекта MasterTower
        image.sprite = newtower.TowerIcon; // Установка спрайта изображения объекта MasterTower
        transform.GetChild(0).gameObject.GetComponent<Text>().text = (tower.ID % 3).ToString(); // Получение дочернего объекта и установка текста

        if (tower.ID % 3 == 0) // Проверка условия
        {
            transform.GetChild(0).gameObject.GetComponent<Text>().text = 3.ToString(); // Установка текста равного 3
        }
    }

    public void ItemBeginDrag() // Метод начала перетаскивания предмета
    {
        parentAfterDrag = transform.parent; // Сохранение родителя до перетаскивания
        transform.SetParent(transform.root); // Установка родителя на корневой объект
        transform.SetAsLastSibling(); // Помещение объекта поверх остальных
        image.raycastTarget = false; // Отключение возможности взаимодействия с изображением
    }

    public void ItemDrag() // Метод перетаскивания предмета
    {
        transform.position = Input.mousePosition; // Установка позиции объекта по позиции мыши
    }

    public void ItemEndDrug() // Метод завершения перетаскивания предмета
    {
        RaycastHit hit; // Переменная для хранения информации о попадании луча
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Создание луча от камеры к позиции мыши

        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // Проверка попадания луча на объект
        {
            if (hit.collider.gameObject.GetComponent<Cell>()) // Проверка наличия компонента Cell у объекта
            {
                if (hit.collider.gameObject.GetComponent<Cell>().BuildTower(tower)) // Попытка построить башню на клетке
                {
                    Destroy(gameObject); // Уничтожение объекта предмета
                }
            }
        }

        transform.SetParent(parentAfterDrag); // Возврат объекта к предыдущему родителю
        image.raycastTarget = true; // Включение возможности взаимодействия с изображением
    }

    public void OnBeginDrag(PointerEventData eventData) // Реализация метода интерфейса IBeginDragHandler
    {
        ItemBeginDrag(); // Вызов метода начала перетаскивания предмета
    }

    public void OnDrag(PointerEventData eventData) // Реализация метода интерфейса IDragHandler
    {
        ItemDrag(); // Вызов метода перетаскивания предмета
    }

    public void OnEndDrag(PointerEventData eventData) // Реализация метода интерфейса IEndDragHandler
    {
        ItemEndDrug(); // Вызов метода завершения перетаскивания предмета
    }
}
