using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TradableItemView : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private Button button;

    public Action OnItemClicked;
    public Action OnItemHovered;
    public Action OnItemHoverExited;

    private void Awake()
    {
        if (button != null)
            button.onClick.AddListener(() => OnItemClicked?.Invoke());
    }

    public void SetIconSprite(Sprite icon)
    {
        iconImage.sprite = icon;
    }

    public void SetQuantityText(int quantity)
    {
        quantityText.text = quantity.ToString();
    }

    private void OnMouseEnter()
    {
        OnItemHovered?.Invoke();
    }

    private void OnMouseExit()
    {
        OnItemHoverExited?.Invoke();
    }
}
