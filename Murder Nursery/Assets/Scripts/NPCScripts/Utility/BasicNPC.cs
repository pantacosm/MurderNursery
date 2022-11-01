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
    public string npcResponse1A;
    public string npcResponse1B;
    public string npcResponse1C;

    [Header("Player Second Reply Set")] //Second set of player responses
    public string playerResponse2A;
    public string playerResponse2B;
    public string playerResponse2C;

    [Header("NPC Second Reply Set")] //Second set of possible npc replies 
    public string npcRespone2A;
    public string npcResponse2B;
    public string npcResponse2C;

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
