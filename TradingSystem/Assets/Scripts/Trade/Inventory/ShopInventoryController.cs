using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ShopInventoryController : InventoryController
{   
    public ShopInventoryController(ShopInventoryModel shopInventoryModel, ShopInventoryView shopInventoryView): base(shopInventoryModel, shopInventoryView)
    {
        shopInventoryView.OnFilterItem += OnFilterItem;
    }    

    private void OnFilterItem(TradableItemType type)
    {
        foreach (TradableItemController itemControler in itemControllers.Values)
        {
            if (itemControler.getModel().type == type)
            {
                itemControler.SetViewVisible(true);
            }
            else
            {
                itemControler.SetViewVisible(false);
            }
        }
    }
}