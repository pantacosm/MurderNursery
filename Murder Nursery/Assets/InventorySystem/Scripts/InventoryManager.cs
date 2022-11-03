using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inventory;
    public List<Item> items = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;
    public ItemManager[] inventoryItems;

    private void Awake()
    {
        inventory = this;
    }

    public void AddItem(Item item)
    {
        items.Add(item);

        // adds itemUI to Inventory UI (allows us to see the item in inventory) 
        GameObject itemObj = Instantiate(inventoryItem, itemContent);
        var itemIcon = itemObj.transform.Find("ItemIcon").GetComponent<Image>();
        itemIcon.sprite = item.icon;

        // sets the item in ItemManager so we can access its UseItem() function
        SetInventoryItems();
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public void SetInventoryItems()
    {
        inventoryItems = itemContent.GetComponentsInChildren<ItemManager>();

        for (int i = 0; i < items.Count; i++)
        {
            inventoryItems[i].AddItem(items[i]);
        }
    }
}
