public class PlayerInventoryModel : Inventory
{
    public override void AddItem(TradableItemSO item, int amount)
    {
        if (items.ContainsKey(item))
            items[item] += amount;
        else
            items.Add(item, amount);
    }

    public override void RemoveItem(TradableItemSO item, int amount)
    {
        if (items.ContainsKey(item))
            items[item] -= amount;
    }
}   