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

    public TradableItemSO item1;
    public TradableItemSO item2;
    public TradableItemSO item3;
    // Start is called before the first frame update

    public TradeManager tradeManager;
    void Start()
    {
        playerInventoryModel = new PlayerInventoryModel(100);
        playerInventoryController = new PlayerInventoryController(playerInventoryModel, playerInventoryView);
        playerInventoryController.AddItem(item1, 5);
        playerInventoryController.AddItem(item2, 7);
        playerInventoryController.AddItem(item3, 1);

        shopInventoryModel = new ShopInventoryModel(100);
        shopInventoryController = new ShopInventoryController(shopInventoryModel, shopInventoryView);
        shopInventoryController.AddItem(item3, 4);

        playerInventoryController.ShowInventory();


        tradeManager.ShowTradingWindow(playerInventoryController, shopInventoryController);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
