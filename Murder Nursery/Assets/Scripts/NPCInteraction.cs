using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCInteraction : MonoBehaviour
{
    public GameObject manager;
    private bool interactable;
    public GameObject dialoguePanel;
    public GameObject player;
    public bool inConvo;
    // Start is called before the first frame update
    void Start()
    {
        interactable = false;
        ; inConvo = false;
        manager = GameObject.FindGameObjectWithTag("Manager");
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
        dialoguePanel.SetActive(true);
    }

    public void ExitConversation()
    {
        dialoguePanel.SetActive(false);
    }
}
