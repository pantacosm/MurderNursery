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
    public bool firstInteractionComplete;
    public int skillBarrier1;
    public bool chosen = false;
    public bool secondInteractionComplete;
    public bool thirdInteractionComplete;
    public bool fourthInteractionComplete;

    [Header("Choice Storers")]
    public int initialChoice = 0;
    public int alphaChoice = 0;
    public int alphaAlphaChoice = 0;
    public int alphaBetaChoice = 0;
    public int alphaGammaChoice = 0;
    public int betaChoice = 0;
    public int betaAlphaChoice = 0;
    public int betaBetaChoice = 0;
    public int betaGammaChoice = 0;
    public int gammaChoice = 0;
    public int gammaAlphaChoice = 0;
    public int gammaBetaChoice = 0;
    public int gammaGammaChoice = 0;
    
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
        secondInteractionComplete = false;
        thirdInteractionComplete = false;
        fourthInteractionComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.name == "FemmeFatale") //Within this are all the femme fatale possibilities
        {
            if (inConvo == false && interactable == true && Input.GetKeyDown(KeyCode.E))
            {
                EnterConverstion();
                inConvo = true;
            }
            if(inConvo == true && Input.GetKeyDown(KeyCode.Escape))
            {
                ExitConversation();
                inConvo = false;
            }
            //First Decision
            if (inConvo == true && initialChoice == 0)
            {
                initialChoice = ChooseResponseEven(firstInteractionComplete);
                print(firstInteractionComplete);
            }
            if (firstInteractionComplete && initialChoice !=0)
            {
                //Second Decision
                if (inConvo == true && initialChoice == 1)
                {
                    alphaChoice = ChooseResponseEven(secondInteractionComplete);
                }

                if (inConvo == true && initialChoice == 2)
                {
                    betaChoice = ChooseResponseEven(secondInteractionComplete);
                }

                if (inConvo == true && initialChoice == 3)
                {
                    gammaChoice = ChooseResponseEven(secondInteractionComplete);
                }
            }

            //Third Decision
            if (secondInteractionComplete && alphaChoice != 0)
            {
                //Alpha
                if (inConvo && alphaChoice == 1 && secondInteractionComplete)
                {
                    alphaAlphaChoice = ChooseResponseOdd(thirdInteractionComplete);
                    print("Choice stored");
                }
                if (inConvo && alphaChoice == 2)
                {
                    alphaBetaChoice = ChooseResponseOdd(thirdInteractionComplete);
                }
                if (inConvo && alphaChoice == 3)
                {
                    alphaGammaChoice = ChooseResponseOdd(thirdInteractionComplete);
                }
                //Beta
                if (inConvo && betaChoice == 1)
                {
                    betaAlphaChoice = ChooseResponseOdd(thirdInteractionComplete);
                }
                if (inConvo && betaChoice == 2)
                {
                    betaBetaChoice = ChooseResponseOdd(thirdInteractionComplete);
                }
                if (inConvo && betaChoice == 3)
                {
                    betaGammaChoice = ChooseResponseOdd(thirdInteractionComplete);
                }
                //Gamma
                if (inConvo && gammaChoice == 1)
                {
                    gammaAlphaChoice = ChooseResponseOdd(thirdInteractionComplete);
                }
                if (inConvo && gammaChoice == 2)
                {
                    gammaBetaChoice = ChooseResponseOdd(thirdInteractionComplete);
                }
                if (inConvo && gammaChoice == 3)
                {
                    gammaGammaChoice = ChooseResponseOdd(thirdInteractionComplete);
                }
            }

            
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
        dialoguePanel.SetActive(true);
        manager.GetComponent<DialogueSystem>().LoadNPCStatement(npcStatement1);
        manager.GetComponent<DialogueSystem>().LoadResponses(playerReply1, playerReply2, playerReply3);
    }

    public void ExitConversation() //Exits the conversation and re-enables player controls
    {
        dialoguePanel.SetActive(false);
        
        
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

    public int ChooseResponseOdd(bool signal) //This is called when the player is mid conversation and is currently choosing a respone
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
                chosen = !chosen;
                MarkAsComplete(signal);
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
                chosen = !chosen;
                MarkAsComplete(signal);
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
                chosen = !chosen;
                MarkAsComplete(signal);
                return choice;

            }
        }
        return choice;
    }

    public int ChooseResponseEven(bool signal) //This is called when the player is mid conversation and is currently choosing a respone
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
            if (Input.GetKeyDown(KeyCode.Return)) //Confirms the player's choice
            {
                choice = 1;
                chosen = !chosen;
                MarkAsComplete(signal);
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
            if (Input.GetKeyDown(KeyCode.Return))
            {
                choice = 2;
                chosen = !chosen;
                MarkAsComplete(signal);
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
            if (Input.GetKeyDown(KeyCode.Return))
            {

                choice = 3;
                chosen = !chosen;
                MarkAsComplete(signal);
                return choice;

            }
        }
        return choice;
    }



    public int ChooseResponseLockedChoiceOne(int skillCheck)
    {
        int choice = 0;
        if (pos == 0)
        {
            if (RelationshipCheck(skillCheck, manager.GetComponent<RelationshipManager>().coolMeter))
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
                if (RelationshipCheck(skillCheck, manager.GetComponent<RelationshipManager>().coolMeter))
                {
                    print("Your relationship is high enough");
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

    public bool MarkAsComplete(bool signal)
    {
        return signal = true;
    }
}

