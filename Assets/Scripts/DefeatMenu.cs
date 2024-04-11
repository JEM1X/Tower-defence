using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefeatMenu : MonoBehaviour // Объявление класса DefeatMenu, который наследуется от MonoBehaviour
{

    public Text goldText; // Публичное поле для текстового элемента, отображающего количество золота
    private ResourceManager resourceManager; // Приватное поле для ссылки на скрипт "ResourceManager"

    void Start() // Метод, вызываемый при старте объекта
    {
        resourceManager = FindObjectOfType<ResourceManager>(); // Нахождение скрипта "ResourceManager" в сцене
    }

    void Update() // Метод, вызываемый каждый кадр
    {
        // Обновляем текстовое поле с количеством золота
        if (resourceManager != null && goldText != null) // Проверка на наличие ссылок на ResourceManager и goldText
        {
            goldText.text = "Gold: " + resourceManager.Gold.ToString(); // Обновление текста в текстовом поле с количеством золота
        }
    }

    public void Replay() // Метод для перезапуска игры
    {
        // Перезапускаем сцену заново
        SceneManager.LoadScene(1); // Загрузка сцены под индексом 1
    }

    public void GoToMainMenu() // Метод для перехода в главное меню
    {
        // Возвращаемся в главное меню
        SceneManager.LoadScene(1); // Загрузка сцены под индексом 1
        SceneManager.LoadScene(0, LoadSceneMode.Additive); // Добавление главной сцены поверх текущей сцены
    }
}
