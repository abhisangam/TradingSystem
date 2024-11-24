using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TradableItemView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private Button button;

    private TradableItemController controller;

    public Action OnItemClicked;

    private void Awake()
    {
        if (button != null)
            button.onClick.AddListener(() => OnItemClicked?.Invoke());
    }

    public void SetController(TradableItemController controller)
    {
        this.controller = controller;
    }

    public void SetIconSprite(Sprite icon)
    {
        iconImage.sprite = icon;
    }

    public void SetQuantityText(int quantity)
    {
        quantityText.text = quantity.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIService.Instance.quickInfo.Show(GetQuickInfoText(controller.GetItemSO()));
        Debug.Log("Pointer Enter");
    }

    private string GetQuickInfoText(TradableItemSO itemSO)
    {
        return "<b>" + itemSO.name + "</b>" + ": " + itemSO.description;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIService.Instance.quickInfo.Hide();
        Debug.Log("Pointer Exit");
    }
}
