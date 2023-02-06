using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inventory;

    [SerializeField]
    Item pinboard; //Stores the pinboard for the player inventory

    [SerializeField]
    Item jotter; //Stores the jotter for the player inventory

    [HideInInspector]
    public ToggleUIVisibility UIVisibility; 

    [SerializeField]
    public List<Item> items = new List<Item>();//List of items present 

    [SerializeField]
    Transform itemContent;

    [SerializeField]
    GameObject inventoryItem;

    public ItemManager[] inventoryItems; //Stores items present in player inventory
    public GameObject blur; //Background blur object
    public List<GameObject> invItems; 

    private void Awake()
    {
        inventory = this;
        UIVisibility = GetComponent<ToggleUIVisibility>();
    }

    private void Start()
    {
        AddItem(pinboard); //Adds the fundamental items to the player's inventory
        AddItem(jotter); //''
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.I))//Used to open and close the player's inventory
        {
            UIVisibility.ToggleInventory();
            if(blur.activeSelf)
            {
                blur.SetActive(false);
            }
        }
    }

    public void AddItem(Item item) //Called when an item is collected and added to the player's inventory 
    {
        items.Add(item);
        SetInventoryItems(item);
    }

    public void RemoveItem(Item item) //Called when an item is removed from the player inventory
    {
        items.Remove(item);
        
    }

    public void SetInventoryItems(Item item)
    {
        
        // adds itemUI to Inventory UI (allows us to see the item in inventory) 
        GameObject itemObj = Instantiate(inventoryItem, itemContent);
        invItems.Add(itemObj);
        var itemIcon = itemObj.transform.Find("ItemIcon").GetComponent<Image>();
        var itemName = itemObj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        itemIcon.sprite = item.icon;
        itemName.text = item.itemName;

        // sets the item in ItemManager so we can access its UseItem() function
        inventoryItems = itemContent.GetComponentsInChildren<ItemManager>();

        // loops through each item in the inventory to add to the item manager
        // item manager allows us to get the items type which is required when using the item
        for (int i = 0; i < items.Count; i++)
        {
            inventoryItems[i].AddItem(items[i]);
        }
    }

   
    
    
   
}
