using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour // ���������� ������ ShopItem, ������� ����������� �� MonoBehaviour
{
    public MasterTower tower; // ��������� ���� ��� ������ �� ������ MasterTower
    public Image image; // ��������� ���� ��� ������ �� ��������� Image
    public InventoryManager invman; // ��������� ���� ��� ������ �� ������ InventoryManager
    public ResourceManager resman; // ��������� ���� ��� ������ �� ������ ResourceManager

    public void Start() // ����� Start, ���������� ��� ������ �������
    {
        InitialiseShopItem(tower); // ����� ������ InitialiseShopItem � ��������� ������� tower � �������� ���������
    }

    public void InitialiseShopItem(MasterTower tower) // ����� ��� ������������� �������� ��������
    {
        image.sprite = tower.TowerIcon; // ��������� ������� ����������� ����� � ��������� Image
    }

    public void BuyItem() // ����� ��� ������� ��������
    {
        if (resman.Gold > resman.TowerCost) // �������� ������������� ������ ��� �������
        {
            if (invman.AddItemToFreeSlot(tower)) // ������� �������� ������� � ���������
            {
                resman.BuildTower(); // ��������� �����
            }
        }
    }
}
