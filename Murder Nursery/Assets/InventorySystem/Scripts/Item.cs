using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Create Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public string itemDescription;
    public Sprite icon;
    public ItemType itemType;

    public enum ItemType
    {
        Bribery,
        Key,
        QuestItem,
        Gift,
        MagnifyingGlass,
        PinBoard
    }

}
