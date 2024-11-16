using UnityEditor;
using UnityEngine;

public enum TradableItemType
{
    Material,
    Weapon,
    Consumable,
    Treasure
}

public enum TradableItemRarity
{
    VeryCommon,
    Common,
    Rare,
    Epic,
    Legendary
}

[CreateAssetMenu(fileName = "NewTradableItem", menuName = "Trading/TradableItem")]
public class TradableItemSO: ScriptableObject
{
    public TradableItemType type;
    public string description;

    public Sprite icon;

    public int buyingPrice;
    public int sellingPrice;

    public int weight;
    public TradableItemRarity rarity;

    //Quantity will always be used from the inventory
}