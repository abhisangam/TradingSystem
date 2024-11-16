using UnityEngine;

public class PlayerInventoryController
{
    public PlayerInventoryModel model { get; private set; }
    private PlayerInventoryView view;

    public PlayerInventoryController(PlayerInventoryModel playerInventoryModel, PlayerInventoryView playerInventoryView)
    {
        model = playerInventoryModel;
        view = playerInventoryView;

        foreach (var item in model.items)
        {
            TradableItemView itemView = view.CreateAndAddItem();
            TradableItemModel itemModel = new TradableItemModel(item.Key, item.Value);
            TradableItemController itemController = new TradableItemController(itemModel, itemView);

            itemController.OnItemSelected += OnItemSelected;
        };
    }

    public void AddItem(TradableItemSO item, int amount)
    {
        //check if item type already exists model
        //and add in view if item is totally new
        if(!model.items.ContainsKey(item))
        {
            TradableItemView itemView = view.CreateAndAddItem();
            TradableItemModel itemModel = new TradableItemModel(item, amount);
            TradableItemController itemController = new TradableItemController(itemModel, itemView);

            itemController.OnItemSelected += OnItemSelected;
        }
        model.AddItem(item, amount);
    }

    public void RemoveItem(TradableItemSO item, int amount)
    {
        model.RemoveItem(item, amount);
        //if item does not have any quantity left, remove it from view
        if (model.GetItemCount(item) == 0)
        {
            //remove item from view
            
        }
    }

    public void ShowInventory()
    {
        view.DisplayInventoryView();
    }

    public void OnItemSelected(TradableItemController itemController)
    {
        Debug.Log("Item selected: " + itemController.getModel().name);
        view.getTradableItemInfoPopupController().Show(itemController.getModel(), true);
    }
}