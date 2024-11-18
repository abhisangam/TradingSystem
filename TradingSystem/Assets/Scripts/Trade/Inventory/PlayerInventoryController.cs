using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerInventoryController : InventoryController
{
    public PlayerInventoryController(PlayerInventoryModel playerInventoryModel, PlayerInventoryView playerInventoryView) : base(playerInventoryModel, playerInventoryView)
    {
       
    }
}