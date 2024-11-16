using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory
{
    public Dictionary<TradableItemSO, int> items;

    public Inventory()
    {
        Debug.Log("Inventory created");
        items = new Dictionary<TradableItemSO, int>();
    }

    public abstract void AddItem(TradableItemSO item, int amount);
    public abstract void RemoveItem(TradableItemSO item, int amount);
}
