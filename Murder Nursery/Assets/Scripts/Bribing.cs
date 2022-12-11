using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bribing : MonoBehaviour
{
    public GameObject manager;
    private GameObject activeNPC;
    private Item firstBribe = null;
    private Item secondBribe = null;
    public GameObject bribePanel;
    public GameObject inventoryManager;

    public void Start()
    {
        firstBribe = null;
        secondBribe = null;
    }


    private void Update()
    {
        activeNPC = manager.GetComponent<DialogueManager>().activeNPC;
    }
    public void AttemptBribeButton1()
    {
        if(firstBribe.itemName == activeNPC.GetComponent<NPCDialogue>().bribeItem)
        {
            manager.GetComponent<DialogueManager>().StartConversation(activeNPC.GetComponent<NPCDialogue>().bribePath, activeNPC, activeNPC.GetComponent<NPCDialogue>().npcCam);
            bribePanel.SetActive(false);
            inventoryManager.GetComponent<InventoryManager>().RemoveItem(inventoryManager.GetComponent<InventoryManager>().items[2]);
            Destroy(inventoryManager.GetComponent<InventoryManager>().invItems[2]); 
            
        }
         else manager.GetComponent<DialogueManager>().StartConversation(activeNPC.GetComponent<NPCDialogue>().bribeFailPath,activeNPC, activeNPC.GetComponent<NPCDialogue>().npcCam);
        bribePanel.SetActive(false);
    }

    public void StoreInfo(Item item)
    {
        if(firstBribe == null)
        {
            firstBribe = item;
        }
        if(firstBribe != null && secondBribe)
        {
            secondBribe = item; 
        }
    }
}
