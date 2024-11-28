using System;
using UnityEngine;
using UnityEngine.UI;

public enum TradableItemFilterOption
{
    All,
    Material,
    Weapon,
    Consumable,
    Treasure
}
public class ShopInventoryView : InventoryView
{
    [SerializeField] private ItemFilterToggle[] itemTypeFilterButtons;

    public Action<TradableItemFilterOption> OnFilterItem;
    private new void Start()
    {
        base.Start();
        foreach (ItemFilterToggle toggle in itemTypeFilterButtons)
        {
            toggle.OnFilterItem += OnItemTypeFilterButtonClicked;
        }
    }

    private void OnItemTypeFilterButtonClicked(TradableItemFilterOption type)
    {
        OnFilterItem?.Invoke(type);
    }

    private void OnDestroy()
    {
        foreach (ItemFilterToggle toggle in itemTypeFilterButtons)
        {
            toggle.OnFilterItem -= OnItemTypeFilterButtonClicked;
        }
    }
}