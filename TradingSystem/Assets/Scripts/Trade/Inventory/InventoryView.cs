using UnityEngine;
using static UnityEditor.Progress;

public class InventoryView : MonoBehaviour
{
    protected InventoryController controller;
    [SerializeField] private Transform itemsParent;
    [SerializeField] private TradableItemView tradableItemPrefab;

    [SerializeField] private TradableItemInfoPopupController itemInfoPopupController;

    public void SetController(InventoryController controller)
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