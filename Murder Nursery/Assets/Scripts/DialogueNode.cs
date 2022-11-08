using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode : MonoBehaviour
{
    public DialogueNode parent;
    public DialogueNode[] children;
    public string speech;
    public string[] responses;
    public int repLevelOption1;
    public int repLevelOption2;
    public int repLevelOption3;
    public string nodeID;
    public bool nodeActive = false;
    public int repGainResponse1;
    public int repGainResponse2;
    public int repGainResponse3;
}
