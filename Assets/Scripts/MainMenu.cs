using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject UIGold;
    private GameObject healthBar;
    private GameObject inventory;
    private GameObject shop;
    private GameObject backpack;

    void Start()
    {
        GameObject canvasObject = GameObject.Find("Canvas");
        if (canvasObject != null)
        {
            Transform canvasTransform = canvasObject.transform;
            UIGold = canvasTransform.Find("UIGold")?.gameObject;
            healthBar = canvasTransform.Find("Health bar")?.gameObject;
            inventory = canvasTransform.Find("MainInventory")?.gameObject;
            shop = canvasTransform.Find("ShopButton")?.gameObject;
            backpack = canvasTransform.Find("BackInventoryButton")?.gameObject;
        }

        if (UIGold != null)
            UIGold.SetActive(false);
        if (healthBar != null)
            healthBar.SetActive(false);
        if (inventory != null)
            inventory.SetActive(false);
        if (shop != null)
            shop.SetActive(false);
        if (backpack != null)
            backpack.SetActive(false);
    }

    public void play()
    {
        if (UIGold != null)
            UIGold.SetActive(true);
        if (healthBar != null)
            healthBar.SetActive(true);
        if (inventory != null)
            inventory.SetActive(true);
        if (shop != null)
            shop.SetActive(true);
        if (backpack != null)
            backpack.SetActive(true);

        SceneManager.LoadScene("GameScene");
    }

    public void Quite()
    {
        Application.Quit();
    }

}
