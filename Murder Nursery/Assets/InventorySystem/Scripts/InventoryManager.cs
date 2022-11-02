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

    private void Awake()
    {
        inventory = this;
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        ListItems();
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        ListItems();
    }

    public void CleanupList()
    {
        // Clean up inventory ui content before adding next item
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
    }

    public void ListItems()
    {

        CleanupList();
        foreach ( var item in items)
        {
            GameObject itemObj = Instantiate(inventoryItem, itemContent);
            var itemIcon = itemObj.transform.Find("ItemIcon").GetComponent<Image>();

            itemIcon.sprite = item.icon;
        }
    }
}
