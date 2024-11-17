using System;
using UnityEngine;

public class TradeManager: MonoBehaviour
{
    [SerializeField] private TradableItemInfoPopupController tradableItemInfoPopup;
    [SerializeField] private TradableItemTradingPopupController tradableItemTradingPopup;

    private bool isSelling;
    private int currentTradingItemsCount;

    private PlayerInventoryController playerInventoryController;
    private ShopInventoryController shopInventoryController;

    private TradableItemSO playerSelectedItemSO;

    private int playerMoney = 10000000;
    private void ShowTradableItemInfoPopup()
    {
    }

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
    }

    private void OnPlayerItemSelected(TradableItemSO tradableItemSO)
    {
        isSelling = true;
        tradableItemInfoPopup.Show(tradableItemSO, playerInventoryController.model.items[tradableItemSO], true);
        tradableItemInfoPopup.OnBuyOrSellRequested = null;
        tradableItemInfoPopup.OnBuyOrSellRequested += OnSellOrBuyRequested;
        playerSelectedItemSO = tradableItemSO;
    }

    private void OnShopItemSelected(TradableItemSO tradableItemSO)
    {
        isSelling = false;
        tradableItemInfoPopup.Show(tradableItemSO, shopInventoryController.model.items[tradableItemSO], false);
        tradableItemInfoPopup.OnBuyOrSellRequested = null;
        tradableItemInfoPopup.OnBuyOrSellRequested += OnSellOrBuyRequested; ;
        playerSelectedItemSO = tradableItemSO;
    }

    private void OnSellOrBuyRequested()
    {
        int itemQuantity = isSelling
            ? playerInventoryController.model.items[playerSelectedItemSO]
            : shopInventoryController.model.items[playerSelectedItemSO];

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
            
            if(shopInventoryController.model.GetTotalWeight() + weight > shopInventoryController.model.GetMaxWeight())
            {
                //Show weight exeeded error message
                Debug.Log("Weight exceeded");
            }
            else
            {
                ShowTradeConfirmationPopup();
            }
        }
        else
        {
            price = playerSelectedItemSO.buyingPrice * itemsToTrade;

            if (playerMoney < price)
            {
                //Show not enough funds error message
                Debug.Log("Not enough funds");
            }
            else if (playerInventoryController.model.GetTotalWeight() + weight > playerInventoryController.model.GetMaxWeight())
            {
                //Show weight exeeded error message
                Debug.Log("Weight exceeded");
            }
            else
            {
                ShowTradeConfirmationPopup();
            }
        }

    }

    void OnTradeCancelled()
    {
        tradableItemTradingPopup.Hide();
    }

    private void ShowTradeConfirmationPopup()
    {
        // To do
        // First show trade confirmation popup
        // ExecuteTrade trade if player confirmed
        OnTradeConfirmationAccepted();
    }

    private void ExecuteTrade(int itemsToTrade)
    {
        Debug.Log("Trade Executed");
        if (this.isSelling)
        {
            playerInventoryController.RemoveItem(playerSelectedItemSO, itemsToTrade);
            shopInventoryController.AddItem(playerSelectedItemSO, itemsToTrade);
        }
        else
        {
            playerInventoryController.AddItem(playerSelectedItemSO, itemsToTrade);
            shopInventoryController.RemoveItem(playerSelectedItemSO, itemsToTrade);
        }
    }

    void OnTradeConfirmationAccepted()
    {
        ExecuteTrade(this.currentTradingItemsCount);
        tradableItemTradingPopup.Hide();
        tradableItemTradingPopup.OnBuyOrSell -= OnBuyOrSellOrderPlaced;
    }

    void OnTradeConfirmationRejected()
    {

    }

}