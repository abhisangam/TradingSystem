using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public Dictionary<TradableItemSO, int> items;

    public int totalWeight;
    private int inventoryMaxWeight;

    public Inventory(int maxWeight)
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

    public void SetInventoryMaxWeight(int maxWeight)
    {
        if (maxWeight < totalWeight)
        {
            //raise error
            Debug.LogError("Max weight you are trying to set is less than current total weight");
        }

        //Setting max weight any way, handling it is not the scope of this project
        inventoryMaxWeight = maxWeight;
    }

    public int GetTotalWeight()
    {
        return totalWeight;
    }

    public int GetMaxWeight()
    {
        return inventoryMaxWeight;
    }
}
