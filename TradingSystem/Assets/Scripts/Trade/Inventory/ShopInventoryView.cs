using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ShopInventoryView : InventoryView
{
    [SerializeField] private ItemFilterToggle[] itemTypeFilterButtons;

    public Action<TradableItemType> OnFilterItem;
    private void Start()
    {
        foreach (ItemFilterToggle toggle in itemTypeFilterButtons)
        {
            toggle.OnFilterItem += OnItemTypeFilterButtonClicked;
        }
    }

    private void OnItemTypeFilterButtonClicked(TradableItemType type)
    {
        OnFilterItem?.Invoke(type);
    }
}