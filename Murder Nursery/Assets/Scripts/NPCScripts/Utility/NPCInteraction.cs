using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;


public class NPCInteraction : MonoBehaviour
{
    public GameObject manager;
    private bool interactable;
    public GameObject dialoguePanel;
    public GameObject player;
    public bool inConvo;
    private string playerReply1;
    private string playerReply2;
    private string playerReply3;
    public GameObject thisNPC;
    private string npcStatement1;
    public GameObject responsePanel1;
    public GameObject responsePanel2;
    public GameObject responsePanel3;
    int pos = 0;
    public int firstChoice = 0;
    public int secondChoice = 0;
    public bool firstInteractionComplete;

    PinboardManager PM;

    
    // Start is called before the first frame update
    void Start()
    {
        interactable = false;
        inConvo = false;
        manager = GameObject.FindGameObjectWithTag("Manager");
        playerReply1 = thisNPC.GetComponent<BasicNPC>().playerResponse1A;
        playerReply2 = thisNPC.GetComponent<BasicNPC>().playerResponse1B;
        playerReply3 = thisNPC.GetComponent<BasicNPC>().playerResponse1C;
        npcStatement1 = thisNPC.GetComponent<BasicNPC>().initialStatement;
        firstInteractionComplete = false;
        PM = FindObjectOfType<PinboardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inConvo == false && interactable == true && Input.GetKeyDown(KeyCode.E)) //Enters the player into a conversation when they are in range and press 'E'
        {
            print("In Convo");
            EnterConverstion();
            inConvo = true;
        }

        if (inConvo == true && Input.GetKey(KeyCode.Escape)) //Allows the player to leave the current conversation
        {
            ExitConversation();
            inConvo = false;
        }

        if (inConvo == true && firstInteractionComplete ==false) //Allows the player to choose their response
        {
            firstChoice = ChooseResponse();
        }

        if(inConvo ==true && firstInteractionComplete == true)
        {
            secondChoice = ChooseResponseLockedChoiceOne();
        }
    }

    private void OnTriggerEnter(Collider other) //Checks if the player is within range to interact with npc
    {
        if (other.gameObject.tag == "Player")
        {
            interactable = true;
        }
    }

    private void OnTriggerExit(Collider other) //Signals that the player is no longer within range of npc
    {
        if (other.gameObject.tag == "Player")
        {
            interactable = false;
        }
    }

    public void EnterConverstion() //Enters a conversation with an npc and disables the player's movement
    {
        player.GetComponent<PlayerMovement>().playerSpeed = 0f;
        player.GetComponent<PlayerMovement>().jumpHeight = 0f;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        dialoguePanel.SetActive(true);
        manager.GetComponent<DialogueSystem>().LoadNPCStatement(npcStatement1);
        manager.GetComponent<DialogueSystem>().LoadResponses(playerReply1, playerReply2, playerReply3);
        GameObject.FindGameObjectWithTag("Camera").GetComponent<Cinemachine.CinemachineInputProvider>().enabled = false;
    }

    public void ExitConversation() //Exits the conversation and re-enables player controls
    {
        player.GetComponent<PlayerMovement>().playerSpeed = 4.0f;
        player.GetComponent<PlayerMovement>().jumpHeight = 1.0f;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        dialoguePanel.SetActive(false);
        GameObject.FindGameObjectWithTag("Camera").GetComponent<Cinemachine.CinemachineInputProvider>().enabled = true;
        
        
    }

    public bool RelationshipCheck(int minLevel, int currentLevel) //Checks whether or not a player has a high enough relationship to select a choice
    {
        bool canProceed;
        if(currentLevel >= minLevel)
        {
            canProceed = true;  
        }
        else canProceed = false;
        return canProceed;
    }

    public int ChooseResponse() //This is called when the player is mid conversation and is currently choosing a respone
    {
        int choice = 0;
        if (pos == 0)
        {
            responsePanel1.GetComponent<Image>().color = Color.green; //These statements alter the background colour of the selected response
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                responsePanel1.GetComponent<Image>().color = Color.white;
                pos++; //Signals that the player is moving through the choices

            }
            if (Input.GetKeyUp(KeyCode.Return)) //Confirms the player's choice
            {
                choice = 1;
                firstInteractionComplete = true; //Signals that the first response has been logged
                
                // Test to show info being added to pin board based on dialogue chosen
                //PM.UpdatePinboard(PM.GoonLikes, "COOL GUY");

                return choice;
            }
        }
        if (pos == 1)
        {
            responsePanel2.GetComponent<Image>().color = Color.green;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                pos--;
                responsePanel2.GetComponent<Image>().color = Color.white;

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                pos++;
                responsePanel2.GetComponent<Image>().color = Color.white;

            }
            if (Input.GetKeyUp(KeyCode.Return))
            {
                choice = 2;
                firstInteractionComplete = true;
                return choice;
            }
        }
        if (pos == 2)
        {
            responsePanel3.GetComponent<Image>().color = Color.green;
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                pos--;
                responsePanel3.GetComponent<Image>().color = Color.white;

            }
            if (Input.GetKeyUp(KeyCode.Return))
            {

                choice = 3;
                firstInteractionComplete = true;
                return choice;

            }
        }
        return choice;
    }

    public int ChooseResponseLockedChoiceOne()
    {
        int choice = 0;
        if (pos == 0)
        {
            if (RelationshipCheck(50, manager.GetComponent<RelationshipManager>().coolMeter))
            {
                responsePanel1.GetComponent<Image>().color = Color.green; //These statements alter the background colour of the selected response
            }
            if (RelationshipCheck(50, manager.GetComponent<RelationshipManager>().coolMeter) == false)
            {
                responsePanel1.GetComponent<Image>().color = Color.red;
            }
                if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                responsePanel1.GetComponent<Image>().color = Color.white;
                pos++; //Signals that the player is moving through the choices

            }
            if (Input.GetKeyUp(KeyCode.Return)) //Confirms the player's choice
            {
                if (RelationshipCheck(50, manager.GetComponent<RelationshipManager>().coolMeter))
                {
                    print("Your relationshiop is high enough");
                    choice = 1;
                    firstInteractionComplete = true; //Signals that the first response has been logged
                    return choice;
                }
                else print("You're too much of a loser");
                
            }
        }
        if (pos == 1)
        {
            responsePanel2.GetComponent<Image>().color = Color.green;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                pos--;
                responsePanel2.GetComponent<Image>().color = Color.white;

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                pos++;
                responsePanel2.GetComponent<Image>().color = Color.white;

            }
            if (Input.GetKeyUp(KeyCode.Return))
            {
                choice = 2;
                firstInteractionComplete = true;
                return choice;
            }
        }
        if (pos == 2)
        {
            responsePanel3.GetComponent<Image>().color = Color.green;
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                pos--;
                responsePanel3.GetComponent<Image>().color = Color.white;

            }
            if (Input.GetKeyUp(KeyCode.Return))
            {

                choice = 3;
                firstInteractionComplete = true;
                return choice;

            }
        }
        return choice;
    }

    public void ResetInteraction() //Resets the interaction, will be used for repeatable interaction e.g. if a player cannot pass a skill check first time then they can return later with the required level
    {
        firstInteractionComplete = false;
    }
}

