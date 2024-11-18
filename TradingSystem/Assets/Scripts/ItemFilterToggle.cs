using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemFilterToggle : MonoBehaviour
{
    [SerializeField] private TradableItemType itemType;

    private Toggle toggle;

    public Action<TradableItemType> OnFilterItem;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            OnFilterItem?.Invoke(itemType);
        }
    }


}
