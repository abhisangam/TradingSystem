using System;
using UnityEngine;

public class TradableItemController
{
    private TradableItemView view;
    private TradableItemModel model;

    public Action<TradableItemController> OnItemSelected;
    public TradableItemController(TradableItemModel model, TradableItemView view)
    {
        this.view = view;
        this.model = model;

        this.view.SetIconSprite(model.icon);
        this.view.SetQuantityText(model.quantity);

        this.view.OnItemClicked += OnItemClicked;
        this.view.OnItemHovered += OnItemHovered;
        this.view.OnItemHoverExited += OnItemHoverExited;
    }
    private void OnItemClicked()
    {
        Debug.Log("Item clicked");
        OnItemSelected?.Invoke(this);
    }

    private void OnItemHovered()
    {
        // Display item info
    }

    private void OnItemHoverExited()
    {
        // Hide item info
    }

    public void setItemQuantity(int quantity)
    {
        model.quantity = quantity;
        view.SetQuantityText(quantity);
    }

    public TradableItemModel getModel()
    {
        return this.model;
    }
}