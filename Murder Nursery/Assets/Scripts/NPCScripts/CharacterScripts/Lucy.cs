using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lucy : MonoBehaviour
{
    GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<NPCInteraction>().firstInteractionComplete)
            CheckFirstReply();
    }

    public void CheckFirstReply()
    {
        int firstChoice = this.gameObject.GetComponent<NPCInteraction>().initialChoice;
        if (firstChoice == 1)
            manager.gameObject.GetComponent<DialogueSystem>().LoadNPCStatement(this.gameObject.GetComponent<BasicNPC>().alphaBranchNPC);
        if (firstChoice == 2)
            manager.gameObject.GetComponent<DialogueSystem>().LoadNPCStatement(this.gameObject.GetComponent<BasicNPC>().betaBranchNPC);
        if (firstChoice == 3)
        {
            manager.gameObject.GetComponent<DialogueSystem>().LoadNPCStatement(this.gameObject.GetComponent<BasicNPC>().gammaBranchNPC);
        }
    }
}
