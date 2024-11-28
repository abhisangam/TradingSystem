using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    protected InventoryController controller;
    [SerializeField] private Transform itemsParent;
    [SerializeField] private TradableItemView tradableItemPrefab;

    private RectTransform contentRectTransform;
    [SerializeField] private GridLayoutGroup gridLayout;
    private Vector2 gridCellSize;
    private Vector2 gridCellSpacing;

    protected void Start()
    {
        gridCellSize = gridLayout.cellSize;
        gridCellSpacing = gridLayout.spacing;
        contentRectTransform = gridLayout.GetComponent<RectTransform>();
    }

    protected void Update()
    {
        // TO DO: 
        // For some strange reason, after resizing the content height, the children go invisible in play mode
        // Fix this later
        //ResizeScrollContent();
    }

    public void SetController(InventoryController controller)
    {
        this.controller = controller;
    }

    public TradableItemView CreateItemView()
    {
        Debug.Log(itemsParent.name);
        TradableItemView itemView = Instantiate(tradableItemPrefab, itemsParent);
        return itemView;
    }

    private void ResizeScrollContent()
    {
        float gridWidth = contentRectTransform.rect.width;
        int columnCount = Mathf.FloorToInt(gridWidth / (gridCellSize.x + gridCellSpacing.x));
        float gridHeight = Mathf.Ceil((float)contentRectTransform.childCount / columnCount) * (gridCellSize.y + gridCellSpacing.y);

        Vector2 sizeDelta = contentRectTransform.sizeDelta;
        sizeDelta.y = gridHeight;
        contentRectTransform.sizeDelta = sizeDelta;
    }
}