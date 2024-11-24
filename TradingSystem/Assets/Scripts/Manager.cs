using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    public ShopInventoryView shopInventoryView;
    private ShopInventoryModel shopInventoryModel;
    private ShopInventoryController shopInventoryController;

    public TradableItemListSO tradableItems;
    // Start is called before the first frame update

    public TradeManager tradeManager;
    void Start()
    {
        shopInventoryModel = new ShopInventoryModel(10000);
        shopInventoryController = new ShopInventoryController(shopInventoryModel, shopInventoryView);
        for (int i = 0; i < tradableItems.tradableItems.Length; i++)
        {
            shopInventoryController.AddItem(tradableItems.tradableItems[i], 10);
        }

        tradeManager.ShowTradingWindow(playerController.GetPlayerInventoryController(), shopInventoryController);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
