using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicNPC : MonoBehaviour
{
    [Header("First Interaction")] //First set of player responses and first NPC statement
    public string initialStatement;
    public string playerResponse1A; //1 Represents the first stage of dialogue with the character and A represents the response option
    public string playerResponse1B;
    public string playerResponse1C;

    [Header("NPC First Reply Set")] //First set of possible NPC replies
    public string alphaBranchNPC;
    public string betaBranchNPC;
    public string gammaBranchNPC;

    [Header("Player Second Reply Set")] //Second set of player responses
    public string alphaAlphaBranchPlayer;
    public string alphaBetaBranchPlayer;
    public string betaAlphaBranchPlayer;
    public string betaBetaBranchPlayer;
    public string gammaAlphaBranchPlayer;
    public string gammaBetaBranchPlayer;


    [Header("NPC Second Reply Set")] //Second set of possible npc replies 
    public string alphaAlphaBranchNPC;
    public string alphaBetaBranchNPC;
    public string betaAlphaBranchNPC;
    public string gammaAlphaBranchNPC;
    public string gammaBetaBranchNPC;

    [Header("Player Third Reply Set")]
    public string alphaAlphaAlphaBranchPlayer;
    public string alphaAlphaBetaBranchPlayer;
    public string alphaAlphaGammaBranchPlayer;
    public string betaAlphaAlphaBranchPlayer;
    public string betaAlphaBetaBranchPlayer;
    public string gammaAlphaAlphaBranchPlayer;
    public string gammaAlphaBetaBranchPlayer;
    public string gammaBetaAlphaBranchPlayer;

    [Header("NPC Third Reply Set")]
    public string alphaAlphaAlphaBranchNPC;
    public string alphaAlphaGammaBranchNPC;
    public string alphaBetaAlphaBranchNPC;
    public string betaAlphaAlphaBranchNPC;
    public string gammaAlphaAlphaBranchNPC;
    public string gammaAlphaBetaBranchNPC;
    public string gammaBetaAlphaBranchNPC;

    //Yes I know this will exponentially increase in responses but I can handle it :)))))))))))

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
