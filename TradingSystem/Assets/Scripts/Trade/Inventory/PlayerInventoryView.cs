using UnityEngine;
using static UnityEditor.Progress;

public class PlayerInventoryView : MonoBehaviour
{
    private PlayerInventoryController controller;
    [SerializeField] private Transform itemsParent;
    [SerializeField] private TradableItemView tradableItemPrefab;
    public void SetController(PlayerInventoryController controller)
    {
        this.controller = controller;
    }
    public void DisplayInventoryView()
    {
        
    }

    public TradableItemView CreateAndAddItem(TradableItemSO tradableItemSO, int quantity)
    {
        TradableItemView itemView = Instantiate(tradableItemPrefab, itemsParent);
        itemView.SetIconSprite(tradableItemSO.icon);
        itemView.SetQuantityText(quantity);

        return itemView;

    }
}