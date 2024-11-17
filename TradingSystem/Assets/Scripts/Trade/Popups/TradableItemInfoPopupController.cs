using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TradableItemInfoPopupController : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private TextMeshProUGUI itemPriceText;
    [SerializeField] private TextMeshProUGUI itemQuantityText;
    [SerializeField] private TextMeshProUGUI itemRarityText;
    [SerializeField] private TextMeshProUGUI itemWeightText;
    [SerializeField] private Button buyOrSellButton;
    [SerializeField] private TextMeshProUGUI buyOrSellButtonText;
    [SerializeField] private Button closeButton;
    // Start is called before the first frame update

    public Action OnBuyOrSellRequested;
    
    public void Show(TradableItemSO itemSO, int itemQuantiy, bool isSelling)
    {
        gameObject.SetActive(true);

        icon.sprite = itemSO.icon;
        itemName.text = itemSO.name;
        itemDescription.text = itemSO.description;
        itemPriceText.text = "Price: " + (isSelling ? itemSO.sellingPrice : itemSO.buyingPrice).ToString();
        itemQuantityText.text = "Quantity: " + itemQuantiy.ToString();
        itemRarityText.text = "Rarity: " + itemSO.rarity.ToString();
        itemWeightText.text = "Weight: " + itemSO.weight.ToString();
        buyOrSellButtonText.text = isSelling ? "Sell" : "Buy";

        buyOrSellButton.onClick.AddListener(OnBuyOrSellButtonClicked);
        closeButton.onClick.AddListener(OnCloseButtonClicked);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnBuyOrSellButtonClicked()
    {
        OnBuyOrSellRequested?.Invoke();
    }

    private void OnCloseButtonClicked()
    {
        Hide();
        closeButton.onClick.RemoveListener(OnCloseButtonClicked);
    }


}
