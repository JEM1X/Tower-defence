using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour // ���������� ������ MainMenu, ������� ����������� �� MonoBehaviour
{
    private GameObject UIGold; // ��������� ���� ��� ������ �� ������ UIGold
    private GameObject healthBar; // ��������� ���� ��� ������ �� ������ healthBar
    private GameObject inventory; // ��������� ���� ��� ������ �� ������ inventory
    private GameObject shop; // ��������� ���� ��� ������ �� ������ shop
    private GameObject backpack; // ��������� ���� ��� ������ �� ������ backpack
    private GameObject castle; // ��������� ���� ��� ������ �� ������ castle

    void Start() // ����� Start, ���������� ��� ������ �������
    {
        GameObject canvasObject = GameObject.Find("Canvas"); // ����� ������� Canvas � �����
        if (canvasObject != null) // ��������, ��� ������ Canvas ������
        {
            Transform canvasTransform = canvasObject.transform; // ��������� ���������� Transform ������� Canvas
            UIGold = canvasTransform.Find("UIGold")?.gameObject; // ����� ������� UIGold ������ Canvas � ���������� ������
            healthBar = canvasTransform.Find("Health bar")?.gameObject; // ����� ������� Health bar ������ Canvas � ���������� ������
            inventory = canvasTransform.Find("MainInventory")?.gameObject; // ����� ������� MainInventory ������ Canvas � ���������� ������
            shop = canvasTransform.Find("ShopButton")?.gameObject; // ����� ������� ShopButton ������ Canvas � ���������� ������
            backpack = canvasTransform.Find("BackInventoryButton")?.gameObject; // ����� ������� BackInventoryButton ������ Canvas � ���������� ������
        }

        if (UIGold != null)
            UIGold.SetActive(false); // ���������� ������� UIGold
        if (healthBar != null)
            healthBar.SetActive(false); // ���������� ������� healthBar
        if (inventory != null)
            inventory.SetActive(false); // ���������� ������� inventory
        if (shop != null)
            shop.SetActive(false); // ���������� ������� shop
        if (backpack != null)
            backpack.SetActive(false); // ���������� ������� backpack   

        castle = GameObject.Find("Castle"); // ����� ������� Castle � �����

        if (castle != null)
        {
            castle.SetActive(false); // ���������� ������� castle
        }
    }

    public void play() // ����� ��� ��������� ������� �� ������ Play
    {
        if (UIGold != null)
            UIGold.SetActive(true); // ��������� ������� UIGold
        if (healthBar != null)
            healthBar.SetActive(true); // ��������� ������� healthBar
        if (inventory != null)
            inventory.SetActive(true); // ��������� ������� inventory
        if (shop != null)
            shop.SetActive(true); // ��������� ������� shop
        if (backpack != null)
            backpack.SetActive(true); // ��������� ������� backpack
        if (castle != null)
        {
            castle.SetActive(true); // ��������� ������� castle
        }

        SceneManager.LoadScene(1); // �������� ����� � �������� 1
    }

    public void Quite() // ����� ��� ������ �� ����
    {
        Application.Quit(); // ����� �� ����������
    }
}
