using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {
        switch (item.itemType)
        {
            case Item.ItemType.Bribery:
                if(item.itemName == ("Candy"))
                {
                    Debug.Log("I can bribe someone with this half eating candy.");
                }
                break;
            case Item.ItemType.Gift:
                Debug.Log(item.itemName);
                InventoryManager.inventory.RemoveItem(item);
                break;
            case Item.ItemType.MagnifyingGlass:
                // Used for investigating
                break;
        }
    }
}
