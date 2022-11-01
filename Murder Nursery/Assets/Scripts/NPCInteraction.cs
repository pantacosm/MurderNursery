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
    int choice = 0;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (inConvo == false && interactable == true && Input.GetKeyDown(KeyCode.E))
        {
            print("In Convo");
            EnterConverstion();
            inConvo = true;
        }

        if (inConvo == true && Input.GetKey(KeyCode.Escape))
        {
            ExitConversation();
            inConvo = false;
        }

        if (inConvo == true)
        {
            if (pos == 0)
            {
                responsePanel1.GetComponent<Image>().color = Color.red;
                if (Input.GetKeyUp(KeyCode.DownArrow))
                {                    
                    responsePanel1.GetComponent<Image>().color = Color.white;
                    pos++;

                }
                if (Input.GetKeyUp(KeyCode.Return))
                {
                    choice = 1;
                    ExitConversation();
                }
            }
            if (pos == 1)
            {
                responsePanel2.GetComponent<Image>().color = Color.red;
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
                    ExitConversation();
                }
            }
            if (pos == 2)
            {
                responsePanel3.GetComponent<Image>().color = Color.red;
                if (Input.GetKeyUp(KeyCode.UpArrow))
                {
                    pos--;
                    responsePanel3.GetComponent<Image>().color = Color.white;

                }
                if (Input.GetKeyUp(KeyCode.Return))
                {

                    choice = 3;
                    ExitConversation();

                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactable = false;
        }
    }

    public void EnterConverstion()
    {
        player.GetComponent<PlayerMovement>().playerSpeed = 0f;
        player.GetComponent<PlayerMovement>().jumpHeight = 0f;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        dialoguePanel.SetActive(true);
        manager.GetComponent<DialogueSystem>().LoadNPCStatement(npcStatement1);
        manager.GetComponent<DialogueSystem>().LoadResponses(playerReply1, playerReply2, playerReply3);
    }

    public void ExitConversation()
    {
        player.GetComponent<PlayerMovement>().playerSpeed = 4.0f;
        player.GetComponent<PlayerMovement>().jumpHeight = 1.0f;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        dialoguePanel.SetActive(false);
        print(choice);
    }
}
