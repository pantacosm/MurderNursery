using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interrogation : MonoBehaviour
{
    public GameObject manager;
    public GameObject interrogationPanel;
    public bool interrogationUnderway;
    private int pos = 0;
    public GameObject intResponseBox1;
    public GameObject intResponseBox2;
    public GameObject intResponseBox3;
    public GameObject intResponseText1;
    public GameObject intResponseText2;
    public GameObject intResponseText3;
    public GameObject npcStatement;
    public DialogueNode activeNode;
    public int interrogationLives;
    public GameObject repManager;
    public GameObject activeInterrogant;
    public AudioSource interrogationSource;
    public AudioClip lifeLostSound;
    public GameObject PinboardManager;
    private Vector3 response1Position;
    private Vector3 response2Position;
    private Vector3 response3Position;
    private int responseCount = 0;
    public GameObject playerResponse1;
    public GameObject playerResponse2;
    public GameObject npcStatement1;
    public GameObject npcStatement2;
    private string lastResponse = null;
    private string lastResponse2;
    private string npcLastResponse1;
    private string npcLastResponse2;
    private bool firstNode = true;
    public Image npcSprite1;
    public Image npcSprite2;
    public GameObject evidencePanel;
    public PinboardManager pinManager;
    public Image evidencePiece1;
    public Image evidencePiece2;
    public Image evidencePiece3;
    public List<Sprite> sprites;
    public GameObject evButton;
    public GameObject noEvMessage;
    private DialogueNode mostRecentChaseNode;
    private bool firstTry = true;
    private DialogueNode mostRecentEddieNode;
    private DialogueNode mostRecentJuiceBoxNode;
    private DialogueNode mostRecentScarletNode;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        response1Position = new Vector3(2030.744140625f, 326.246826171875f, 0.0f);
        response2Position = new Vector3(2030.777587890625f, 228.91348266601563f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        interrogationUnderway = manager.GetComponent<SceneTransition>().interrogationActive;
        if(interrogationUnderway)
        {
            ContinueInterrogation();
        }
        if(interrogationLives == 0 && interrogationUnderway)
        {
            BadEnd(2, repManager.GetComponent<ReputationManager>().femmePoints);
        }
        if(interrogationUnderway && activeNode!=null)
        {
            if (activeNode.exitNode == true)
            {
                SuccessfulEnd();
            }
        }
        
        
    }

    public void ContinueInterrogation()
    {
        int j;
        j =  RecordInterrogationResponse();
        if(j == 0)
        {
            lastResponse = activeNode.responses[0];
            pos = 0;
            LoadIntNodeInfo(activeNode.children[j]);         
        }
        if(j == 1)
        {
            EarlyExit();
        }
    }

    public int RecordInterrogationResponse()
    {
        int choice = 4;
        if (pos == 0)
        {
            intResponseBox1.GetComponent<Image>().color = Color.white;
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {

                pos++;
                intResponseBox1.GetComponent<Image>().color = Color.gray;
            }
            if (Input.GetKeyUp(KeyCode.Return))
            {
                
                    choice = 0;
                    intResponseBox1.GetComponent<Image>().color = Color.gray;                   
                    return choice;
                
            }
        }
        if (pos == 1)
        {
            intResponseBox2.GetComponent<Image>().color = Color.white;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                pos--;
                intResponseBox2.GetComponent<Image>().color = Color.gray;
            }
            

            if (Input.GetKeyUp(KeyCode.Return))
            {
                
                    choice = 1;
                    intResponseBox2.GetComponent<Image>().color = Color.gray;
                    return choice;
                
            }
        }
        

        return choice;
    }

    public void EarlyExit()
    {
        manager.GetComponent<SceneTransition>().ChangeToMainArea();
        interrogationPanel.SetActive(false);
        
    }
    public void SuccessfulEnd()
    {
        manager.GetComponent<SceneTransition>().ChangeToMainArea();
        interrogationPanel.SetActive(false);
        ClearDialogue();
    }

    public void BadEnd(int repLoss, int chosenRepLevel)
    {
        chosenRepLevel -= repLoss;
        manager.GetComponent<SceneTransition>().ChangeToMainArea();
        interrogationPanel.SetActive(false);
        ClearDialogue();
    }

    public void LoadIntNodeInfo(DialogueNode newNode)
    {
        if (lastResponse != null)
        {
            playerResponse1.GetComponent<TextMeshProUGUI>().text = "Detective Drew: " + lastResponse;
        }
        if (activeNode != null)
        {
            activeNode.nodeActive = false;
        }
        activeNode = newNode;
        newNode.nodeActive = true;
        SwitchEmotion();
        if(activeInterrogant.name == "JuiceBox (The Artiste)")
        {
            mostRecentJuiceBoxNode = activeNode;
        }
        if(activeInterrogant.name == "Scarlet (The Femme Fatale)")
        {
            mostRecentScarletNode = activeNode;
        }
        if(activeInterrogant.name == "Chase (The Cool Guy)")
        {
            mostRecentChaseNode = activeNode;
        }
        if(activeInterrogant.name == "Eddie (The Goon)")
        {
            mostRecentEddieNode = activeNode;
        }
        npcStatement.GetComponent<TextMeshProUGUI>().text = activeInterrogant.name + ": " + newNode.speech;
        intResponseText1.GetComponent<TextMeshProUGUI>().text = activeNode.responses[0];
        if (activeNode.lifeLoss > 0)
        {
            interrogationSource.PlayOneShot(lifeLostSound, 0.5f);
            interrogationLives -= activeNode.lifeLoss;
        }
        if (activeNode.evidenceNeededCheck)
        {
            evButton.SetActive(true);
        }
        else evButton.SetActive(false);
    }

    public void StartInterrogation(DialogueNode startNode, GameObject targetNPC)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pos = 0;
        intResponseBox2.GetComponent<Image>().color = Color.gray;
        intResponseBox3.GetComponent<Image>().color = Color.gray;
        interrogationLives = 5;
        activeInterrogant = targetNPC;
        if (!firstTry)
        {
            if(activeInterrogant.name == "JuiceBox (The Artiste)")
            {
                if(mostRecentJuiceBoxNode == null)
                {
                    LoadIntNodeInfo(startNode);
                }
                else
                LoadIntNodeInfo(mostRecentJuiceBoxNode);
            }
            if(activeInterrogant.name == "Scarlet (The Femme Fatale)")
            {
                if(mostRecentScarletNode == null)
                {
                    LoadIntNodeInfo(startNode);
                }
                else
                LoadIntNodeInfo(mostRecentScarletNode);
            }
            if(activeInterrogant.name == "Eddie (The Goon)")
            {
                if(mostRecentEddieNode == null)
                {
                    LoadIntNodeInfo(startNode);
                }
                else
                LoadIntNodeInfo(mostRecentEddieNode);
            }
            if(activeInterrogant.name == "Chase (The Cool Guy)")
            {
                if (mostRecentChaseNode == null)
                {
                    LoadIntNodeInfo(startNode);
                }
                else
                LoadIntNodeInfo(mostRecentChaseNode);
            }
        }
        if (firstTry)
        {
            LoadIntNodeInfo(startNode);
            firstTry = false;
        }
        
        
        npcSprite1.sprite = activeInterrogant.GetComponent<NPCDialogue>().sprite;
        npcSprite2.sprite = activeInterrogant.GetComponent<NPCDialogue>().sprite;
    }

    public bool CheckNodeEvidence()
    {
        bool evidencePresent;
        foreach(string evidence in PinboardManager.GetComponent<PinboardManager>().chaseThreadedLikes)
        {
            if (activeNode.pathARequiredEvidence == evidence)
            {
                evidencePresent = true;
                return evidencePresent;
                
            }
        }
        return evidencePresent = false;
    }

    

    private void ClearDialogue()
    {
        npcStatement2.GetComponent<TextMeshProUGUI>().text = "";
        npcStatement2.SetActive(false);
        playerResponse1.GetComponent<TextMeshProUGUI>().text = "";
        playerResponse1.SetActive(false);
        playerResponse2.GetComponent<TextMeshProUGUI>().text = "";
        playerResponse2.SetActive(false);
        lastResponse = null;
        lastResponse2 = null;
        responseCount = 0;
    }

    public void BringUpEvidencePanel()
    {
        evidencePanel.SetActive(true);
        interrogationPanel.SetActive(false);
        if (!activeNode.evImagesGenerated)
        {
            FillEvidenceImages();
        }
    }

    public void ReturnToInterrogationPanel()
    {
        interrogationPanel.SetActive(true);
        evidencePanel.SetActive(false);
    }

    private void FillEvidenceImages()
    {
        if (activeNode.evidenceNeededCheck)
        {
            noEvMessage.SetActive(true);
            evidencePiece1.gameObject.SetActive(false);
            evidencePiece2.gameObject.SetActive(false);
            evidencePiece3.gameObject.SetActive(false);
            foreach (string evidence in pinManager.threadedEvidence)
            {
                if (evidence == activeNode.evidenceRequired)
                {
                    evidencePiece1.gameObject.SetActive(true);
                    evidencePiece2.gameObject.SetActive(true);
                    evidencePiece3.gameObject.SetActive(true);
                    noEvMessage.SetActive(false);
                    int evImage = Random.Range(0, 2);
                    switch (evImage)
                    {
                        case 0:
                            evidencePiece1.sprite = activeNode.evidenceRequiredImage;
                            evidencePiece2.sprite = sprites[Random.Range(0, sprites.Count)];
                            if(evidencePiece2.sprite == activeNode.evidenceRequiredImage)
                            {
                                while(evidencePiece2.sprite == activeNode.evidenceRequiredImage)
                                {
                                    evidencePiece2.sprite = sprites[Random.Range(0, sprites.Count)];
                                }
                            }
                            evidencePiece3.sprite = sprites[Random.Range(0, sprites.Count)];
                            if (evidencePiece3.sprite == activeNode.evidenceRequiredImage)
                            {
                                while (evidencePiece3.sprite == activeNode.evidenceRequiredImage)
                                {
                                    evidencePiece3.sprite = sprites[Random.Range(0, sprites.Count)];
                                }
                            }

                            break;
                        case 1:
                            evidencePiece2.sprite = activeNode.evidenceRequiredImage;
                            evidencePiece1.sprite = sprites[Random.Range(0, sprites.Count)];
                            if (evidencePiece1.sprite == activeNode.evidenceRequiredImage)
                            {
                                while (evidencePiece1.sprite == activeNode.evidenceRequiredImage)
                                {
                                    evidencePiece1.sprite = sprites[Random.Range(0, sprites.Count)];
                                }
                            }
                            evidencePiece3.sprite = sprites[Random.Range(0, sprites.Count)];
                            if (evidencePiece3.sprite == activeNode.evidenceRequiredImage)
                            {
                                while (evidencePiece3.sprite == activeNode.evidenceRequiredImage)
                                {
                                    evidencePiece3.sprite = sprites[Random.Range(0, sprites.Count)];
                                }
                            }
                            break;
                        case 2:
                            evidencePiece3.sprite = activeNode.evidenceRequiredImage;
                            evidencePiece2.sprite = sprites[Random.Range(0, sprites.Count)];
                            if (evidencePiece2.sprite == activeNode.evidenceRequiredImage)
                            {
                                while (evidencePiece2.sprite == activeNode.evidenceRequiredImage)
                                {
                                    evidencePiece2.sprite = sprites[Random.Range(0, sprites.Count)];
                                }
                            }
                            evidencePiece1.sprite = sprites[Random.Range(0, sprites.Count)];
                            if (evidencePiece1.sprite == activeNode.evidenceRequiredImage)
                            {
                                while (evidencePiece1.sprite == activeNode.evidenceRequiredImage)
                                {
                                    evidencePiece1.sprite = sprites[Random.Range(0, sprites.Count)];
                                }
                            }
                            break;
                    }
                    activeNode.evImagesGenerated = true;
                }
                
            }
        }       
    }

    public void CheckImage(GameObject button)
    {
        if (button.gameObject.GetComponent<Image>().sprite != activeNode.evidenceRequiredImage)
        {
            lastResponse = activeNode.responses[2];
            LoadIntNodeInfo(activeNode.children[0]);
            ReturnToInterrogationPanel();
        }
        if (button.gameObject.GetComponent<Image>().sprite == activeNode.evidenceRequiredImage)
        {
            lastResponse = activeNode.responses[1];
            LoadIntNodeInfo(activeNode.children[1]);
            ReturnToInterrogationPanel();
        }
        
    }

    private void SwitchEmotion()
    {
        switch (activeNode.nodeEmotion)
        {
            case 0:
                activeInterrogant.GetComponent<NPCDialogue>().textureToChange.SetTexture("_DetailAlbedoMap", activeInterrogant.GetComponent<NPCDialogue>().defaultEmotion);
                break;
            case 1:
                activeInterrogant.GetComponent<NPCDialogue>().textureToChange.SetTexture("_DetailAlbedoMap", activeInterrogant.GetComponent<NPCDialogue>().angryEmotion);
                break;
            case 2:
                activeInterrogant.GetComponent<NPCDialogue>().textureToChange.SetTexture("_DetailAlbedoMap", activeInterrogant.GetComponent<NPCDialogue>().cryingEmotion);
                break;
            case 3:
                activeInterrogant.GetComponent<NPCDialogue>().textureToChange.SetTexture("_DetailAlbedoMap", activeInterrogant.GetComponent<NPCDialogue>().guiltyEmotion);
                break;
            case 4:
                activeInterrogant.GetComponent<NPCDialogue>().textureToChange.SetTexture("_DetailAlbedoMap", activeInterrogant.GetComponent<NPCDialogue>().playfulEmotion);
                break;
            case 5:
                activeInterrogant.GetComponent<NPCDialogue>().textureToChange.SetTexture("_DetailAlbedoMap", activeInterrogant.GetComponent<NPCDialogue>().sadEmotion);
                break;
            case 6:
                activeInterrogant.GetComponent<NPCDialogue>().textureToChange.SetTexture("_DetailAlbedoMap", activeInterrogant.GetComponent<NPCDialogue>().shockedEmotion);
                break;
            case 7:
                activeInterrogant.GetComponent<NPCDialogue>().textureToChange.SetTexture("_DetailAlbedoMap", activeInterrogant.GetComponent<NPCDialogue>().thinkingEmotion);
                break;
        }
    }
}
