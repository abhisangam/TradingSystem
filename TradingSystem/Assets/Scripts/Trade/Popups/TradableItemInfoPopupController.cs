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
    
    public void Show(TradableItemModel model, bool isSelling)
    {
        gameObject.SetActive(true);

        icon.sprite = model.icon;
        itemName.text = model.name;
        itemDescription.text = model.description;
        itemPriceText.text = "Price: " + model.sellingPrice.ToString();
        itemQuantityText.text = "Quantity: " + model.quantity.ToString();
        itemRarityText.text = "Rarity: " + model.rarity.ToString();
        itemWeightText.text = "Weight: " + model.weight.ToString();
        buyOrSellButtonText.text = isSelling ? "Sell" : "Buy";
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    


}
