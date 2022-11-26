using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public DialogueNode[] dialogueTree = new DialogueNode[27]; //Creates the dialogue tree used to store nodes
    public bool isInteractable = false;
    public bool inConversation = false;
    public GameObject interactionMessage;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach(DialogueNode node in dialogueTree)
            {
            node.firstPathLocked = false;
            node.secondPathLocked = false;
            node.thirdPathLocked = false;
            node.nodeVisited = false;
            }
    }

    // Update is called once per frame
    void Update()
    {
        if(isInteractable && Input.GetKeyDown(KeyCode.E) &&!inConversation)
        {
            this.GetComponent<DialogueManager>().StartConversation(dialogueTree[0], this.gameObject);
            inConversation = true;
            isInteractable = false;
        }
        if(inConversation && Input.GetKeyDown(KeyCode.Escape) && !isInteractable)
        {
            this.GetComponent<DialogueManager>().ExitConversation();
            inConversation = false;
        }
        if(inConversation)
        {
            interactionMessage.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            isInteractable = true;
            interactionMessage.SetActive(true);
            interactionMessage.GetComponent<TextMeshProUGUI>().text = "Press [E] to interact with " + this.name;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            isInteractable = false;
            interactionMessage.SetActive(false);
            inConversation = false;
        }
    }
}
