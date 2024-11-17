using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ShopInventoryController
{
    public ShopInventoryModel model { get; private set; }
    private ShopInventoryView view;

    private Dictionary<TradableItemSO, TradableItemController> itemControllers = new Dictionary<TradableItemSO, TradableItemController>();

    public Action<TradableItemSO> OnItemSelected;
    public ShopInventoryController(ShopInventoryModel shopInventoryModel, ShopInventoryView shopInventoryView)
    {
        model = shopInventoryModel;
        view = shopInventoryView;

        foreach (var item in model.items)
        {
            itemControllers.TryAdd(item.Key, CreateItemController(item.Key, item.Value));
        };
    }

    private TradableItemController CreateItemController(TradableItemSO itemSO, int initialQuantity)
    {
        TradableItemView itemView = view.CreateItemView();
        TradableItemModel itemModel = new TradableItemModel(itemSO, initialQuantity);
        TradableItemController itemController = new TradableItemController(itemModel, itemView);

        itemController.OnItemSelected += RelayItemClickEvent;

        return itemController;
    }

    private void DestroyItemController(TradableItemSO itemSO)
    {
        TradableItemController controller = itemControllers[itemSO];

        if (controller != null)
        {
            controller.OnItemSelected -= RelayItemClickEvent;
            itemControllers.Remove(itemSO);

            controller.DestroyModelView();
            controller = null;
        }
    }

    public void AddItem(TradableItemSO itemSO, int quantity)
    {
        //check if item type already exists model
        //and add in view if item is totally new
        if (!model.items.ContainsKey(itemSO))
        {
            itemControllers.TryAdd(itemSO, CreateItemController(itemSO, quantity));
        }
        model.AddItem(itemSO, quantity);
        itemControllers[itemSO].setItemQuantity(model.items[itemSO]);
    }

    public void RemoveItem(TradableItemSO itemSO, int amount)
    {
        model.RemoveItem(itemSO, amount);
        if (model.items.ContainsKey(itemSO))
            itemControllers[itemSO].setItemQuantity(model.items[itemSO]);
        else
        {
            //if item does not have any quantity left, remove it 
            DestroyItemController(itemSO);
        }
    }

    public void ShowInventory()
    {
        view.DisplayInventoryView();
    }

    public void RelayItemClickEvent(TradableItemSO itemSO)
    {
        OnItemSelected?.Invoke(itemSO);
    }
}