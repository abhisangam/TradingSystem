using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TradableItemTradingPopupController : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI totalCostText;
    [SerializeField] TextMeshProUGUI tradingItemCountText;
    [SerializeField] Button increaseButton;
    [SerializeField] Button decreaseButton;
    [SerializeField] Button buyOrSellButton;
    [SerializeField] TextMeshProUGUI buyOrSellButtonText;
    [SerializeField] Button cancelButton;

    private int tradingItemCount;
    bool isSelling;
    int itemCurrentQuantity;

    public Action<int> OnBuyOrSell; // send item count along
    public Action OnCancelTrade;

    public void Show(TradableItemSO itemSO, int itemCurrentQuantity, bool isSelling)
    {
        gameObject.SetActive(true);
        icon.sprite = itemSO.icon;
        nameText.text = itemSO.name;

        int price = isSelling
            ? itemSO.sellingPrice
            : itemSO.buyingPrice;

        this.itemCurrentQuantity = itemCurrentQuantity;

        totalCostText.text = "Cost: " + price;
        tradingItemCountText.text = "1";
        increaseButton.onClick.RemoveAllListeners();
        increaseButton.onClick.AddListener(() => IncreaseTradingItemCount(itemSO));
        decreaseButton.onClick.RemoveAllListeners();
        decreaseButton.onClick.AddListener(() => DecreaseTradingItemCount(itemSO));
        buyOrSellButton.onClick.RemoveAllListeners();
        buyOrSellButton.onClick.AddListener(() => OnClickedBuyOrSell());
        cancelButton.onClick.RemoveAllListeners();
        cancelButton.onClick.AddListener(() => OnClickedClose());
        buyOrSellButtonText.text = isSelling ? "Sell" : "Buy";

        this.tradingItemCount = 1;
        this.isSelling = isSelling;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void IncreaseTradingItemCount(TradableItemSO tradableItemSO)
    {
        if(tradingItemCount < itemCurrentQuantity)
        {
            tradingItemCount++;
            tradingItemCountText.text = tradingItemCount.ToString();
            int tradingPrice = isSelling
                ? tradableItemSO.sellingPrice
                : tradableItemSO.buyingPrice;
            totalCostText.text = "Cost: " + (tradingItemCount * tradingPrice);
        }
    }

    private void DecreaseTradingItemCount(TradableItemSO tradableItemSO)
    {
        if (tradingItemCount > 1)
        {
            tradingItemCount--;
            tradingItemCountText.text = tradingItemCount.ToString();
            int tradingPrice = isSelling
                ? tradableItemSO.sellingPrice
                : tradableItemSO.buyingPrice;
            totalCostText.text = "Cost: " + (tradingItemCount * tradingPrice);
        }
    }

    private void OnClickedBuyOrSell()
    {
        OnBuyOrSell?.Invoke(tradingItemCount);
    }

    private void OnClickedClose()
    {
        Hide();
        OnCancelTrade?.Invoke();
    }
}