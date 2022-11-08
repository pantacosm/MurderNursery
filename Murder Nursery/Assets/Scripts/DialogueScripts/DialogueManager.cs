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

    private DialogueNode activeNode;
    private GameObject activeNPC;
    private bool inConvo = false;
    public int pos = 0;
    public int relationship = 0;

    [HideInInspector]
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if(inConvo)
        {
            ContinueConversation();
        }
    }

    public void StartConversation(DialogueNode startNode, GameObject npc)
    {
        activeNPC = npc;
        LoadNodeInfo(startNode);
        dialogueZone.SetActive(true);
        inConvo = true;
    }

    public void ExitConversation()
    {
        activeNPC = null;
        dialogueZone.SetActive(false);
        inConvo = false;
    }

    public void LoadNodeInfo(DialogueNode newNode)
    {
        if(activeNode != null)
        {
            activeNode.nodeActive = false;
        }
        activeNode = newNode;
        newNode.nodeActive = true;
        npcStatement.GetComponent<TextMeshProUGUI>().text = newNode.speech;

        if(activeNode.responses.Length == 0)
        {
            playerFirstResponse.GetComponent<TextMeshProUGUI>().text = "Press Escape To Leave Conversation";
            playerSecondResponseBox.SetActive(false);
            playerThirdResponseBox.SetActive(false);
        }
        if (activeNode.responses.Length == 1)
        {
            playerSecondResponseBox.SetActive(false);
            playerThirdResponseBox.SetActive(false);
        }
        if (activeNode.responses.Length == 2)
        {
            playerThirdResponseBox.SetActive(false);
        }

        if (activeNode.responses.Length >= 1)
            playerFirstResponse.GetComponent<TextMeshProUGUI>().text = activeNode.responses[0].ToString();
        if (activeNode.responses.Length >= 2)
            playerSecondResponseBox.SetActive(true);
        playerSecondResponse.GetComponent<TextMeshProUGUI>().text = activeNode.responses[1].ToString();
        if (activeNode.responses.Length >= 3)
            playerThirdResponseBox.SetActive(true);
        playerThirdResponse.GetComponent<TextMeshProUGUI>().text = activeNode.responses[2].ToString();

    }

    public void ContinueConversation()
    {
        int playerChoice = RecordResponse();
        if(playerChoice == 0 && activeNode.repGainResponse1 != 0)
        {
            manager.GetComponent<RelationshipManager>().UpdateCoolMeter(relationship, activeNode.repGainResponse1);
        }
        if(playerChoice == 1 && activeNode.repGainResponse2 != 0)
        {
            manager.GetComponent<RelationshipManager>().UpdateCoolMeter(relationship, activeNode.repGainResponse2);
        }
        if(playerChoice == 2 && activeNode.repGainResponse3 != 0)
        {
            manager.GetComponent<RelationshipManager>().UpdateCoolMeter(relationship, activeNode.repGainResponse3);
        }

        if(playerChoice >=0 && playerChoice <= 2)
        {           
                LoadNodeInfo(activeNode.children[playerChoice]);           
        }
        inConvo = true;
    }

    public int RecordResponse()
    {
        int choice = 4;
        if(pos == 0)
        {
            playerFirstResponseBox.GetComponent<Image>().color = Color.cyan;
            if(Input.GetKeyUp(KeyCode.DownArrow))
            {
                
                pos++;
                playerFirstResponseBox.GetComponent<Image>().color = Color.white;
            }
            if(Input.GetKeyUp(KeyCode.Return))
            {
                if (relationship >= activeNode.repLevelOption1)
                {
                    choice = 0;
                    playerFirstResponseBox.GetComponent<Image>().color = Color.white;
                    print(choice);
                    return choice;
                }
                else if(relationship < activeNode.repLevelOption1)
                {
                    print("Rep Level Not High Enough");
                }
            }
        }
        if (pos == 1)
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
                if (relationship >= activeNode.repLevelOption2)
                {
                    choice = 1;
                    playerSecondResponseBox.GetComponent<Image>().color = Color.white;
                    print(choice);
                    return choice;
                }
                else if (relationship < activeNode.repLevelOption2)
                {
                    print("Rep Level Not High Enough");
                }
            }
        }
        if(pos == 2)
        {
            playerThirdResponseBox.GetComponent<Image>().color = Color.cyan;
            if(Input.GetKeyUp(KeyCode.UpArrow))
            {
                pos--;
                playerThirdResponseBox.GetComponent<Image>().color = Color.white;
            }
            if (Input.GetKeyUp(KeyCode.Return))
            {
                if (relationship >= activeNode.repLevelOption3)
                {
                    choice = 2;
                    playerThirdResponseBox.GetComponent<Image>().color = Color.white;
                    print(choice);
                    return choice;
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
