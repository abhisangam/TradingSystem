using System;
using System.Data;
using UnityEngine;

public class TradableItemController
{
    private TradableItemView view;
    private TradableItemModel model;

    public Action<TradableItemSO> OnItemSelected;
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
        OnItemSelected?.Invoke(this.model.tradableItemSO);
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

    public void DestroyModelView()
    {
        GameObject.Destroy(view.gameObject);
        model = null;
    }

    public void SetViewVisible(bool visible)
    {
        view.gameObject.SetActive(visible);
    }
    ~TradableItemController()
    {
        this.view.OnItemClicked -= OnItemClicked;
        this.view.OnItemHovered -= OnItemHovered;
        this.view.OnItemHoverExited -= OnItemHoverExited;

        GameObject.Destroy(view.gameObject);

        model = null;
        view = null;

        Debug.Log("THIS BLOODY CONTROLLER IS DESTROYED NOW");
    }
}