using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class NPCDialogue : MonoBehaviour
{
    public DialogueNode[] dialogueTree = new DialogueNode[27]; //Creates the dialogue tree used to store nodes
    public bool isInteractable = false;
    public bool inConversation = false;
    public GameObject interactionMessage;
    public GameObject manager;
    public Camera npcCam;
    public GameObject interrogationManager;
    public Sprite sprite;
    public Texture defaultEmotion;
    public Texture angryEmotion;
    public Texture cryingEmotion;
    public Texture guiltyEmotion;
    public Texture playfulEmotion;
    public Texture sadEmotion;
    public Texture shockedEmotion;
    public Texture thinkingEmotion;
    public Material textureToChange;
    
    // Start is called before the first frame update
    void Start()
    {
        
        manager = GameObject.FindGameObjectWithTag("Manager");
        foreach(DialogueNode node in dialogueTree)
            {
            node.firstPathLocked = false;
            node.secondPathLocked = false;
            node.thirdPathLocked = false;
            node.nodeVisited = false;
            }
        textureToChange.SetTexture("_DetailAlbedoMap", defaultEmotion);
    }

    // Update is called once per frame
    void Update()
    {
        if(isInteractable && Input.GetKeyDown(KeyCode.E) &&!inConversation)
        {
            manager.GetComponent<DialogueManager>().StartConversation(dialogueTree[0], this.gameObject, npcCam);
            inConversation = true;
            isInteractable = false;
        }
        if(inConversation && Input.GetKeyDown(KeyCode.Escape) && !isInteractable && !interrogationManager.GetComponent<Interrogation>().interrogationUnderway)
        {
            manager.GetComponent<DialogueManager>().ExitConversation();
            textureToChange.SetTexture("_DetailAlbedoMap", defaultEmotion);
            inConversation = false;
            interactionMessage.SetActive(true);
        }
        if(inConversation)
        {
            interactionMessage.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "DetectiveDrew")
        {
            isInteractable = true;
            interactionMessage.SetActive(true);
            interactionMessage.GetComponent<TextMeshProUGUI>().text = "Press [E] to interact with " + this.name;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.name == "DetectiveDrew")
        {
            isInteractable = false;
            interactionMessage.SetActive(false);
            inConversation = false;
        }
    }
}
