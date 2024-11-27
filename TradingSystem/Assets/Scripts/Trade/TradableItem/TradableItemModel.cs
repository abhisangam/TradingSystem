using UnityEngine;

public class TradableItemModel
{   
    private int quantity;
    public int Quantity 
    {
        get { return quantity; } 
        set { quantity = value; } 
    }
    private TradableItemSO tradableItemSO;
    public TradableItemSO TradableItemSO { get { return tradableItemSO; } }

    public TradableItemModel(TradableItemSO tradableItemSO, int quantity)
    {
        this.tradableItemSO = tradableItemSO;
        this.quantity = quantity;

    }
}