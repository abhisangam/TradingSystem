using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public PlayerInventoryView playerInventoryView;
    private PlayerInventoryController playerInventoryController;
    public PlayerInventoryModel playerInventoryModel;

    public TradableItemSO item1;
    public TradableItemSO item2;
    public TradableItemSO item3;
    // Start is called before the first frame update
    void Start()
    {
        playerInventoryModel = new PlayerInventoryModel();
        playerInventoryController = new PlayerInventoryController(playerInventoryModel, playerInventoryView);
        playerInventoryController.AddItem(item1, 5);
        playerInventoryController.AddItem(item2, 7);
        playerInventoryController.AddItem(item3, 1);

        playerInventoryController.ShowInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
