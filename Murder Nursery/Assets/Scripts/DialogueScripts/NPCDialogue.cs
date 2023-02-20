using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class NPCDialogue : MonoBehaviour
{
    public DialogueNode[] dialogueTree = new DialogueNode[27]; //Creates the dialogue tree used to store nodes
    public bool isInteractable = false; //Used to signal if NPC is interactable
    public bool inConversation; //Signals if player is in conversation
    public GameObject interactionMessage; //The message displayed to the player when in NPC interaction range 
    public GameObject manager;//Stores game manager
    public Camera npcCam; //NPC specific camera 
    public GameObject interrogationManager; //Stores interrogation manager
    public Sprite sprite; //NPC sprite

    [Header("Emotions")]
    public Texture defaultEmotion;//Emotion texture
    public Texture angryEmotion;//''
    public Texture cryingEmotion;//''
    public Texture guiltyEmotion;//''
    public Texture playfulEmotion;//''
    public Texture sadEmotion;//''
    public Texture shockedEmotion;//''
    public Texture thinkingEmotion;//''
    public Material textureToChange;//The texture to be replaced

    [Header("Bribery Variables")]
    public string bribeItem; //Bribe item required
    public DialogueNode bribePath; //Successful bribe dialogue path
    public DialogueNode bribeFailPath; //Unsuccessful bribe dialogue path

    public DialogueNode interrogationNode;
    public string requiredEvidence1;
    public string requiredEvidence2;
    public string requiredEvidence3;
    public string requiredEvidence4;
    public string requiredEvidence5;
    public string description;



    public void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager"); //Stores manager

        foreach(DialogueNode node in dialogueTree) //Resets dialogue tree locking
            {
            node.firstPathLocked = false;
            node.secondPathLocked = false;
            node.thirdPathLocked = false;
            node.nodeVisited = false;
            node.evImagesGenerated = false;
            }
        textureToChange.SetTexture("_DetailAlbedoMap", defaultEmotion); //Sets default emotion active 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInteractable)
        {
            ToggleConversation();
        }

        // reset inConversation boolean when convo ends (useful for when convo ends due to a dialogue option)
        if(interactionMessage && interactionMessage.activeInHierarchy)
        {
            inConversation = false;
        }
    }

    public void OnTriggerEnter(Collider other) 
    {
        if (other.name == "DetectiveDrew")//Detects collison with the player object 
        {
            isInteractable = true;
            interactionMessage.SetActive(true); //Activates NPC interaction messages
            interactionMessage.GetComponent<TextMeshProUGUI>().text = "Press [E] to interact with " + this.name;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.name == "DetectiveDrew") //Detects the player leaving the collision area
        {
            isInteractable = false;
            interactionMessage.SetActive(false); //Deactivates NPC interavtion messages 
            //inConversation = false;
        }
    }

    public void ToggleConversation() // toggles dialogue when interacting with an npc (E key / Return icon button)
    {
        if (inConversation) // end convo
        {
            if (!isInteractable && !interrogationManager.GetComponent<Interrogation>().interrogationUnderway) //Allows the player to leave conversation 
            {
                manager.GetComponent<DialogueManager>().ExitConversation(); //Exits conversation with chosen NPC
                textureToChange.SetTexture("_DetailAlbedoMap", defaultEmotion);
                inConversation = false;
                interactionMessage.SetActive(true);
                manager.GetComponent<DialogueManager>().briberyPanel.SetActive(false);
                Cursor.visible = false;
            }
        }
        else if (!inConversation && isInteractable) // start convo
        {
            manager.GetComponent<DialogueManager>().StartConversation(dialogueTree[0], this.gameObject, npcCam); //Enters dialogue with chosen NPC
            inConversation = true;
            isInteractable = false;
            interactionMessage.SetActive(false);
        }
    }

}
