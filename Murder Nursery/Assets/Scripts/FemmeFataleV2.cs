using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FemmeFataleV2 : MonoBehaviour
{
    public DialogueNode[] dialogueTree = new DialogueNode[27];
    public bool isInteractable = false;
    public bool inConversation = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            this.GetComponent<DialogueManager>().StartConversation(dialogueTree[0], this.gameObject);
            inConversation = true;
        }
        if(inConversation && Input.GetKeyDown(KeyCode.Escape))
        {
            this.GetComponent<DialogueManager>().ExitConversation();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            isInteractable = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            isInteractable = false;
        }
    }
}
