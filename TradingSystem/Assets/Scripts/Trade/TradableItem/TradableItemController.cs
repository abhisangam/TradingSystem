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

        this.view.SetIconSprite(model.TradableItemSO.icon);
        this.view.SetQuantityText(model.Quantity);
        this.view.SetController(this);

        this.view.OnItemClicked += OnItemClicked;
    }
    private void OnItemClicked()
    {
        Debug.Log("Item clicked");
        OnItemSelected?.Invoke(this.model.TradableItemSO);
    }

    public void setItemQuantity(int quantity)
    {
        model.Quantity = quantity;
        view.SetQuantityText(quantity);
    }

    public TradableItemSO GetItemSO()
    {
        return this.model.TradableItemSO;
    }

    public TradableItemType GetItemType()
    {
        return this.model.TradableItemSO.type;
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

        GameObject.Destroy(view.gameObject);

        model = null;
        view = null;
    }
}