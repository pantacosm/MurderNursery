using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interrogation : MonoBehaviour
{
    public GameObject manager;
    public GameObject interrogationPanel;
    public bool interrogationUnderway;
    private int pos = 0;
    public GameObject intResponseBox1;
    public GameObject intResponseBox2;
    public GameObject intResponseBox3;
    public GameObject intResponseText1;
    public GameObject intResponseText2;
    public GameObject intResponseText3;
    public GameObject npcStatement;
    public DialogueNode activeNode;
    public int interrogationLives;
    public GameObject repManager;
    public GameObject activeInterrogant;
    public AudioSource interrogationSource;
    public AudioClip lifeLostSound;
    public GameObject PinboardManager;
    private Vector3 response1Position;
    private Vector3 response2Position;
    private Vector3 response3Position;
    private int responseCount = 0;
    public GameObject playerResponse1;
    public GameObject playerResponse2;
    public GameObject npcStatement1;
    public GameObject npcStatement2;
    private string lastResponse;
    private string lastResponse2;
    private string npcLastResponse1;
    private string npcLastResponse2;
    private bool firstNode = true;
    public Image npcSprite1;
    public Image npcSprite2;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        response1Position = new Vector3(2030.744140625f, 326.246826171875f, 0.0f);
        response2Position = new Vector3(2030.777587890625f, 228.91348266601563f, 0.0f);
        response3Position = new Vector3(2030.7772216796875f, 126.91357421875f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        interrogationUnderway = manager.GetComponent<SceneTransition>().interrogationActive;
        if(interrogationUnderway)
        {
            ContinueInterrogation();
        }
        if(interrogationLives == 0 && interrogationUnderway)
        {
            BadEnd(2, repManager.GetComponent<ReputationManager>().femmePoints);
        }
        if(interrogationUnderway && activeNode!=null)
        {
            if (activeNode.exitNode == true)
            {
                SuccessfulEnd();
            }
        }
        
        
    }

    public void ContinueInterrogation()
    {
        int j;
        j =  RecordInterrogationResponse();
        if(j == 0 || j == 1 || j == 2)
        {
            if (responseCount >= 1)
            {
                lastResponse2 = lastResponse;
            }
            switch (j)
            {
                case 0:
                    lastResponse = activeNode.responses[0];
                    break;
                case 1:
                    lastResponse = activeNode.responses[1];
                    break;
                case 2:
                    lastResponse = activeNode.responses[2];
                    break;
            }
            responseCount++;
            pos = 0;
            LoadIntNodeInfo(activeNode.children[j]);         
        }
    }

    public int RecordInterrogationResponse()
    {
        int choice = 4;
        if (pos == 0)
        {
            intResponseBox1.GetComponent<Image>().color = Color.white;
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {

                pos++;
                intResponseBox1.GetComponent<Image>().color = Color.gray;
            }
            if (Input.GetKeyUp(KeyCode.Return))
            {
                
                    choice = 0;
                    intResponseBox1.GetComponent<Image>().color = Color.gray;
                    print(choice);
                    return choice;
                
            }
        }
        if (pos == 1)
        {
            intResponseBox2.GetComponent<Image>().color = Color.white;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                pos--;
                intResponseBox2.GetComponent<Image>().color = Color.gray;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                pos++;
                intResponseBox2.GetComponent<Image>().color = Color.gray;
            }

            if (Input.GetKeyUp(KeyCode.Return))
            {
                
                    choice = 1;
                    intResponseBox2.GetComponent<Image>().color = Color.gray;
                    print(choice);
                    return choice;
                
            }
        }
        if (pos == 2)
        {
            intResponseBox3.GetComponent<Image>().color = Color.white;
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                pos--;
                intResponseBox3.GetComponent<Image>().color = Color.gray;
            }
            if (Input.GetKeyUp(KeyCode.Return))
            {
                
                    choice = 2;
                    intResponseBox3.GetComponent<Image>().color = Color.gray;
                    print(choice);
                    return choice;               
            }
        }

        return choice;
    }


    public void SuccessfulEnd()
    {
        manager.GetComponent<SceneTransition>().ChangeToMainArea();
        interrogationPanel.SetActive(false);
        ClearDialogue();
    }

    public void BadEnd(int repLoss, int chosenRepLevel)
    {
        chosenRepLevel -= repLoss;
        manager.GetComponent<SceneTransition>().ChangeToMainArea();
        interrogationPanel.SetActive(false);
        ClearDialogue();
    }

    public void LoadIntNodeInfo(DialogueNode newNode)
    {
        if (activeNode != null)
        {
            activeNode.nodeActive = false;
        }
        activeNode = newNode;
        newNode.nodeActive = true;
        npcStatement.GetComponent<TextMeshProUGUI>().text = newNode.speech;
        if(firstNode)
        {
            npcLastResponse1 = activeNode.speech;
        }
        if(!firstNode)
        {
            npcLastResponse2 = npcLastResponse1;
            npcLastResponse1 = activeNode.speech;

            UpdateRollingText();
        }

        if (activeNode.responses.Length == 0)
        {
            intResponseText1.GetComponent<TextMeshProUGUI>().text = "Press Escape To Leave Conversation";
            intResponseBox2.SetActive(false);
            intResponseBox3.SetActive(false);
        }
        if (activeNode.responses.Length == 1)
        {
            intResponseBox2.SetActive(false);
            intResponseBox3.SetActive(false);
        }
        if (activeNode.responses.Length == 2)
        {
            intResponseBox3.SetActive(false);
        }

        if (activeNode.responses.Length >= 1)
            intResponseText1.GetComponent<TextMeshProUGUI>().text = activeNode.responses[0].ToString();
        if (activeNode.responses.Length >= 2)
        {
            intResponseBox2.SetActive(true);
            intResponseText2.GetComponent<TextMeshProUGUI>().text = activeNode.responses[1].ToString();
        }
        if (activeNode.responses.Length == 3)
        {
            intResponseBox3.SetActive(true);
            intResponseText3.GetComponent<TextMeshProUGUI>().text = activeNode.responses[2].ToString();
        }
        if (activeNode.lifeLoss > 0)
        {
            interrogationSource.PlayOneShot(lifeLostSound, 0.5f);
            interrogationLives -= activeNode.lifeLoss;
            print("Life Lost!");
        }
        if(activeNode.evidenceCheckNode)
        {
            if(activeNode.pathAInterrogationEvidenceRequired)
            {
                intResponseBox1.SetActive(false);
                activeNode.firstPathLocked = true;
                if(CheckNodeEvidence())
                {
                    intResponseBox1.SetActive(true);
                    activeNode.firstPathLocked = false;
                }
            }
        }
        MoveOptions();
        firstNode = false;
    }

    public void StartInterrogation(DialogueNode startNode, GameObject targetNPC)
    {
        pos = 0;
        intResponseBox2.GetComponent<Image>().color = Color.gray;
        intResponseBox3.GetComponent<Image>().color = Color.gray;
        interrogationLives = 5;
        LoadIntNodeInfo(startNode);
        activeInterrogant = targetNPC;
        npcSprite1.sprite = activeInterrogant.GetComponent<NPCDialogue>().sprite;
        npcSprite2.sprite = activeInterrogant.GetComponent<NPCDialogue>().sprite;
    }

    public bool CheckNodeEvidence()
    {
        bool evidencePresent;
        foreach(string evidence in PinboardManager.GetComponent<PinboardManager>().chaseThreadedLikes)
        {
            if (activeNode.pathARequiredEvidence == evidence)
            {
                evidencePresent = true;
                return evidencePresent;
                
            }
        }
        return evidencePresent = false;
    }

    public void MoveOptions()
    {
        
        if (activeNode.firstPathLocked)
        {
            intResponseBox2.transform.position = response1Position;
            intResponseBox3.transform.position = response2Position;
        }
        if (activeNode.secondPathLocked)
        {

            intResponseBox1.transform.position = response1Position;
            intResponseBox3.transform.position = response2Position;
        }
        if (activeNode.firstPathLocked && activeNode.secondPathLocked)
        {
            intResponseBox3.transform.position = response1Position;
        }
        if (activeNode.firstPathLocked && activeNode.thirdPathLocked)
        {
            intResponseBox2.transform.position = response1Position;
        }
    }

    private void UpdateRollingText()
    {
        if (responseCount == 1)
        {
            npcStatement.SetActive(true);
            npcStatement.GetComponent<TextMeshProUGUI>().text = npcLastResponse1;
            npcStatement2.SetActive(true);
            npcStatement2.GetComponent<TextMeshProUGUI>().text = npcLastResponse2;
            playerResponse1.SetActive(true);
            playerResponse1.GetComponent<TextMeshProUGUI>().text = lastResponse;
        }
        if (responseCount > 1)
        {
            npcStatement.GetComponent<TextMeshProUGUI>().text = npcLastResponse1;
            npcStatement2.GetComponent<TextMeshProUGUI>().text = npcLastResponse2;
            playerResponse1.GetComponent<TextMeshProUGUI>().text = lastResponse;
            playerResponse2.SetActive(true);
            playerResponse2.GetComponent<TextMeshProUGUI>().text = lastResponse2;
        }
    }

    private void ClearDialogue()
    {
        npcStatement2.GetComponent<TextMeshProUGUI>().text = "";
        npcStatement2.SetActive(false);
        playerResponse1.GetComponent<TextMeshProUGUI>().text = "";
        playerResponse1.SetActive(false);
        playerResponse2.GetComponent<TextMeshProUGUI>().text = "";
        playerResponse2.SetActive(false);
        lastResponse = null;
        lastResponse2 = null;
        responseCount = 0;
    }
}
