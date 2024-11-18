using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public PlayerInventoryView playerInventoryView;
    private PlayerInventoryController playerInventoryController;
    private PlayerInventoryModel playerInventoryModel;

    public ShopInventoryView shopInventoryView;
    private ShopInventoryModel shopInventoryModel;
    private ShopInventoryController shopInventoryController;

    public TradableItemSO[] tradableItems;
    // Start is called before the first frame update

    public TradeManager tradeManager;
    void Start()
    {
        playerInventoryModel = new PlayerInventoryModel(100);
        playerInventoryController = new PlayerInventoryController(playerInventoryModel, playerInventoryView);
        for(int i = 0; i < tradableItems.Length; i++)
        {
            playerInventoryController.AddItem(tradableItems[i], 1);
        }

        shopInventoryModel = new ShopInventoryModel(100);
        shopInventoryController = new ShopInventoryController(shopInventoryModel, shopInventoryView);
        for (int i = 0; i < tradableItems.Length; i++)
        {
            shopInventoryController.AddItem(tradableItems[i], 10);
        }

        playerInventoryController.ShowInventory();


        tradeManager.ShowTradingWindow(playerInventoryController, shopInventoryController);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
