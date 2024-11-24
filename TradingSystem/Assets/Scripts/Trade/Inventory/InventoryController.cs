using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryController
{
    protected InventoryModel model;
    public InventoryModel Model { get { return model; } }
    protected InventoryView view;

    protected Dictionary<TradableItemSO, TradableItemController> itemControllers = new Dictionary<TradableItemSO, TradableItemController>();

    public Action<TradableItemSO> OnItemSelected; 
    public InventoryController(InventoryModel inventoryModel, InventoryView inventoryView)
    {
        model = inventoryModel;
        view = inventoryView;

        foreach (var item in model.items)
        {
            itemControllers.TryAdd(item.Key, CreateItemController(item.Key, item.Value));
        };

        view.SetController(this);
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
        //Check if there is space in inventory
        if(itemSO.weight * quantity + model.totalWeight > model.GetMaxWeight())
        {
            //TO DO: Display message that inventory is full
            Debug.LogError("Inventory is full");
            return;
        }
        //check if item type already exists model
        //and add in view if item is totally new
        if (!model.items.ContainsKey(itemSO))
        {
            itemControllers.Add(itemSO, CreateItemController(itemSO, quantity));
        }
        model.AddItem(itemSO, quantity);
        itemControllers[itemSO].setItemQuantity(model.items[itemSO]);
    }

    public void RemoveItem(TradableItemSO itemSO, int amount)
    {
        model.RemoveItem(itemSO, amount);
        if(model.items.ContainsKey(itemSO))
            itemControllers[itemSO].setItemQuantity(model.items[itemSO]);
        else
        {
            //if item does not have any quantity left, remove it from the view and destroy the controller
            DestroyItemController(itemSO);
        }
    }

    public void RelayItemClickEvent(TradableItemSO itemSO)
    {
        OnItemSelected?.Invoke(itemSO);
    }

    public int GetItemQuantity(TradableItemSO itemSO)
    {
        return model.items[itemSO];
    }

    public int GetInventoryWeight()
    {
        return model.GetTotalWeight();
    }

    public int GetInventoryMaxWeight()
    {
        return model.GetMaxWeight();
    }
}