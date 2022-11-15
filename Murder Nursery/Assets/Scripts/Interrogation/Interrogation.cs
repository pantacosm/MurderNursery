using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

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
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        interrogationUnderway = manager.GetComponent<SceneTransition>().interrogationActive;
        if(Input.GetKeyDown(KeyCode.C) && interrogationUnderway)
        {
            UpdateCurrentEmotion(1);
        }
        if(interrogationUnderway)
        {
            ContinueInterrogation();
        }
        if(interrogationLives == 0 && interrogationUnderway)
        {
            BadEnd(2, repManager.GetComponent<ReputationManager>().femmePoints);
        }
        if(interrogationUnderway && activeNode.exitNode == true)
        {
            SuccessfulEnd();
        }
    }

    public void ContinueInterrogation()
    {
        int j;
        j =  RecordInterrogationResponse();
        if(j == 0 || j == 1 || j == 2)
        {
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

    public void UpdateCurrentEmotion(int emotion)
    {
        switch(emotion) //Animations will go here when successful
        {
            case 0:
                print("The NPC is smiling too much, get a grip creep");
                break;
            case 1:
                print("The NPC begins to tremble with fear, clearly you look very ugly today");
                break;
            case 3:
                print("The NPC is getting very red in the face, you begin to fear for your life");
                break;
        }
    }
    public void SuccessfulEnd()
    {
        manager.GetComponent<SceneTransition>().ChangeToMainArea();
        interrogationPanel.SetActive(false);
    }

    public void BadEnd(int repLoss, int chosenRepLevel)
    {
        chosenRepLevel -= repLoss;
        manager.GetComponent<SceneTransition>().ChangeToMainArea();
        interrogationPanel.SetActive(false);
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
            interrogationLives -= activeNode.lifeLoss;
            print("Life Lost!");
        }
    }

    public void StartInterrogation(DialogueNode startNode, GameObject targetNPC)
    {

        interrogationLives = 5;
        LoadIntNodeInfo(startNode);
        activeInterrogant = targetNPC;
    }

}
