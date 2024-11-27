using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel
{
    public Dictionary<TradableItemSO, int> items;

    private int totalWeight;
    public int TotalWeight { 
        get { return totalWeight; }
        set { totalWeight = value; }
    }

    private int inventoryMaxWeight;
    public int InventoryMaxWeight
    {
        get { return inventoryMaxWeight; }
        set { inventoryMaxWeight = value; }
    }

    public InventoryModel(int maxWeight)
    {
        Debug.Log("Inventory created");
        items = new Dictionary<TradableItemSO, int>();
        totalWeight = 0;
        inventoryMaxWeight = maxWeight;
    }

    public void AddItem(TradableItemSO item, int amount)
    {
        if (items.ContainsKey(item))
        {
            items[item] += amount;
            totalWeight += item.weight * amount;
        }
        else
        {
            items.Add(item, amount);
            totalWeight += item.weight * amount;
        }
    }

    public void RemoveItem(TradableItemSO item, int amount)
    {
        if (items.ContainsKey(item))
        {
            items[item] -= amount;
            totalWeight -= item.weight * amount;

            if (items[item] <= 0)
            {
                items.Remove(item);
            }
        }
    }

    public int GetItemCount(TradableItemSO item)
    {
        if (items.ContainsKey(item))
            return items[item];
        else
            return 0;
    }
}
