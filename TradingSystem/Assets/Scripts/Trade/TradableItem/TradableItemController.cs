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
        this.view.SetController(this);

        this.view.OnItemClicked += OnItemClicked;
    }
    private void OnItemClicked()
    {
        Debug.Log("Item clicked");
        OnItemSelected?.Invoke(this.model.tradableItemSO);
    }

    public void setItemQuantity(int quantity)
    {
        model.quantity = quantity;
        view.SetQuantityText(quantity);
    }

    public TradableItemSO GetItemSO()
    {
        return this.model.tradableItemSO;
    }

    public TradableItemType GetItemType()
    {
        return this.model.tradableItemSO.type;
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