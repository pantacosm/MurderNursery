using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FemmeFatale : MonoBehaviour
{
    private GameObject manager;
    private bool cirCalled = false;
    private bool csrCalled = false;
    int firstChoice;
    int alphaChoice = 0;
    int betaChoice = 0;
    int gammaChoice = 0;
    int alphaAlphaChoice = 0;
    int alphaBetaChoice = 0;
    int betaAlphaChoice = 0;
    int betaBetaChoice = 0;
    int gammaAlphaChoice = 0;
    int gammaBetaChoice = 0;
    int alphaAlphaAlphaChoice = 0;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {

        firstChoice = this.gameObject.GetComponent<NPCInteraction>().initialChoice;
        alphaChoice = this.gameObject.GetComponent<NPCInteraction>().alphaChoice;
        betaChoice = this.gameObject.GetComponent<NPCInteraction>().betaChoice;
        gammaChoice = this.gameObject.GetComponent<NPCInteraction>().gammaChoice;
        alphaAlphaChoice = this.gameObject.GetComponent<NPCInteraction>().alphaAlphaChoice;

        if (this.gameObject.GetComponent<NPCInteraction>().initialChoice != 0 && cirCalled == false && this.gameObject.gameObject.GetComponent<NPCInteraction>().chosen) //Checks to see whether or not the first choice has been made
            cirCalled = CheckInitialReply();
        if (cirCalled && this.gameObject.gameObject.GetComponent<NPCInteraction>().chosen == false && csrCalled == false)
            CheckSecondReply();
        if(csrCalled && this.gameObject.gameObject.GetComponent<NPCInteraction>().chosen && this.gameObject.GetComponent<NPCInteraction>().thirdInteractionComplete)            
            CheckThirdReply();
    }

    //One tier npc and two tiers player
   public bool CheckInitialReply()
    {
        if(firstChoice == 1)
        {
            manager.GetComponent<DialogueSystem>().LoadNPCStatement(this.gameObject.GetComponent<BasicNPC>().alphaBranchNPC);
            manager.GetComponent<DialogueSystem>().LoadResponses(this.GetComponent<BasicNPC>().alphaAlphaBranchPlayer, this.GetComponent<BasicNPC>().alphaBetaBranchPlayer);
            return cirCalled = true;
        }
        if(firstChoice == 2)
        {
            manager.GetComponent<DialogueSystem>().LoadNPCStatement(this.gameObject.GetComponent<BasicNPC>().betaBranchNPC);
            manager.GetComponent<DialogueSystem>().LoadResponses(this.GetComponent<BasicNPC>().betaAlphaBranchPlayer, this.GetComponent<BasicNPC>().betaBetaBranchPlayer);
            return cirCalled = true;
        }
        if(firstChoice == 3)
        {
            manager.GetComponent<DialogueSystem>().LoadNPCStatement(this.gameObject.GetComponent<BasicNPC>().gammaBranchNPC);
            manager.GetComponent<DialogueSystem>().LoadResponses(this.GetComponent<BasicNPC>().gammaAlphaBranchPlayer, this.GetComponent<BasicNPC>().gammaBetaBranchPlayer);
            return cirCalled = true;
        }
        this.gameObject.GetComponent<NPCInteraction>().chosen = false;
        return cirCalled;

    }

    //Two tiers NPC and three tiers Player
    public void CheckSecondReply()
    {
        if (alphaChoice == 1)
        {
            manager.GetComponent<DialogueSystem>().LoadNPCStatement(this.gameObject.GetComponent<BasicNPC>().alphaAlphaBranchNPC);
            manager.GetComponent<DialogueSystem>().LoadResponses(this.GetComponent<BasicNPC>().alphaAlphaAlphaBranchPlayer, this.GetComponent<BasicNPC>().alphaAlphaBetaBranchPlayer, this.GetComponent<BasicNPC>().alphaAlphaGammaBranchPlayer);
            csrCalled = true;
        }
        if (alphaChoice == 2)
        {
            manager.GetComponent<DialogueSystem>().LoadNPCStatement(this.gameObject.GetComponent<BasicNPC>().alphaBetaBranchNPC);
            csrCalled = true;

        }
        if(betaChoice == 1)
        {
            manager.GetComponent<DialogueSystem>().LoadNPCStatement(this.gameObject.GetComponent<BasicNPC>().betaAlphaBranchNPC);
            manager.GetComponent<DialogueSystem>().LoadResponses(this.GetComponent<BasicNPC>().betaAlphaAlphaBranchPlayer, this.GetComponent<BasicNPC>().betaAlphaBetaBranchPlayer);
            csrCalled = true;
        }
        if(betaChoice == 2)
        {
            manager.GetComponent<DialogueSystem>().LoadNPCStatement(this.gameObject.GetComponent<BasicNPC>().betaAlphaBranchNPC);
            manager.GetComponent<DialogueSystem>().LoadResponses(this.GetComponent<BasicNPC>().betaAlphaAlphaBranchPlayer, this.GetComponent<BasicNPC>().betaAlphaBetaBranchPlayer);
            csrCalled = true;
        }
        if(gammaChoice == 1)
        {
            manager.GetComponent<DialogueSystem>().LoadNPCStatement(this.gameObject.GetComponent<BasicNPC>().gammaAlphaBranchNPC);
            manager.GetComponent<DialogueSystem>().LoadResponses(this.GetComponent<BasicNPC>().gammaAlphaAlphaBranchPlayer, this.GetComponent<BasicNPC>().gammaAlphaBetaBranchPlayer);
            csrCalled = true;
        }
        if(gammaChoice == 2)
        {
            manager.GetComponent<DialogueSystem>().LoadNPCStatement(this.gameObject.GetComponent<BasicNPC>().gammaBetaBranchNPC);
            manager.GetComponent<DialogueSystem>().LoadResponses(this.gameObject.GetComponent<BasicNPC>().gammaBetaAlphaBranchPlayer);
            csrCalled = true;
        }
        this.gameObject.GetComponent<NPCInteraction>().chosen = true;
    }   

    //Three tiers NPC and four tiers Player
    public void CheckThirdReply()
    {
        print("alphaAlphaChoice " + alphaAlphaChoice);
        if (alphaAlphaChoice == 1)
        {
            manager.GetComponent<DialogueSystem>().LoadNPCStatement(this.GetComponent<BasicNPC>().alphaAlphaAlphaBranchNPC); 
        }
        
        
    }
}
