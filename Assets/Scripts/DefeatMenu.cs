using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefeatMenu : MonoBehaviour
{

    public Text goldText;
    private ResourceManager resourceManager;

    void Start()
    {   
        resourceManager = FindObjectOfType<ResourceManager>();
    }

    void Update()
    {
        // Обновляем текстовое поле с количеством золота
        if (resourceManager != null && goldText != null)
        {
            goldText.text = "Gold: " + resourceManager.Gold.ToString();
        }
    }
    public void Replay()
    {
        // Перезапускаем сцену заново
        SceneManager.LoadScene(1);
    }

    public void GoToMainMenu()
    {
        // Возвращаемся в главное меню
        SceneManager.LoadScene(1);
        SceneManager.LoadScene(0, LoadSceneMode.Additive);

    }
}
