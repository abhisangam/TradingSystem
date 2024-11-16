using UnityEngine;

public class PlayerInventoryController
{
    public PlayerInventoryModel model { get; private set; }
    private PlayerInventoryView view;

    public PlayerInventoryController(PlayerInventoryModel playerInventoryModel, PlayerInventoryView playerInventoryView)
    {
        model = playerInventoryModel;
        view = playerInventoryView;
    }

    public void AddItem(TradableItemSO item, int amount)
    {
        model.AddItem(item, amount);
    }

    public void RemoveItem(TradableItemSO item, int amount)
    {
        model.RemoveItem(item, amount);
    }

    public void ShowInventory()
    {
        foreach (var item in model.items)
        {
            TradableItemView itemView = view.CreateAndAddItem();
            TradableItemModel itemModel = new TradableItemModel(item.Key, item.Value);
            TradableItemController itemController = new TradableItemController(itemModel, itemView);

            itemController.OnItemSelected += OnItemSelected;
        };
    }

    public void OnItemSelected(TradableItemController itemController)
    {
        Debug.Log("Item selected: " + itemController.view.name);
    }
}