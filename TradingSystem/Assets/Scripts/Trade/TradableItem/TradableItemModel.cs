using UnityEngine;

public class TradableItemModel
{
    public string name;
    public TradableItemType type;
    public string description;

    public Sprite icon;

    public int buyingPrice;
    public int sellingPrice;

    public int weight;
    public TradableItemRarity rarity;

    public int quantity;

    public TradableItemSO tradableItemSO { get; private set; }

    public TradableItemModel(TradableItemSO tradableItemSO, int quantity)
    {
        this.name = tradableItemSO.name;
        this.type = tradableItemSO.type;
        this.description = tradableItemSO.description;
        this.icon = tradableItemSO.icon;
        this.buyingPrice = tradableItemSO.buyingPrice;
        this.sellingPrice = tradableItemSO.sellingPrice;
        this.weight = tradableItemSO.weight;
        this.rarity = tradableItemSO.rarity;

        this.tradableItemSO = tradableItemSO;
        this.quantity = quantity;

    }
}