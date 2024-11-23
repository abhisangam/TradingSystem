using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class TradableItemQuickInfo : MonoBehaviour
{
    // Start is called before the first frame update
    private static TradableItemQuickInfo instance;
    public static TradableItemQuickInfo Instance { get { return instance; } private set { } }

    private bool isShowing = false;
    [SerializeField] private TMPro.TextMeshProUGUI itemInfoText;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowing)
        {
            gameObject.transform.position = Input.mousePosition;
        }
    }

    public static void Show(TradableItemSO itemSO)
    {
        Instance.itemInfoText.text = "<b>" + itemSO.name + "</b>" + ": " + itemSO.description;
        Instance.gameObject.SetActive(true);
        Instance.gameObject.transform.position = Input.mousePosition;
        Instance.isShowing = true;
    }

    public static void Hide()
    {
        Instance.gameObject.SetActive(false);
        Instance.isShowing = false;
    }
}
