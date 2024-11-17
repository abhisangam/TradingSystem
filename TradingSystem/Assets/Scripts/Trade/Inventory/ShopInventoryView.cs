using UnityEngine;
using static UnityEditor.Progress;

public class ShopInventoryView : MonoBehaviour
{
    private ShopInventoryController controller;
    [SerializeField] private Transform itemsParent;
    [SerializeField] private TradableItemView tradableItemPrefab;

    [SerializeField] private TradableItemInfoPopupController itemInfoPopupController;
    public void SetController(ShopInventoryController controller)
    {
        this.controller = controller;
    }
    public void DisplayInventoryView()
    {

    }

    public TradableItemView CreateItemView()
    {
        TradableItemView itemView = Instantiate(tradableItemPrefab, itemsParent);
        return itemView;
    }
}