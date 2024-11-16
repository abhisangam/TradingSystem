using System;
using UnityEngine;

public class TradableItemController
{
    public TradableItemView view { get; private set; }
    public TradableItemModel model { get; private set; }

    public Action<TradableItemController> OnItemSelected;
    public TradableItemController(TradableItemModel model, TradableItemView view)
    {
        this.view = view;
        this.model = model;

        this.view.SetIconSprite(model.icon);

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
        view.SetQuantityText(quantity);
    }
    public void setItemSprite(Sprite icon)
    {
        view.SetIconSprite(icon);
    }
}