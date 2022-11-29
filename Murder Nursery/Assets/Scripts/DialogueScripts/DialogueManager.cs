using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("UI Objects")]
    public GameObject dialogueZone;
    public GameObject npcStatement;
    public GameObject playerFirstResponse;
    public GameObject playerSecondResponse;
    public GameObject playerThirdResponse;
    public GameObject playerFirstResponseBox;
    public GameObject playerSecondResponseBox;
    public GameObject playerThirdResponseBox;
    public GameObject npcNameArea;
    public GameObject briberyOption;
    public GameObject briberyPanel;
    public Image repGainSprite;
    public Image repLossSprite;

    [Header("Characters")]
    public GameObject Femme;
    public GameObject JuiceBox;
    public GameObject Goon;
    public GameObject CoolGuy;


    private DialogueNode activeNode;
    private GameObject activeNPC;
    public bool inConvo = false;
    public int pos = 0;
    public int relationship = 0;
    public bool gainingRep = false;
    public bool losingRep = false;
    public Vector3 response1Position;
    public Vector3 response2Position;
    public Vector3 response3Position;
    public bool trueEndingReached = false;
    public bool goodEndingReached = false;
    public bool badEndingReached = false;
    public GameObject dressUpBox;


    [HideInInspector]
    public GameObject manager;

    [SerializeField]
    GameObject repManager;

    ReputationManager RM;


    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        RM = repManager.GetComponent<ReputationManager>();
        response1Position = new Vector3(1377.7333984375f, 326.85614013671877f, 0.0f);
        response2Position = new Vector3(1377.738037109375f, 232.59222412109376f, 0.0f);
        response3Position = new Vector3(1377.7333984375f, 143.99176025390626f, 0.0f);


    }

    // Update is called once per frame
    void Update()
    {
        if(inConvo)
        {
            ContinueConversation();
        }
        if(gainingRep)
        {
            for (int i = 0; i < 1; i++)
            {
                StartCoroutine(RepFader(repGainSprite, true));
                StartCoroutine(WaitForSeconds(gainingRep, repGainSprite, 1.5f));
            }
        }
        if(losingRep)
        {
            for(int i = 0; i < 1; i++)
            {
                StartCoroutine(RepFader(repLossSprite, true));
                StartCoroutine(WaitForSeconds(losingRep, repLossSprite, 1.5f));
            }
        }
        if (activeNode != null)
        {
            if (activeNode.exitNode)
            {

                if (activeNode.triggerTrueEnd)
                {
                    trueEndingReached = true;
                    manager.GetComponent<Conclusion>().blackFade.gameObject.SetActive(true);
                    StartCoroutine(manager.GetComponent<Conclusion>().BlackTransition());
                }
                if(activeNode.triggerGoodEnd)
                {
                    goodEndingReached = true;
                    manager.GetComponent<Conclusion>().blackFade.gameObject.SetActive(true);
                    StartCoroutine(manager.GetComponent<Conclusion>().BlackTransition());

                }
                if(activeNode.triggerBadEnd)
                {
                    badEndingReached = true;
                    manager.GetComponent<Conclusion>().blackFade.gameObject.SetActive(true);
                    StartCoroutine(manager.GetComponent<Conclusion>().BlackTransition());
                }
                ExitConversation();
            }
        }
    }

    public void StartConversation(DialogueNode startNode, GameObject npc)
    {
        activeNode = startNode;
        pos = 0;
        playerSecondResponseBox.GetComponent<Image>().color = Color.white;
        playerThirdResponseBox.GetComponent<Image>().color = Color.white;
        activeNPC = npc;
        LoadNodeInfo(startNode);
        if(startNode.firstPathLocked)
        {
            pos = 1;
        }
        if(startNode.firstPathLocked && startNode.secondPathLocked)
        {
            pos = 2;
        }
        dialogueZone.SetActive(true);
        npcNameArea.GetComponent<TextMeshProUGUI>().text = npc.name;

        inConvo = true;
    }

    public void ExitConversation()
    {
        activeNPC = null;
        dialogueZone.SetActive(false);
        inConvo = false;
    }

    public void LoadNodeInfo(DialogueNode newNode)
    {
        if(activeNode != null)
        {
            activeNode.nodeActive = false;
        }
        if (newNode.fitCheck)
        {
            if (dressUpBox.GetComponent<DressUp>().checkOutfit(activeNode.requiredOutfit))
            {
                activeNode = newNode.dressUpNode;
            }
        }
        else if (!newNode.fitCheck || !dressUpBox.GetComponent<DressUp>().checkOutfit(activeNode.requiredOutfit))
        {
            activeNode = newNode;
        }
        activeNode.nodeActive = true;
        npcStatement.GetComponent<TextMeshProUGUI>().text = activeNode.speech;
        if (!activeNode.firstPathLocked)
        {
            playerFirstResponseBox.SetActive(true);
        }
        if(!activeNode.secondPathLocked)
        {
            playerSecondResponseBox.SetActive(true);
        }
        if(!activeNode.thirdPathLocked)
        {
            playerThirdResponseBox.SetActive(true);
        }

        if (activeNode.responses.Length == 0)
        {
            playerFirstResponse.GetComponent<TextMeshProUGUI>().text = "Press Escape To Leave Conversation";
            playerSecondResponseBox.SetActive(false);
            playerThirdResponseBox.SetActive(false);
        }
        if (activeNode.responses.Length == 1)
        {
            playerSecondResponseBox.SetActive(false);
            playerThirdResponseBox.SetActive(false);
        }
        if (activeNode.responses.Length == 2)
        {
            playerThirdResponseBox.SetActive(false);
        }

        if (activeNode.responses.Length >= 1)
            playerFirstResponse.GetComponent<TextMeshProUGUI>().text = activeNode.responses[0].ToString();
        if (activeNode.responses.Length >= 2)
        {
            playerSecondResponseBox.SetActive(true);
            playerSecondResponse.GetComponent<TextMeshProUGUI>().text = activeNode.responses[1].ToString();
        }
        if (activeNode.responses.Length == 3)
        {
            playerThirdResponseBox.SetActive(true);
            playerThirdResponse.GetComponent<TextMeshProUGUI>().text = activeNode.responses[2].ToString();
        }
        if(activeNode.lockingNode)
        {
            if (activeNode.nodeVisited)
            {
                if (activeNode.firstPathLocked)
                {
                    playerFirstResponseBox.SetActive(false);
                }
                
                if (activeNode.secondPathLocked)
                {
                    playerSecondResponseBox.SetActive(false);
                }

                if(activeNode.thirdPathLocked)
                {
                    playerThirdResponseBox.SetActive(false);
                }

                
            }
        }
        MoveOptions();

        if (activeNode.briberyAvailable)
        {
            briberyOption.SetActive(true);
        }
        

    }

    void UpdateRep(int repGain)
    {
        if (activeNPC == Goon)
        {
            if (repGain > 0)
            {
                gainingRep = true;
            }
            if(repGain < 0)
            {
                losingRep = true;
            }
            RM.UpdateReputation(RM.goonPoints += repGain);
            RM.UpdateGoon();
        }
        if (activeNPC == Femme)
        {
            if (repGain > 0)
            {
                gainingRep = true;
            }
            if (repGain < 0)
            {
                losingRep = true;
            }
            RM.UpdateReputation(RM.femmePoints += repGain);
            RM.UpdateFemme();
        }
        if (activeNPC == JuiceBox)
        {
            if (repGain > 0)
            {
                gainingRep = true;
            }
            if (repGain < 0)
            {
                losingRep = true;
            }
            RM.UpdateReputation(RM.juiceBoxPoints += repGain);
            RM.UpdateJuiceBox();

        }
        if (activeNPC == CoolGuy)
        {
            if (repGain > 0)
            {
                gainingRep = true;
            }
            if (repGain < 0)
            {
                losingRep = true;
            }
            RM.UpdateReputation(RM.coolGuyPoints += repGain);
            RM.UpdateCoolGuy();
        }
    }

    public void ContinueConversation()
    {
        int playerChoice = 4;
        playerChoice = RecordResponse();
        if (playerChoice == 0 && activeNode.lockingFirstPath)
        {
            activeNode.firstPathLocked = true;
        }
        if(playerChoice == 1 && activeNode.lockingSecondPath)
        {
            activeNode.secondPathLocked = true;
        }
        if (playerChoice == 2 && activeNode.lockingThirdPath)
        {
            activeNode.thirdPathLocked = true;
        }
        if(activeNode.interrogationNode)
        {
            EnterInterrogation(activeNPC);
            inConvo = false;
        }
        if(playerChoice == 0 && activeNode.repGainResponse1 != 0)
        {
            UpdateRep(activeNode.repGainResponse1);

        }
        if(playerChoice == 1 && activeNode.repGainResponse2 != 0)
        {
            UpdateRep(activeNode.repGainResponse2);
        }
        if(playerChoice == 2 && activeNode.repGainResponse3 != 0)
        {
            UpdateRep(activeNode.repGainResponse3);
        }

        if(playerChoice == 0|| playerChoice == 1 || playerChoice == 2)
        {

            pos = 0;
            if(activeNode.children.Length > 0)
            {
                activeNode.nodeVisited = true;
                LoadNodeInfo(activeNode.children[playerChoice]);               
            }
        }
    }

    public void EnterInterrogation(GameObject targetNPC)
    {
        
        ExitConversation();
        manager.GetComponent<SceneTransition>().ChangeToInterrogation(targetNPC);

    }

    public int RecordResponse()
    {
        int choice = 4;
        if(pos == 0)
        {
            playerFirstResponseBox.GetComponent<Image>().color = Color.cyan;
            if (Input.GetKeyUp(KeyCode.DownArrow) && activeNode.responses.Length > 1)
            {
                if (activeNode.secondPathLocked)
                {
                    pos = pos + 2;
                }
                else
                {
                    pos++;
                }
                playerFirstResponseBox.GetComponent<Image>().color = Color.white;
            }
            if(Input.GetKeyUp(KeyCode.Return))
            {
                if (relationship >= activeNode.repLevelOption1)
                {
                    choice = 0;
                    playerFirstResponseBox.GetComponent<Image>().color = Color.white;
                    print(choice);
                    return choice;
                }
                else if(relationship < activeNode.repLevelOption1)
                {
                    print("Rep Level Not High Enough");
                }
            }
        }
        if (pos == 1)
        {
            playerSecondResponseBox.GetComponent<Image>().color = Color.cyan;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (!activeNode.firstPathLocked)
                {
                    pos--;
                    playerSecondResponseBox.GetComponent<Image>().color = Color.white;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                if (!activeNode.thirdPathLocked)
                {
                    pos++;
                    playerSecondResponseBox.GetComponent<Image>().color = Color.white;
                }
            }
            
            if(Input.GetKeyUp(KeyCode.Return))
            {
                if (relationship >= activeNode.repLevelOption2)
                {
                    choice = 1;
                    playerSecondResponseBox.GetComponent<Image>().color = Color.white;
                    print(choice);
                    return choice;
                }
                else if (relationship < activeNode.repLevelOption2)
                {
                    print("Rep Level Not High Enough");
                }
            }
        }
        if(pos == 2)
        {
            playerThirdResponseBox.GetComponent<Image>().color = Color.cyan;
            if(Input.GetKeyUp(KeyCode.UpArrow))
            {
                if (activeNode.secondPathLocked)
                {
                    pos = pos - 2;
                }
                else
                {
                    pos--;
                }
                playerThirdResponseBox.GetComponent<Image>().color = Color.white;
            }
            if (Input.GetKeyUp(KeyCode.Return))
            {
                if (relationship >= activeNode.repLevelOption3)
                {
                    choice = 2;
                    playerThirdResponseBox.GetComponent<Image>().color = Color.white;
                    print(choice);
                    return choice;
                 }
            else if (relationship < activeNode.repLevelOption3)
            {
                print("Rep Level Not High Enough");
            }
            }
        }
        
        return choice;
    }

    public void Bribery()
    {
        dialogueZone.SetActive(false);
        briberyPanel.SetActive(true);
    }

    public IEnumerator RepFader(Image repSymbol, bool fadeIn, float fadeSpeed = 1f)
    {
        repSymbol.gameObject.SetActive(true);
        Color repColour = repSymbol.color;
        float fadeProgress;
        if(fadeIn)
        {
            
            while(repSymbol.color.a < 1)
            {
                fadeProgress = repColour.a + (fadeSpeed * Time.deltaTime) ;
                repColour = new Color(repColour.r, repColour.g, repColour.b, fadeProgress);
                repSymbol.color = repColour;
                yield return null;
            }

        }
        else
        {
            while(repSymbol.color.a > 0)
            {
                fadeProgress = repColour.a - (fadeSpeed * Time.deltaTime);
                repColour = new Color(repColour.r, repColour.g, repColour.b, fadeProgress);
                repSymbol.color = repColour;
                if(fadeProgress < 0.01f)
                {
                    repSymbol.gameObject.SetActive(false);
                }
                yield return null;
            }
            
        }
    }

    public IEnumerator WaitForSeconds(bool signal, Image sprite, float countdownValue = 2)
    {
        float currentCountdownValue = countdownValue;
        while (currentCountdownValue > 0)
        {
            yield return new WaitForSeconds(1);
            currentCountdownValue--;
        }
        StartCoroutine(RepFader(sprite, false));
        signal = false;
    }

    public void MoveOptions()
    {
        if(!activeNode.nodeVisited)
        {
            playerFirstResponseBox.transform.position = response1Position;
            playerSecondResponseBox.transform.position = response2Position;
            playerThirdResponseBox.transform.position = response3Position;
        }
        else
        if(activeNode.firstPathLocked)
        {
            playerSecondResponseBox.transform.position = response1Position;
            playerThirdResponseBox.transform.position = response2Position;
        }
        if(activeNode.secondPathLocked)
        {
            
            playerFirstResponseBox.transform.position = response1Position;
            playerThirdResponseBox.transform.position = response2Position;
        }
        if(activeNode.firstPathLocked && activeNode.secondPathLocked)
        {
            playerThirdResponseBox.transform.position = response1Position;
        }
        if(activeNode.firstPathLocked && activeNode.thirdPathLocked)
        {
            playerSecondResponseBox.transform.position = response1Position;
        }
    }
}
