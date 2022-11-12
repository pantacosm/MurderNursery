using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interrogation : MonoBehaviour
{
    public GameObject manager;
    public GameObject interrogationPanel;
    public bool interrogationUnderway;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        interrogationUnderway = manager.GetComponent<SceneTransition>().interrogationActive;

        if(interrogationUnderway)
        {
            interrogationPanel.SetActive(true);
            this.GetComponent<DialogueManager>().StartConversation(this.GetComponent<SceneTransition>().activeInterrogant.GetComponent<NPCDialogue>().dialogueTree[0], this.GetComponent<SceneTransition>().activeInterrogant);
        }
        if(!interrogationUnderway)
        {
            interrogationPanel.SetActive(false);
        }
    }
}
