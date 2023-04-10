using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ItemManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public GameObject itemTooltip;
    public GameObject notebook;
    

    //private bool firstMG = true;
    //private bool firstFP = true;
    public GameObject tutorialManager;
    public string currentOutfit = null;

    public GameObject dressUp;
    private bool outfitChanging = false;

    public void Start()
    {
        tutorialManager = InventoryManager.inventory.tutorialPanel;
        dressUp = GameObject.FindGameObjectWithTag("Dress Up Manager");
        
    }

    public void Update()
    {
        
        if (dressUp.GetComponent<DressUp>().outfitChanging)
        {
            if(dressUp.GetComponent<DressUp>().activeOutfit != "Detective Outfit" && this.gameObject.name == "Magnifying Glass")
            {
                RemoveItem();
                dressUp.GetComponent<DressUp>().outfitChanging = false;
            }
           // if (dressUp.GetComponent<DressUp>().activeOutfit != "Detective Outfit" && this.gameObject.name == "Listening Device")
            //{
              //  RemoveItem();
                //dressUp.GetComponent<DressUp>().outfitChanging = false;
            //}
            if (dressUp.GetComponent<DressUp>().activeOutfit == "Detective Outfit")
            {
                AddItem(InventoryManager.inventory.mGlass);
                //AddItem(InventoryManager.inventory.listeningDevice);
                dressUp.GetComponent<DressUp>().outfitChanging = false;

            }
        }
    }
    // Called from inventory manager when an item is picked up
    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    // Destroys the item and removes it from inventory
    public void RemoveItem()
    {
        InventoryManager.inventory.RemoveItem(item);
        Destroy(gameObject);
    }

    public void RemoveItem(Item toRemove)
    {
        InventoryManager.inventory.RemoveItem(toRemove);
        Destroy(toRemove);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        itemTooltip.SetActive(true);
        itemTooltip.GetComponentInChildren<TextMeshProUGUI>().text = item.itemDescription;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        itemTooltip.SetActive(false);
    }

    // Called when we click an item in our inventory (item type determines the items use functionality)
    public void UseItem()
    {
        switch (item.itemType)
        {
            case Item.ItemType.Bribery:
                break;
            case Item.ItemType.Gift:
                Debug.Log(item.itemName);
                RemoveItem();
                break;
            case Item.ItemType.MagnifyingGlass:
                //if(firstMG)
                //{
                //    Time.timeScale = 0;
                //    tutorialManager.GetComponent<Tutorials>().ActivateTutorial(tutorialManager.GetComponent<Tutorials>().magnifyingGlassTutorial);
                //    firstMG = false;
                //}
                if (InventoryManager.inventory.MG.GetComponent<MagnifyingGlass>().OutfitCheck())
                {
                    InventoryManager.inventory.MG.GetComponent<MagnifyingGlass>().ToggleMagnifyingGlass();
                    InventoryManager.inventory.Player.GetComponent<PlayerMovement>().StartMGCamTransition(); // starts a coroutine which stops player movement whilst active
                    InventoryManager.inventory.UIVisibility.ToggleInventory();
                    itemTooltip.SetActive(false);
                }
                
                break;
            case Item.ItemType.PinBoard:
                InventoryManager.inventory.UIVisibility.TogglePinboard();
                itemTooltip.SetActive(false);
                break;
            case Item.ItemType.Jotter:
                InventoryManager.inventory.UIVisibility.ToggleJotter();
                break;
            case Item.ItemType.NoteBook:
                InventoryManager.inventory.UIVisibility.ToggleNotebook();
                break;
        }
    }
}
