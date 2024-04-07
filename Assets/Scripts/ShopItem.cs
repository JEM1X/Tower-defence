using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public MasterTower tower;
    public Image image;
    public InventoryManager invman;
    public ResourceManager resman;

    public void Start()
    {
        InitialiseShopItem(tower);
    }
    public void InitialiseShopItem(MasterTower tower)
    {
        image.sprite = tower.TowerIcon;
    }

    public void BuyItem()
    {
        if (resman.Gold > resman.TowerCost)
        {
            if (invman.AddItemToFreeSlot(tower))
            {
                resman.BuildTower();
            }
        }
         
    }

}
