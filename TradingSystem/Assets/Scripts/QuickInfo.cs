using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class QuickInfo : MonoBehaviour
{
    private bool isShowing = false;
    [SerializeField] private TMPro.TextMeshProUGUI itemInfoText;


    private void Awake()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowing)
        {
            gameObject.transform.position = Input.mousePosition;
        }
    }

    public void Show(string info)
    {
        itemInfoText.text = info;
        gameObject.SetActive(true);
        gameObject.transform.position = Input.mousePosition;
        isShowing = true;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        isShowing = false;
    }
}
