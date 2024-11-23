using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    private int currency;

    private PlayerInventoryController playerInventoryController;
    [SerializeField] private PlayerInventoryView playerInventoryView;

    [SerializeField] TradableItemListSO tradableItemListSO;

    public Action<int> OnCurrencyChanged;

    private void Awake()
    {
        PlayerInventoryModel playerInventoryModel = new PlayerInventoryModel(100000);
        playerInventoryController = new PlayerInventoryController(playerInventoryModel, playerInventoryView);

        currency = 0;
        OnCurrencyChanged?.Invoke(currency);
    }

    public int GetCurrency()
    {
        return currency;
    }

    public PlayerInventoryController GetPlayerInventoryController()
    {
        return playerInventoryController;
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
        OnCurrencyChanged?.Invoke(currency);
    }

    public void SubtractCurrency(int amount)
    {
        currency -= amount;
        OnCurrencyChanged?.Invoke(currency);
    }

    /**
     * Gathers 10 resources based on their rarity and adds them to the player's inventory
     * To simulate player collecting items in the world in the game
     */
    public void GatherResources()
    {
        List<TradableItemSO> tradableItemsInWorld = new List<TradableItemSO>();
        //Populate the tradable items available in the player's world
        for(int i = 0; i < tradableItemListSO.tradableItems.Length; i++)
        {
            TradableItemSO tradableItemSO = tradableItemListSO.tradableItems[i];
            int numberOfItems = 0;
            switch(tradableItemSO.rarity)
            {
                case TradableItemRarity.VeryCommon:
                    numberOfItems = 10;
                    break;
                case TradableItemRarity.Common:
                    numberOfItems = 7;
                    break;
                case TradableItemRarity.Rare:
                    numberOfItems = 4;
                    break;
                case TradableItemRarity.Epic:
                    numberOfItems = 2;
                    break;
                case TradableItemRarity.Legendary:
                    numberOfItems = 1;
                    break;
            }

            for(int j = 0; j < numberOfItems; j++)
            {
                tradableItemsInWorld.Add(tradableItemSO);
            }
        }

        //Pick a random tradable item in the world
        for(int i = 0; i < 10; i++)
        {
            TradableItemSO tradableItemSO = tradableItemsInWorld[UnityEngine.Random.Range(0, tradableItemsInWorld.Count)];
            playerInventoryController.AddItem(tradableItemSO, 1);
        }
    }
}