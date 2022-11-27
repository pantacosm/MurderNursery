using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode : MonoBehaviour
{
    public DialogueNode parent; //Stores the previous node
    public DialogueNode[] children; //Stores the connected child nodes
    public string speech; //Stores the npc statement
    public string[] responses; //Stores the players possible responses
    public int repLevelOption1; //Rep Level Checker
    public int repLevelOption2; //''
    public int repLevelOption3; //'' 
    public string nodeID;
    public bool nodeActive = false; //Used to indicate if node is active
    public int repGainResponse1; //Rep gained by response
    public int repGainResponse2; //''
    public int repGainResponse3; //'' 
    public bool interrogationNode = false;
    public int lifeLoss = 0;
    public bool exitNode = false;
    public bool firstPathLocked = false;
    public bool secondPathLocked = false;
    public bool thirdPathLocked = false;
    public bool nodeVisited = false;
    public bool lockingNode = false;
    public bool briberyAvailable = false;
    public bool triggerTrueEnd = false;
    public bool triggerGoodEnd = false;
    public bool triggerBadEnd = false;

    private void Start()
    {
        firstPathLocked = false;
        secondPathLocked = false;
        thirdPathLocked = false;
    }
}
