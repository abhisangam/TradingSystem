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

    public TradableItemView CreateAndAddItem()
    {
        TradableItemView itemView = Instantiate(tradableItemPrefab, itemsParent);

        return itemView;

    }
}