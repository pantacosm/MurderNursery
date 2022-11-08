using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Susie : MonoBehaviour
{
    private GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager"); //Sets up the game manager
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.GetComponent<NPCInteraction>().firstInteractionComplete) //Checks to see whether or not the first choice has been made
            CheckFirstReply();
    }

    public void CheckFirstReply() //Retrieves and stores the player's first reply, also loads the next set of dialogue choices and responses depending on choice.
    {
        int firstChoice = this.gameObject.GetComponent<NPCInteraction>().initialChoice;
        if (firstChoice == 1)
        {
            manager.gameObject.GetComponent<DialogueSystem>().LoadNPCStatement(this.gameObject.GetComponent<BasicNPC>().alphaBranchNPC); 
             
        }

        if(firstChoice == 2)
            manager.gameObject.GetComponent<DialogueSystem>().LoadNPCStatement(this.gameObject.GetComponent<BasicNPC>().betaBranchNPC);
            manager.gameObject.GetComponent<DialogueSystem>().LoadResponses(this.gameObject.GetComponent<BasicNPC>().alphaAlphaBranchPlayer, this.gameObject.GetComponent<BasicNPC>().alphaBetaBranchPlayer, this.gameObject.GetComponent<BasicNPC>().betaAlphaBranchPlayer);
        if (firstChoice == 3)
        {
            manager.gameObject.GetComponent<DialogueSystem>().LoadNPCStatement(this.gameObject.GetComponent<BasicNPC>().gammaBranchNPC);
            manager.gameObject.GetComponent<RelationshipManager>().UpdateCoolMeter(manager.GetComponent<RelationshipManager>().coolMeter, 10); //Updates specific relationship with predetermined value
        }
    }
}
