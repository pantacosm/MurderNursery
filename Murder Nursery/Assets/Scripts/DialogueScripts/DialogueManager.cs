using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public GameObject activeNPC;
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
    public AudioSource playerAudio;
    public AudioClip repLossSound;
    public AudioClip repGainSound;
    public AudioClip selectOptionSound;
    public AudioClip changeOptionSound;
    public AudioClip passOutfitCheckSound;
    public Camera currentNPCCam;
    public Camera playerCam;
    public GameObject player;
    public Color unselectedColour;
    public Color selectedColour;
    public Image npcSprite1;
    public Image npcSprite2;
    public Image npcSprite3;
    public Image npcSprite4;
    public GameObject npcStatement2;
    public GameObject npcStatement3;
    public GameObject npcStatement4;
    public GameObject playerResponse1;
    public GameObject playerResponse2;
    public GameObject playerResponse3;
    public GameObject playerResponse4;
    private int responseCount = 0;
    private bool lastResponsePlayer = false;
    private int lastResponseID;
    private bool firstNode = true;
    private string lastResponse;
    private string lastResponse2;
    private string npcLastResponse1;
    private string npcLastResponse2;
    public GameObject inventoryManager;
    public Image item1;
    public Image item2;


    [HideInInspector]
    public GameObject manager;

    [SerializeField]
    GameObject repManager;
    public GameObject pinBoardManager;

    ReputationManager RM;


    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        RM = repManager.GetComponent<ReputationManager>();
        response1Position = new Vector3(1963.9716796875f, 329.7158203125f, 0.0f);
        response2Position = new Vector3(1963.9686279296875f, 232.59219360351563f, 0.0f);
        response3Position = new Vector3(1963.975341796875f, 136.84246826171876f, 0.0f);
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

    public void StartConversation(DialogueNode startNode, GameObject npc, Camera npcCam)
    {
        player.SetActive(false);
        pos = 0;
        playerSecondResponseBox.GetComponent<Image>().color = unselectedColour;
        playerThirdResponseBox.GetComponent<Image>().color = unselectedColour;
        currentNPCCam = npcCam;
        currentNPCCam.gameObject.SetActive(true);
        playerCam.gameObject.SetActive(false);
        activeNPC = npc;
        activeNode = startNode;
        LoadNodeInfo(startNode);
        npcStatement.SetActive(true);
        npcStatement.GetComponent<TextMeshProUGUI>().text = activeNode.speech;
        npcLastResponse1 = activeNode.speech;
        if (startNode.firstPathLocked)
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
        npcSprite1.sprite = npc.GetComponent<NPCDialogue>().sprite;
        npcSprite2.sprite = npc.GetComponent<NPCDialogue>().sprite;
        npcSprite3.sprite = npc.GetComponent<NPCDialogue>().sprite;
        npcSprite4.sprite = npc.GetComponent<NPCDialogue>().sprite;
    }

    public void ExitConversation()
    {
        player.SetActive(true);
        playerCam.gameObject.SetActive(true);
        currentNPCCam.gameObject.SetActive(false);
        //activeNPC = null;
        dialogueZone.SetActive(false);
        inConvo = false;
        ClearDialogue();
    }

    public void LoadNodeInfo(DialogueNode newNode)
    {
        
        if (activeNode != null)
        {
            activeNode.nodeActive = false;
            
        }
        
        if (newNode.fitCheck)
        {
            if (dressUpBox.GetComponent<DressUp>().CheckOutfit(activeNode.requiredOutfit))
            {
                playerAudio.PlayOneShot(passOutfitCheckSound, 0.5f);
                activeNode = newNode.dressUpNode;
            }
        }
        else if (!newNode.fitCheck || !dressUpBox.GetComponent<DressUp>().CheckOutfit(activeNode.requiredOutfit))
        {
            activeNode = newNode;
            
        }
        if (firstNode)
        {
            npcLastResponse1 = activeNode.speech;
        }
        if (!firstNode)
        {
            npcLastResponse2 = npcLastResponse1;
            npcLastResponse1 = activeNode.speech;
            
            UpdateRollingText();
            
        }
        SwitchEmotion();
        if (activeNode.evidenceToDiscover != null && !activeNode.nodeVisited && !activeNode.evidenceToDiscover.evidenceFound)
        {
            pinBoardManager.GetComponent<PinboardManager>().discoveredEvidence.Add(activeNode.evidenceToDiscover);
            //pinBoardManager.GetComponent<PinboardManager>().UpdateEvidenceListUI(activeNode.evidenceToDiscover);
            pinBoardManager.GetComponent<PinboardManager>().UpdateEvidenceImages(activeNode.evidenceToDiscover);
            activeNode.evidenceToDiscover.evidenceFound = true;
        }
        activeNode.nodeActive = true;
        //npcStatement.GetComponent<TextMeshProUGUI>().text = activeNode.speech;
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
        firstNode = false;
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
                playerAudio.PlayOneShot(repGainSound, 0.5f);
                gainingRep = true;
            }
            if(repGain < 0)
            {
                playerAudio.PlayOneShot(repLossSound, 0.5f);
                losingRep = true;
            }
            RM.UpdateReputation(RM.goonPoints += repGain);
            RM.UpdateGoon();
        }
        if (activeNPC == Femme)
        {
            if (repGain > 0)
            {
                playerAudio.PlayOneShot(repGainSound, 0.5f);
                gainingRep = true;
            }
            if (repGain < 0)
            {
                playerAudio.PlayOneShot(repLossSound, 0.5f);
                losingRep = true;
            }
            RM.UpdateReputation(RM.femmePoints += repGain);
            RM.UpdateFemme();
        }
        if (activeNPC == JuiceBox)
        {
            if (repGain > 0)
            {
                playerAudio.PlayOneShot(repGainSound, 0.5f);
                gainingRep = true;
            }
            if (repGain < 0)
            {
                playerAudio.PlayOneShot(repLossSound, 0.5f);
                losingRep = true;

            }
            RM.UpdateReputation(RM.juiceBoxPoints += repGain);
            RM.UpdateJuiceBox();

        }
        if (activeNPC == CoolGuy)
        {
            if (repGain > 0)
            {
                playerAudio.PlayOneShot(repGainSound, 0.5f);
                gainingRep = true;
            }
            if (repGain < 0)
            {
                playerAudio.PlayOneShot(repLossSound, 0.5f);
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
                playerAudio.PlayOneShot(selectOptionSound, 0.5f);
                if (responseCount >= 1)
                {
                    lastResponse2 = lastResponse;
                }
                switch (playerChoice)
                {
                    case 0: lastResponse = activeNode.responses[0];
                        break;
                    case 1: lastResponse = activeNode.responses[1];
                        break;
                    case 2: lastResponse = activeNode.responses[2];
                        break;
                }
                
                responseCount++;
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
            playerFirstResponseBox.GetComponent<Image>().color = Color.green;
            if (Input.GetKeyUp(KeyCode.DownArrow) && activeNode.responses.Length > 1)
            {
                if (activeNode.secondPathLocked)
                {
                    pos = pos + 2;
                    playerAudio.PlayOneShot(changeOptionSound, 0.5f);
                }
                else
                {
                    pos++;
                    playerAudio.PlayOneShot(changeOptionSound, 0.5f);
                }
                playerFirstResponseBox.GetComponent<Image>().color = unselectedColour;
            }
            if(Input.GetKeyUp(KeyCode.Return))
            {
                if (relationship >= activeNode.repLevelOption1)
                {
                    choice = 0;
                    lastResponseID = choice;
                    playerFirstResponseBox.GetComponent<Image>().color = unselectedColour;
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
            playerSecondResponseBox.GetComponent<Image>().color = Color.green; ;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (!activeNode.firstPathLocked)
                {
                    pos--;
                    playerAudio.PlayOneShot(changeOptionSound, 0.5f);
                    playerSecondResponseBox.GetComponent<Image>().color = unselectedColour;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                if (!activeNode.thirdPathLocked)
                {
                    pos++;
                    playerAudio.PlayOneShot(changeOptionSound, 0.5f);
                    playerSecondResponseBox.GetComponent<Image>().color = unselectedColour;
                }
            }
            
            if(Input.GetKeyUp(KeyCode.Return))
            {
                if (relationship >= activeNode.repLevelOption2)
                {
                    choice = 1;
                    lastResponseID = choice;
                    playerSecondResponseBox.GetComponent<Image>().color = unselectedColour;
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
            playerThirdResponseBox.GetComponent<Image>().color = Color.green;
            if(Input.GetKeyUp(KeyCode.UpArrow))
            {
                if (activeNode.secondPathLocked)
                {
                    pos = pos - 2;
                    playerAudio.PlayOneShot(changeOptionSound, 0.5f);
                }
                else
                {
                    pos--;
                    playerAudio.PlayOneShot(changeOptionSound, 0.5f);
                }
                playerThirdResponseBox.GetComponent<Image>().color = unselectedColour;
            }
            if (Input.GetKeyUp(KeyCode.Return))
            {
                if (relationship >= activeNode.repLevelOption3)
                {
                    choice = 2;
                    lastResponseID = choice;
                    playerThirdResponseBox.GetComponent<Image>().color = unselectedColour;
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
        if(inventoryManager.GetComponent<InventoryManager>().items.Count == 3)
        {
            inventoryManager.GetComponent<Bribing>().StoreInfo(inventoryManager.GetComponent<InventoryManager>().items[2]);
            item1.gameObject.SetActive(true);
            item1.sprite = inventoryManager.GetComponent<InventoryManager>().items[2].icon;
        }
        if(inventoryManager.GetComponent<InventoryManager>().items.Count ==4)
        {
            item1.gameObject.SetActive(true);
            item2.gameObject.SetActive(true);
            item1.sprite = inventoryManager.GetComponent<InventoryManager>().items[2].icon;
            item2.sprite = inventoryManager.GetComponent<InventoryManager>().items[3].icon;
        }
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

    private void UpdateRollingText()
    {
        if (responseCount == 1)
        {
            npcStatement.SetActive(true);
            npcStatement.GetComponent<TextMeshProUGUI>().text = npcLastResponse1;          
            npcStatement3.SetActive(true);
            npcStatement3.GetComponent<TextMeshProUGUI>().text = npcLastResponse2;
            playerResponse2.SetActive(true);
            playerResponse2.GetComponent<TextMeshProUGUI>().text = lastResponse;
        }
        if(responseCount >1)
        {
            npcStatement.GetComponent<TextMeshProUGUI>().text = npcLastResponse1;
            npcStatement3.GetComponent<TextMeshProUGUI>().text = npcLastResponse2;
            playerResponse2.GetComponent<TextMeshProUGUI>().text = lastResponse;
            playerResponse4.SetActive(true);
            playerResponse4.GetComponent<TextMeshProUGUI>().text = lastResponse2;
        }
    }

    private void ClearDialogue()
    {
        npcStatement3.GetComponent<TextMeshProUGUI>().text = "";
        npcStatement3.SetActive(false);
        playerResponse2.GetComponent<TextMeshProUGUI>().text = "";
        playerResponse2.SetActive(false);
        playerResponse4.GetComponent<TextMeshProUGUI>().text = "";
        playerResponse4.SetActive(false);
        lastResponse = null;
        lastResponse2 = null;
        responseCount = 0;
    }

    private void SwitchEmotion()
    {
        switch(activeNode.nodeEmotion)
        {
            case 0: activeNPC.GetComponent<NPCDialogue>().textureToChange.SetTexture("_DetailAlbedoMap", activeNPC.GetComponent<NPCDialogue>().defaultEmotion);
                break;
            case 1: activeNPC.GetComponent<NPCDialogue>().textureToChange.SetTexture("_DetailAlbedoMap", activeNPC.GetComponent<NPCDialogue>().angryEmotion);
                break;
            case 2: activeNPC.GetComponent<NPCDialogue>().textureToChange.SetTexture("_DetailAlbedoMap", activeNPC.GetComponent<NPCDialogue>().cryingEmotion);
                break;
            case 3: activeNPC.GetComponent<NPCDialogue>().textureToChange.SetTexture("_DetailAlbedoMap", activeNPC.GetComponent<NPCDialogue>().guiltyEmotion);
                break;
            case 4: activeNPC.GetComponent<NPCDialogue>().textureToChange.SetTexture("_DetailAlbedoMap", activeNPC.GetComponent<NPCDialogue>().playfulEmotion);
                break;
            case 5: activeNPC.GetComponent<NPCDialogue>().textureToChange.SetTexture("_DetailAlbedoMap", activeNPC.GetComponent<NPCDialogue>().sadEmotion);
                break;
            case 6: activeNPC.GetComponent<NPCDialogue>().textureToChange.SetTexture("_DetailAlbedoMap", activeNPC.GetComponent<NPCDialogue>().shockedEmotion);
                break;
            case 7: activeNPC.GetComponent<NPCDialogue>().textureToChange.SetTexture("_DetailAlbedoMap", activeNPC.GetComponent<NPCDialogue>().thinkingEmotion);
                break;
        }
    }
}
