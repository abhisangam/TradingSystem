using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemFilterToggle : MonoBehaviour
{
    [SerializeField] private TradableItemFilterOption itemFilterType;

    private Toggle toggle;

    public Action<TradableItemFilterOption> OnFilterItem;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            OnFilterItem?.Invoke(itemFilterType);
        }
    }


}
