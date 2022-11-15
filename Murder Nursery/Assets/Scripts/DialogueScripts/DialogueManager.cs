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
    public GameObject npcNameArea;

    [Header("Characters")]
    public GameObject Femme;
    public GameObject JuiceBox;
    public GameObject Goon;
    public GameObject CoolGuy;


    private DialogueNode activeNode;
    private GameObject activeNPC;
    private bool inConvo = false;
    public int pos = 0;
    public int relationship = 0;


    [HideInInspector]
    public GameObject manager;

    [SerializeField]
    GameObject repManager;

    ReputationManager RM;


    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        RM = repManager.GetComponent<ReputationManager>();
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
        pos = 0;
        playerSecondResponseBox.GetComponent<Image>().color = Color.white;
        playerThirdResponseBox.GetComponent<Image>().color = Color.white;
        activeNPC = npc;
        LoadNodeInfo(startNode);
        dialogueZone.SetActive(true);
        npcNameArea.GetComponent<TextMeshProUGUI>().text = npc.name;

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
        {
            playerSecondResponseBox.SetActive(true);
            playerSecondResponse.GetComponent<TextMeshProUGUI>().text = activeNode.responses[1].ToString();
        }
        if (activeNode.responses.Length == 3)
        {
            playerThirdResponseBox.SetActive(true);
            playerThirdResponse.GetComponent<TextMeshProUGUI>().text = activeNode.responses[2].ToString();
        }

    }

    void UpdateRep()
    {
        if (activeNPC == Goon)
        {
            RM.UpdateReputation(RM.goonPoints += activeNode.repGainResponse1);
            //RM.UpdateReputation(RM.goonPoints += activeNode.repGainResponse2);
            //RM.UpdateReputation(RM.goonPoints += activeNode.repGainResponse3);
        }
        if (activeNPC == Femme)
        {
            RM.UpdateReputation(RM.femmePoints += activeNode.repGainResponse1);
            //RM.UpdateReputation(RM.femmePoints += activeNode.repGainResponse2);
            //RM.UpdateReputation(RM.femmePoints += activeNode.repGainResponse3);
        }
        if (activeNPC == JuiceBox)
        {
            RM.UpdateReputation(RM.juiceBoxPoints += activeNode.repGainResponse1);
            //RM.UpdateReputation(RM.juiceBoxPoints += activeNode.repGainResponse2);
            //RM.UpdateReputation(RM.juiceBoxPoints += activeNode.repGainResponse3);

        }
        if (activeNPC == CoolGuy)
        {
            RM.UpdateReputation(RM.coolGuyPoints += activeNode.repGainResponse1);
            //RM.UpdateReputation(RM.coolGuyPoints += activeNode.repGainResponse2);
            //RM.UpdateReputation(RM.coolGuyPoints += activeNode.repGainResponse3);
        }
    }

    public void ContinueConversation()
    {
        int playerChoice = RecordResponse();
        if(activeNode.interrogationNode)
        {
            EnterInterrogation(activeNPC);
            inConvo = false;
        }
        if(playerChoice == 0 && activeNode.repGainResponse1 != 0)
        {
            //manager.GetComponent<RelationshipManager>().UpdateCoolMeter(relationship, activeNode.repGainResponse1);
            UpdateRep();

        }
        if(playerChoice == 1 && activeNode.repGainResponse2 != 0)
        {
            // manager.GetComponent<RelationshipManager>().UpdateCoolMeter(relationship, activeNode.repGainResponse2);
            UpdateRep();
        }
        if(playerChoice == 2 && activeNode.repGainResponse3 != 0)
        {
            // manager.GetComponent<RelationshipManager>().UpdateCoolMeter(relationship, activeNode.repGainResponse3);
            UpdateRep();
        }

        if(playerChoice == 0 || playerChoice == 1 || playerChoice == 2)
        {
            pos = 0; 
            LoadNodeInfo(activeNode.children[playerChoice]);           
        }
    }

    public void EnterInterrogation(GameObject targetNPC)
    {
        
        ExitConversation();
        manager.GetComponent<SceneTransition>().ChangeToInterrogation(targetNPC);

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
