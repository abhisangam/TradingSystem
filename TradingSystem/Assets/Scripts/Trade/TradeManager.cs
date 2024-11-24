using System;
using UnityEngine;

public class TradeManager: MonoBehaviour
{
    [SerializeField] private TradableItemInfoPopupController tradableItemInfoPopup;
    [SerializeField] private TradableItemTradingPopupController tradableItemTradingPopup;
    [SerializeField] private PlayerController playerController;

    private bool isSelling;
    private int currentTradingItemsCount;

    private PlayerInventoryController playerInventoryController;
    private ShopInventoryController shopInventoryController;

    private TradableItemSO playerSelectedItemSO;

    public void ShowTradingWindow(PlayerInventoryController playerInventoryController, ShopInventoryController shopInventoryController)
    {
        this.playerInventoryController = playerInventoryController;
        this.shopInventoryController = shopInventoryController;

        playerInventoryController.OnItemSelected = null;
        shopInventoryController.OnItemSelected = null;
        //Subscribe to inventory events
        playerInventoryController.OnItemSelected += OnPlayerItemSelected;
        shopInventoryController.OnItemSelected += OnShopItemSelected;

        this.gameObject.SetActive(true);
    }

    public void HideTradingWindow()
    {
        //unsubscribe to inventory events
        playerInventoryController.OnItemSelected -= OnPlayerItemSelected;
        shopInventoryController.OnItemSelected -= OnShopItemSelected;
    }

    private void OnPlayerItemSelected(TradableItemSO tradableItemSO)
    {
        isSelling = true;
        playerSelectedItemSO = tradableItemSO;
        tradableItemInfoPopup.Show(tradableItemSO, playerInventoryController.GetItemQuantity(tradableItemSO), true);
        tradableItemInfoPopup.OnBuyOrSellRequested = null;
        tradableItemInfoPopup.OnBuyOrSellRequested += OnSellOrBuyRequested;
    }

    private void OnShopItemSelected(TradableItemSO tradableItemSO)
    {
        isSelling = false;
        playerSelectedItemSO = tradableItemSO;
        tradableItemInfoPopup.Show(tradableItemSO, shopInventoryController.GetItemQuantity(tradableItemSO), false);
        tradableItemInfoPopup.OnBuyOrSellRequested = null;
        tradableItemInfoPopup.OnBuyOrSellRequested += OnSellOrBuyRequested;
        Debug.Log("Shop item selected and event subscribed");
    }

    private void OnSellOrBuyRequested()
    {
        int itemQuantity = isSelling
            ? playerInventoryController.GetItemQuantity(playerSelectedItemSO)
            : shopInventoryController.GetItemQuantity(playerSelectedItemSO);

        tradableItemTradingPopup.Show(playerSelectedItemSO, itemQuantity, isSelling);
        tradableItemTradingPopup.OnBuyOrSell = null;
        tradableItemTradingPopup.OnCancelTrade = null;
        tradableItemTradingPopup.OnBuyOrSell += OnBuyOrSellOrderPlaced;
        tradableItemTradingPopup.OnCancelTrade += OnTradeCancelled;
        tradableItemInfoPopup.Hide();
    }

    void OnBuyOrSellOrderPlaced(int itemsToTrade)
    {
        currentTradingItemsCount = itemsToTrade;
        //Check for currency and weight contitions and accept or reject trade
        int weight = playerSelectedItemSO.weight * itemsToTrade;
        int price = 0;

        if (isSelling)
        {
            price = playerSelectedItemSO.sellingPrice * itemsToTrade;
            
            if(shopInventoryController.GetInventoryWeight() + weight > shopInventoryController.GetInventoryMaxWeight())
            {
                //Show weight exeeded error message
                Debug.Log("Weight exceeded");
            }
            else
            {
                ExecuteTrade(this.currentTradingItemsCount, price);
           
            }
        }
        else
        {
            price = playerSelectedItemSO.buyingPrice * itemsToTrade;

            if (playerController.GetCurrency() < price)
            {
                //Show not enough funds error message
                Debug.Log("Not enough funds");
            }
            else if (playerInventoryController.GetInventoryWeight() + weight > playerInventoryController.GetInventoryMaxWeight())
            {
                //Show weight exeeded error message
                Debug.Log("Weight exceeded");
            }
            else
            {
                ExecuteTrade(this.currentTradingItemsCount, price);
            }
        }

    }

    void OnTradeCancelled()
    {
        tradableItemTradingPopup.Hide();
    }

    private void ExecuteTrade(int itemsToTrade, int tradeAmount)
    {
        Debug.Log("Trade Executed");
        if (this.isSelling)
        {
            playerInventoryController.RemoveItem(playerSelectedItemSO, itemsToTrade);
            shopInventoryController.AddItem(playerSelectedItemSO, itemsToTrade);
            playerController.AddCurrency(tradeAmount);
        }
        else
        {
            playerInventoryController.AddItem(playerSelectedItemSO, itemsToTrade);
            shopInventoryController.RemoveItem(playerSelectedItemSO, itemsToTrade);
            playerController.SubtractCurrency(tradeAmount);
        }

        FinishTrading();
    }

    private void FinishTrading()
    {
        tradableItemTradingPopup.Hide();
        tradableItemTradingPopup.OnBuyOrSell -= OnBuyOrSellOrderPlaced;
    }

}