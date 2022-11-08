using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("UI Objects")]
    public GameObject dialogueZone;
    public GameObject npcStatement;
    public GameObject playerFirstResponse;
    public GameObject playerSecondResponse;
    public GameObject playerThirdResponse;
    public GameObject playerFirstResponseBox;
    public GameObject playerSecondResponseBox;
    public GameObject playerThirdResponseBox;

    private GameObject player;
    private DialogueNode activeNode;
    private GameObject activeNPC;
    private bool inConvo = false;
    public int pos = 0;
    public GameObject manager;
    public int relationship = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        manager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if(inConvo) //Checks if the player is still in a conversation
        {
            ContinueConversation();
        }
    }

    public void StartConversation(DialogueNode startNode, GameObject npc) //Is called when a player interacts with an npc and begins a conversation
    {
        activeNPC = npc;
        LoadNodeInfo(startNode); //Loads the intro node info into the dialogue UI
        dialogueZone.SetActive(true);
        player.GetComponent<CharacterController>().enabled = false;
        inConvo = true; //Indicates that the player is in a conversations
    }

    public void ExitConversation() //Is called when the player is finished speaking to an npc
    {
        activeNPC = null;
        dialogueZone.SetActive(false);
        player.GetComponent<CharacterController>().enabled = true;
        inConvo = false;
    }

    public void LoadNodeInfo(DialogueNode newNode) //Is called when we want to load a new npc statement and a new set of player responses
    {
        if(activeNode != null)
        {
            activeNode.nodeActive = false; //Signals that the previous node is no longer active
        }
        activeNode = newNode; //Signals that the new node is active
        newNode.nodeActive = true;
        npcStatement.GetComponent<TextMeshProUGUI>().text = newNode.speech;

        if(activeNode.responses.Length == 0) //Checks if the player has any possible responses
        {
            playerFirstResponse.GetComponent<TextMeshProUGUI>().text = "Press Escape To Leave Conversation"; //Tells the player it's time to leave the conversation
            playerSecondResponseBox.SetActive(false);
            playerThirdResponseBox.SetActive(false);
        }
        if (activeNode.responses.Length == 1) //Checks if the player has only one response
        {
            playerSecondResponseBox.SetActive(false); //Disables the unused text boxes
            playerThirdResponseBox.SetActive(false);
        }
        if (activeNode.responses.Length == 2) //Checks if the player has only two responses
        {
            playerThirdResponseBox.SetActive(false); //Disabled the unused text box
        }

        if (activeNode.responses.Length >= 1)
            playerFirstResponse.GetComponent<TextMeshProUGUI>().text = activeNode.responses[0].ToString(); //Loads the player's first response into the UI 
        if (activeNode.responses.Length >= 2)
            playerSecondResponseBox.SetActive(true);
            playerSecondResponse.GetComponent<TextMeshProUGUI>().text = activeNode.responses[1].ToString(); //Loads the player's second response into the UI
        if (activeNode.responses.Length >= 3)
            playerThirdResponseBox.SetActive(true);
            playerThirdResponse.GetComponent<TextMeshProUGUI>().text = activeNode.responses[2].ToString(); //Loads the player's third response into the UI
        
        
    }

    public void ContinueConversation() //Is called when the player is progressing further into the dialogue tree
    {
        int playerChoice = RecordResponse(); //Retrieves a response from the player's input
        if(playerChoice == 0 && activeNode.repGainResponse1 != 0)
        {
            manager.GetComponent<RelationshipManager>().UpdateCoolMeter(relationship, activeNode.repGainResponse1); //Updates the player's rep level
        }
        if(playerChoice == 1 && activeNode.repGainResponse2 != 0)
        {
            manager.GetComponent<RelationshipManager>().UpdateCoolMeter(relationship, activeNode.repGainResponse2); //''
        }
        if(playerChoice == 2 && activeNode.repGainResponse3 != 0)
        {
            manager.GetComponent<RelationshipManager>().UpdateCoolMeter(relationship, activeNode.repGainResponse3);//''
        }

        if(playerChoice >=0 && playerChoice <= 2) //Checks if the player has made a valid choice
        {           
                LoadNodeInfo(activeNode.children[playerChoice]); //Loads the new node chosen by the player's response        
        }
        inConvo = true;
    }

    public int RecordResponse() //Is called when the player is asked for a response to dialogue
    {
        int choice = 4;
        if(pos == 0) //Checks if the player is currently selecting response 1
        {
            playerFirstResponseBox.GetComponent<Image>().color = Color.cyan;
            if(Input.GetKeyUp(KeyCode.DownArrow))
            {
                
                pos++;
                playerFirstResponseBox.GetComponent<Image>().color = Color.white;
            }
            if(Input.GetKeyUp(KeyCode.Return))
            {
                if (relationship >= activeNode.repLevelOption1) //Checks if the player has the required rep level
                {
                    choice = 0;
                    playerFirstResponseBox.GetComponent<Image>().color = Color.white;
                    print(choice);
                    return choice; //Returns the player's response 
                }
                else if(relationship < activeNode.repLevelOption1)
                {
                    print("Rep Level Not High Enough");
                }
            }
        }
        if (pos == 1) //Checks if the player is currently selecting response 2
        {
            playerSecondResponseBox.GetComponent<Image>().color = Color.cyan;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                
                pos--;
                playerSecondResponseBox.GetComponent<Image>().color = Color.white;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                pos++;
                playerSecondResponseBox.GetComponent<Image>().color = Color.white;
            }
            
            if(Input.GetKeyUp(KeyCode.Return))
            {
                if (relationship >= activeNode.repLevelOption2) //Checks if the player has the required rep level
                {
                    choice = 1;
                    playerSecondResponseBox.GetComponent<Image>().color = Color.white;
                    print(choice);
                    return choice; //Returns the player's response 
                }
                else if (relationship < activeNode.repLevelOption2)
                {
                    print("Rep Level Not High Enough");
                }
            }
        }
        if(pos == 2) //Checks if the player is currently selecting response 3
        {
            playerThirdResponseBox.GetComponent<Image>().color = Color.cyan;
            if(Input.GetKeyUp(KeyCode.UpArrow))
            {
                pos--;
                playerThirdResponseBox.GetComponent<Image>().color = Color.white;
            }
            if (Input.GetKeyUp(KeyCode.Return))
            {
                if (relationship >= activeNode.repLevelOption3) //Checks if the player has the required rep level
                {
                    choice = 2;
                    playerThirdResponseBox.GetComponent<Image>().color = Color.white;
                    print(choice);
                    return choice; //Returns the player's response 
                }
            else if (relationship < activeNode.repLevelOption3)
            {
                print("Rep Level Not High Enough");
            }
            }
        }
        
        return choice;
    }
}
