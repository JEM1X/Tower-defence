using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour // Объявление класса StartGame, который наследуется от MonoBehaviour
{
    public GameObject castleObject; // Публичное поле для объекта замка

    void Start() // Метод Start, который вызывается при запуске сцены
    {
        if (castleObject != null) // Проверка наличия объекта замка
        {
            castleObject.SetActive(true); // Включение объекта замка
        }
    }
}
