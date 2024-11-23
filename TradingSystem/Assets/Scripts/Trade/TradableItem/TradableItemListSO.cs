using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "NewTradableItemList", menuName = "Trading/TradableItemList")]
public class TradableItemListSO: ScriptableObject
{
    public TradableItemSO[] tradableItems;
}