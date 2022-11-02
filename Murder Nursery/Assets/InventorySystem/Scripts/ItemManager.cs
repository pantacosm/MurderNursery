using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    Item item;

    public void UseItem()
    {
        switch (item.itemType)
        {
            case Item.ItemType.Bribery:
                Debug.Log("Bribe someone for information.");
                break;
            case Item.ItemType.MagnifyingGlass:
                // Used for investigating
                break;
        }
    }
}
