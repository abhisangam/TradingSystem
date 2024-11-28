using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventoryController : InventoryController
{   
    public ShopInventoryController(ShopInventoryModel shopInventoryModel, ShopInventoryView shopInventoryView): base(shopInventoryModel, shopInventoryView)
    {
        shopInventoryView.OnFilterItem += OnFilterItem;
    }    

    private void OnFilterItem(TradableItemFilterOption type)
    {
        foreach (TradableItemController itemControler in itemControllers.Values)
        {
            if(type == TradableItemFilterOption.All)
            {
                itemControler.SetViewVisible(true);
                continue;
            }

            if (itemControler.GetItemType() == filterTypeToItemType(type))
            {
                itemControler.SetViewVisible(true);
            }
            else
            {
                itemControler.SetViewVisible(false);
            }
        }
    }

    private TradableItemType filterTypeToItemType(TradableItemFilterOption type)
    {
        switch (type)
        {
            case TradableItemFilterOption.Consumable:
                return TradableItemType.Consumable;
            case TradableItemFilterOption.Material:
                return TradableItemType.Material;
            case TradableItemFilterOption.Weapon:
                return TradableItemType.Weapon;
            case TradableItemFilterOption.Treasure:
                return TradableItemType.Treasure;
            default:
                return TradableItemType.Consumable;
        }
    }

    ~ShopInventoryController()
    {
        ((ShopInventoryView)view).OnFilterItem -= OnFilterItem;
    }
}