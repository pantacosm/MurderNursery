using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bribing : MonoBehaviour
{
    public GameObject manager; //Stores the game manager
    private GameObject activeNPC; //Stores the active NPC
    private Item firstBribe = null; //First bribe slot
    private Item secondBribe = null; //Second bribe slot
    public GameObject bribePanel; //UI element which stores the bribe panel
    public GameObject inventoryManager; //Stores the inventory manager for easy access to held items

    public void Start()
    {
        firstBribe = null; //Ensures that the bribes are reset at the start of play
        secondBribe = null;
    }


    private void Update()
    {
        activeNPC = manager.GetComponent<DialogueManager>().activeNPC; //Stores the active NPC
    }
    public void AttemptBribeButton1() //Called when the player attempts to bribe an NPC using the first bribe slot 
    {
        if(firstBribe.itemName == activeNPC.GetComponent<NPCDialogue>().bribeItem) //Checks if the bribe is the correct item 
        {
            manager.GetComponent<DialogueManager>().activeNode.bribeGiven = true; //Signals that the bribe has been accepted
            manager.GetComponent<DialogueManager>().StartConversation(activeNPC.GetComponent<NPCDialogue>().bribePath, activeNPC, activeNPC.GetComponent<NPCDialogue>().npcCam);//Loads the relevant dialogue node 
            bribePanel.SetActive(false); //Deactivates the bribe panel
            inventoryManager.GetComponent<InventoryManager>().RemoveItem(inventoryManager.GetComponent<InventoryManager>().items[2]); //Removes the item from the player's inventory
            Destroy(inventoryManager.GetComponent<InventoryManager>().invItems[2]); //Destroys the bribe item
            
        }
         else manager.GetComponent<DialogueManager>().StartConversation(activeNPC.GetComponent<NPCDialogue>().bribeFailPath,activeNPC, activeNPC.GetComponent<NPCDialogue>().npcCam); //Triggers a bribery fail scenario
        bribePanel.SetActive(false); //Deactivates the bribe panel
    }

    public void AttemptBribeButton2() //Same as previous method but with different slot
    {
        if(secondBribe.itemName == activeNPC.GetComponent<NPCDialogue>().bribeItem)
        {
            manager.GetComponent<DialogueManager>().activeNode.bribeGiven = true;
            manager.GetComponent<DialogueManager>().StartConversation(activeNPC.GetComponent<NPCDialogue>().bribePath, activeNPC, activeNPC.GetComponent<NPCDialogue>().npcCam);
            bribePanel.SetActive(false);
            inventoryManager.GetComponent<InventoryManager>().RemoveItem(inventoryManager.GetComponent<InventoryManager>().items[3]);
            Destroy(inventoryManager.GetComponent<InventoryManager>().invItems[3]);

        }
        else manager.GetComponent<DialogueManager>().StartConversation(activeNPC.GetComponent<NPCDialogue>().bribeFailPath, activeNPC, activeNPC.GetComponent<NPCDialogue>().npcCam);
        bribePanel.SetActive(false);
    
    }

    public void StoreInfo(Item item) //Stores the potential bribes when relevant items are collected
    {
        if (firstBribe != null && secondBribe == null)
        {
            secondBribe = item;
        }
        if (firstBribe == null)
        {
            firstBribe = item;
        }
        
    }
}
