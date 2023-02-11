using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interrogation : MonoBehaviour
{
    [Header("Managers")]
    public GameObject manager; //Stores the game manager
    public GameObject PinboardManager; //Stores the pinboard manager
    public GameObject repManager; //Stores the reputation manager

    [Header("UI Objects")]
    public GameObject interrogationPanel; //UI element containing all interrogation components
    public GameObject intResponseBox1; //Player response box 
    public GameObject intResponseBox2; //''
    public GameObject intResponseBox3;//''
    public GameObject intResponseText1;//Player response text
    public GameObject intResponseText2;//''
    public GameObject intResponseText3;//''
    public GameObject npcStatement; //NPC response text
    public GameObject playerResponse1; //Player response option
    public GameObject playerResponse2; //''
    public GameObject npcStatement1; //NPC response text
    public GameObject npcStatement2;//''
    public Image npcSprite1; //Sprite to display the NPC currently being interrogated
    public Image npcSprite2; //''
    public GameObject summaryPanel;

    [Header("Evidence UI Objects")]
    public GameObject evButton; //UI object holding the evidence screen select button
    public GameObject noEvMessage; //Message displayed when the player has no evidence to use
    public GameObject evidencePanel; //UI element containing all evidence screen components
    public Image evidencePiece1; //Image used to display evidence piece
    public Image evidencePiece2; //''
    public Image evidencePiece3;//''
    public List<Sprite> sprites; //List of potential evidence piece sprites

    [Header("Interrogation Variables")]
    [HideInInspector]
    public DialogueNode activeNode; //Stores the currently active node
    public int interrogationLives; //The number of lives the player has available for interrogation
    private GameObject activeInterrogant; //The NPC currently being interrogated
    public bool interrogationUnderway; //Signals that an interrogation is underway

    [Header("Interrogation Audio")]
    public AudioSource interrogationSource; //Audio source for interrogation
    public AudioClip lifeLostSound; //Sound played when the player makes a wrong decision

    //Vectors storing response box positions 
    private Vector3 response1Position;
    private Vector3 response2Position;
    private Vector3 response3Position;

    //Variables for recording player responses
    private int responseCount = 0;
    private string lastResponse = null;
    private string lastResponse2;
    private string npcLastResponse1;
    private string npcLastResponse2;
    private bool firstNode = true;
    private DialogueNode mostRecentChaseNode;
    private bool firstTry = true;
    private DialogueNode mostRecentEddieNode;
    private DialogueNode mostRecentJuiceBoxNode;
    private DialogueNode mostRecentScarletNode;
    private int pos = 0;

   



    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager"); //Finds and stores game manager
        response1Position = new Vector3(2030.744140625f, 326.246826171875f, 0.0f); //Stores UI element position
        response2Position = new Vector3(2030.777587890625f, 228.91348266601563f, 0.0f); //''
    }

    // Update is called once per frame
    void Update()
    {
        interrogationUnderway = manager.GetComponent<SceneTransition>().interrogationActive; //Checks if an interrogation is active

        if(interrogationUnderway) //Allows the player to continue their interrogation
        {
            ContinueInterrogation();
        }
        if(interrogationLives == 0 && interrogationUnderway) //Is called when a player fails an interrogation //NEEDS UPDATED
        {
            BadEnd(2, repManager.GetComponent<ReputationManager>().femmePoints);
        }
        if(interrogationUnderway && activeNode!=null)
        {
            if (activeNode.exitNode == true)
            {
                SuccessfulEnd(); //Is called when a player completes an interrogation successfully
            }
        }
        
        
    }

    public void ContinueInterrogation() //Used for continuing the interrogation sequence
    {
        int j;
        j =  RecordInterrogationResponse(); //Retrieves a response from the player 
        if(j == 0)
        {
            lastResponse = activeNode.responses[0]; //Stores the last response from the player
            pos = 0;
            LoadIntNodeInfo(activeNode.children[j]); //Loads the next node 
        }
        if(j == 1)
        {
            EarlyExit(); //Allows the player to leave an interrogation at a time of their choosing
        }
    }

    public int RecordInterrogationResponse() //Used to retreive a response from the player using keys
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

    public void EarlyExit() //Called when a player wants to leave interrogation
    {
        manager.GetComponent<SceneTransition>().ChangeToMainArea();//Transitions the player back to the main area
        interrogationPanel.SetActive(false); //Deactivates the interrogation UI
        
    }
    public void SuccessfulEnd() //Called when a player succeeds in an interrogation
    {
        manager.GetComponent<SceneTransition>().ChangeToMainArea(); //Transitions the player back to the main area
        interrogationPanel.SetActive(false);
        ClearDialogue(); //Clears the last interrogation's data
    }

    public void BadEnd(int repLoss, int chosenRepLevel) //Is called when a player runs out of lives and fails an interrogation
    {
        chosenRepLevel -= repLoss; //Reputation is lost
        manager.GetComponent<SceneTransition>().ChangeToMainArea(); //Transitions the player back to the main area
        interrogationPanel.SetActive(false);
        ClearDialogue(); //Clears the last interrogation's data
    }

    public void LoadIntNodeInfo(DialogueNode newNode) //Method is used to load a dialogue node's data and update the UI, similar to the method found in DialogueManager
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

    public void StartInterrogation(DialogueNode startNode, GameObject targetNPC) //Is called at the beginning of an interrogation 
    {
        Cursor.visible = true; //CURSOR STUFF - UPDATE
        Cursor.lockState = CursorLockMode.None;
        pos = 0; //Resets selection position
        intResponseBox2.GetComponent<Image>().color = Color.gray; 
        intResponseBox3.GetComponent<Image>().color = Color.gray;
        interrogationLives = 5;
        activeInterrogant = targetNPC;
        if (!firstTry) //Checks if the player has been in this interrogation before
        {
            if(activeInterrogant.name == "JuiceBox (The Artiste)") 
            {
                if(mostRecentJuiceBoxNode == null)
                {
                    LoadIntNodeInfo(startNode);
                }
                else
                LoadIntNodeInfo(mostRecentJuiceBoxNode); //Loads the node that was visited in the last interrogation
            }
            if(activeInterrogant.name == "Scarlet (The Femme Fatale)")
            {
                if(mostRecentScarletNode == null)
                {
                    LoadIntNodeInfo(startNode);
                }
                else
                LoadIntNodeInfo(mostRecentScarletNode); //Loads the node that was visited in the last interrogation
            }
            if(activeInterrogant.name == "Eddie (The Goon)")
            {
                if(mostRecentEddieNode == null)
                {
                    LoadIntNodeInfo(startNode);
                }
                else
                LoadIntNodeInfo(mostRecentEddieNode); //Loads the node that was visited in the last interrogation
            }
            if(activeInterrogant.name == "Chase (The Cool Guy)")
            {
                if (mostRecentChaseNode == null)
                {
                    LoadIntNodeInfo(startNode);
                }
                else
                LoadIntNodeInfo(mostRecentChaseNode); //Loads the node that was visited in the last interrogation
            }
        }
        if (firstTry)
        {
            LoadIntNodeInfo(startNode); //Loads the start node of the interrogation
            firstTry = false; //Signals that the player has attempted the interrogation at least once
        }
        
        
        npcSprite1.sprite = activeInterrogant.GetComponent<NPCDialogue>().sprite; //Updates the NPC sprite with the active NPC's sprite
        npcSprite2.sprite = activeInterrogant.GetComponent<NPCDialogue>().sprite;
    }

    public bool CheckNodeEvidence() //Method is used to determine if the player has the correct evidence //POSSIBLY REDUNDANT
    {
        bool evidencePresent;
        foreach(string evidence in PinboardManager.GetComponent<PinboardManager>().chaseThreadedLikes)
        {
            if (activeNode.evidenceRequired == evidence)
            {
                evidencePresent = true;
                return evidencePresent;
                
            }
        }
        return evidencePresent = false;
    }

    

    private void ClearDialogue() //Clears the dialogue from the UI elements and resets the response count 
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

    public void BringUpEvidencePanel() //Activates the evidence panel UI elements
    {
        evidencePanel.SetActive(true);
        interrogationPanel.SetActive(false);
        if (!activeNode.evImagesGenerated)
        {
            FillEvidenceImages(); //Fills the evidence screen with decoy images and the correct evidence image
        }
    }

    public void ReturnToInterrogationPanel() //Transitions the player back to the interrogation panel
    {
        interrogationPanel.SetActive(true);
        evidencePanel.SetActive(false);
    }

    private void FillEvidenceImages() //Fills the evidence screen with decoy images and the correct evidence image
    {
        if (activeNode.evidenceNeededCheck)
        {
            noEvMessage.SetActive(true); //Signals that the player has no evidence available 
            evidencePiece1.gameObject.SetActive(false);
            evidencePiece2.gameObject.SetActive(false);
            evidencePiece3.gameObject.SetActive(false);
            foreach (string evidence in PinboardManager.GetComponent<PinboardManager>().threadedEvidence) //Checks if the evidence has been threaded
            {
                if (evidence == activeNode.evidenceRequired) //Checks if the evidence is relevant to the active node
                {
                    evidencePiece1.gameObject.SetActive(true);
                    evidencePiece2.gameObject.SetActive(true);
                    evidencePiece3.gameObject.SetActive(true);
                    noEvMessage.SetActive(false);
                    int evImage = Random.Range(0, 2); //Randomises the position of the correcr evidence piece on the screen
                    switch (evImage) //This switch statement is responsible for placing the images in the correct slots 
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
                    activeNode.evImagesGenerated = true; //Marks that the images have been filled for this node
                }
                
            }
        }       
    }

    public void CheckImage(GameObject button) //Used to check whether or not the player has selected the correct piece of evidence 
    {
        if (button.gameObject.GetComponent<Image>().sprite != activeNode.evidenceRequiredImage) //Called when the player selects the wrong option and loads relevant dialogue
        {
            lastResponse = activeNode.responses[2];
            LoadIntNodeInfo(activeNode.children[0]);
            ReturnToInterrogationPanel();
        }
        if (button.gameObject.GetComponent<Image>().sprite == activeNode.evidenceRequiredImage)//Called when the player selects the correct option and loads relevant dialogue
        {
            lastResponse = activeNode.responses[1];
            LoadIntNodeInfo(activeNode.children[1]);
            ReturnToInterrogationPanel();
        }
        
    }

    private void SwitchEmotion() //Method is used to update the emotions displayed by the NPC characters in the interrogation
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
