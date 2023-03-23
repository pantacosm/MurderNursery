using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ListeningDevice : MonoBehaviour
{
    public GameObject textPrompt;
    private bool inRange = false;
    public string requiredOutfit;
    public GameObject dressUpManager;
    public GameObject manager;
    public GameObject currentCam;
    public GameObject desiredCam;
    public Image blackFade;
    public GameObject noirFilter;
    public float currentCountdownValue;
    public List<string> npcStatements = new List<string>();
    public GameObject firstTextBox;
    public GameObject secondTextBox;
    public GameObject thirdTextBox;
    public GameObject fourthTextBox;
    public GameObject fifthTextBox;
    public GameObject sixthTextBox;
    public GameObject firstNPCText;
    public GameObject secondNPCText;
    public GameObject thirdNPCText;
    public GameObject fourthNPCText;
    public GameObject fifthNPCText;
    public GameObject sixthNPCText;
    public bool inLD = false;
    private int progress = 0;
    private int convoProgress = 0;
    public GameObject player;
    public GameObject pinboardManager;
    public EvidenceClass heardEvidence;
    private bool evidenceAlreadyCollected = false;

    private bool firstLD = true;
    public GameObject tutorialManager;

    public GameObject notebook;
    public int convoID;
    // Start is called before the first frame update
    void Start()
    {
        dressUpManager = GameObject.FindGameObjectWithTag("Dress Up Manager");
        manager = GameObject.FindGameObjectWithTag("Manager");
        player = GameObject.FindGameObjectWithTag("Player");
        pinboardManager = GameObject.FindGameObjectWithTag("PinBoard Manager");
        progress = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E) && !inLD)
        {
            if (dressUpManager.GetComponent<DressUp>().activeOutfit == requiredOutfit)
            {
                StartListening();
            }
            else
            {
                print("Wrong Outfit");
            }
        }

        if (inLD && Input.GetKeyUp(KeyCode.Return))
        {
            
            switch(convoProgress)
            {
                case 0:
                    progress++;
                    secondTextBox.SetActive(true);
                    secondNPCText.GetComponent<TextMeshProUGUI>().text = npcStatements[progress];
                    convoProgress++;
                    progress++;
                    break;
                case 1:
                    thirdTextBox.SetActive(true);
                    thirdNPCText.GetComponent<TextMeshProUGUI>().text = npcStatements[progress];
                    convoProgress++;
                    progress++;
                    break;
                case 2:
                    if (npcStatements[progress] ==  "BREAK")
                    {
                        ClearDialogue();
                        StartCoroutine(BlackTransition(desiredCam, currentCam, false));
                        StartCoroutine(WaitForSeconds(false));
                        inLD = false;
                        foreach(EvidenceClass evidence in pinboardManager.GetComponent<PinboardManager>().discoveredEvidence)
                        {
                            if(evidence == heardEvidence)
                            {
                                evidenceAlreadyCollected = true;
                            }
                        }
                        if(!heardEvidence.evidenceFound && !evidenceAlreadyCollected)
                        {
                            pinboardManager.GetComponent<PinboardManager>().discoveredEvidence.Add(heardEvidence);
                            pinboardManager.GetComponent<PinboardManager>().UpdateEvidenceImages(heardEvidence);
                            heardEvidence.evidenceFound = true;
                        }
                        break;
                    }
                    firstTextBox.SetActive(false);
                    secondTextBox.SetActive(false);
                    thirdTextBox.SetActive(false);
                    fourthTextBox.SetActive(true);
                    fourthNPCText.GetComponent<TextMeshProUGUI>().text = npcStatements[progress];
                    convoProgress++;
                    progress++;
                    break;
                case 3:
                    if (npcStatements[progress] == "BREAK")
                    {
                        ClearDialogue();
                        StartCoroutine(BlackTransition(desiredCam, currentCam, false));
                        StartCoroutine(WaitForSeconds(false));
                        inLD = false;
                        foreach (EvidenceClass evidence in pinboardManager.GetComponent<PinboardManager>().discoveredEvidence)
                        {
                            if (evidence == heardEvidence)
                            {
                                evidenceAlreadyCollected = true;
                            }
                        }
                        if (!heardEvidence.evidenceFound && !evidenceAlreadyCollected)
                        {
                            pinboardManager.GetComponent<PinboardManager>().discoveredEvidence.Add(heardEvidence);
                            pinboardManager.GetComponent<PinboardManager>().UpdateEvidenceImages(heardEvidence);
                            heardEvidence.evidenceFound = true;
                        }
                        break;
                    }
                    fifthTextBox.SetActive(true);
                    fifthNPCText.GetComponent<TextMeshProUGUI>().text = npcStatements[progress];
                    convoProgress++;
                    progress++;
                    break;
                case 4:
                    if (npcStatements[progress] == "BREAK")
                    {
                        ClearDialogue();
                        StartCoroutine(BlackTransition(desiredCam, currentCam, false));
                        StartCoroutine(WaitForSeconds(false));
                        inLD = false;
                        foreach (EvidenceClass evidence in pinboardManager.GetComponent<PinboardManager>().discoveredEvidence)
                        {
                            if (evidence == heardEvidence)
                            {
                                evidenceAlreadyCollected = true;
                            }
                        }
                        if (!heardEvidence.evidenceFound && !evidenceAlreadyCollected)
                        {
                            pinboardManager.GetComponent<PinboardManager>().discoveredEvidence.Add(heardEvidence);
                            pinboardManager.GetComponent<PinboardManager>().UpdateEvidenceImages(heardEvidence);
                            heardEvidence.evidenceFound = true;
                        }
                        break;
                    }
                    sixthTextBox.SetActive(true);
                    sixthNPCText.GetComponent<TextMeshProUGUI>().text = npcStatements[progress];
                    convoProgress++;
                    progress++;
                    break;
                case 5:
                    if (npcStatements[progress] == "BREAK")
                    {
                        ClearDialogue();
                        StartCoroutine(BlackTransition(desiredCam, currentCam, false));
                        StartCoroutine(WaitForSeconds(false));
                        inLD = false;
                        foreach (EvidenceClass evidence in pinboardManager.GetComponent<PinboardManager>().discoveredEvidence)
                        {
                            if (evidence == heardEvidence)
                            {
                                evidenceAlreadyCollected = true;
                            }
                        }
                        if (!heardEvidence.evidenceFound && !evidenceAlreadyCollected)
                        {
                            pinboardManager.GetComponent<PinboardManager>().discoveredEvidence.Add(heardEvidence);
                            pinboardManager.GetComponent<PinboardManager>().UpdateEvidenceImages(heardEvidence);
                            heardEvidence.evidenceFound = true;
                        }
                        break;
                    }
                    fourthTextBox.SetActive(false);
                    fifthTextBox.SetActive(false);
                    sixthTextBox.SetActive(false);
                    firstTextBox.SetActive(true);
                    firstNPCText.GetComponent<TextMeshProUGUI>().text = npcStatements[progress];
                    convoProgress++;
                    progress++;
                    break;
                case 6:
                    if (npcStatements[progress] == "BREAK")
                    {
                        ClearDialogue();
                        StartCoroutine(BlackTransition(desiredCam, currentCam, false));
                        StartCoroutine(WaitForSeconds(false));
                        inLD = false;
                        foreach (EvidenceClass evidence in pinboardManager.GetComponent<PinboardManager>().discoveredEvidence)
                        {
                            if (evidence == heardEvidence)
                            {
                                evidenceAlreadyCollected = true;
                            }
                        }
                        if (!heardEvidence.evidenceFound && !evidenceAlreadyCollected)
                        {
                            pinboardManager.GetComponent<PinboardManager>().discoveredEvidence.Add(heardEvidence);
                            pinboardManager.GetComponent<PinboardManager>().UpdateEvidenceImages(heardEvidence);
                            heardEvidence.evidenceFound = true;
                        }
                        break;
                    }
                    secondTextBox.SetActive(true);
                    secondNPCText.GetComponent<TextMeshProUGUI>().text = npcStatements[progress];
                    convoProgress++;
                    progress++;
                    break;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(tutorialManager.GetComponent<Tutorials>().firstLD)
            {
                Time.timeScale = 0;
                tutorialManager.GetComponent<Tutorials>().ActivateTutorial(tutorialManager.GetComponent<Tutorials>().ldTutorial);
                tutorialManager.GetComponent<Tutorials>().firstLD = false;
                Cursor.visible = true;
            }
            if (dressUpManager.GetComponent<DressUp>().activeOutfit == requiredOutfit)
            {
                textPrompt.SetActive(true);
            }
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            textPrompt.SetActive(false);
            inRange = false;
        }
    }

    private void StartListening()
    {
        print("calling");
        StartCoroutine(BlackTransition(currentCam, desiredCam, true));
        StartCoroutine(WaitForSeconds(true));
        
        
    }

    public IEnumerator BlackTransition(GameObject currentCam, GameObject desiredCam, bool intoLD, bool transitionToBlack = true, int timeToFade = 1)
    {
        textPrompt.SetActive(false);
        blackFade.gameObject.SetActive(true);
        Color screenColour = blackFade.color;
        float fadeProgress;
        if (transitionToBlack)
        {
            while (blackFade.color.a < 1)
            {
                fadeProgress = screenColour.a + (timeToFade * Time.deltaTime);
                screenColour = new Color(screenColour.r, screenColour.g, screenColour.b, fadeProgress);
                blackFade.color = screenColour;
                if (fadeProgress > 0.95f)
                {

                    ChangeCam(currentCam, desiredCam);

                    noirFilter.GetComponent<PostProcessingActivation>().TurnFilterOn(true);
                    inLD = true;
                    if(intoLD)
                    {
                        player.SetActive(false);
                    }
                    if (!intoLD)
                    {
                        player.SetActive(true);
                    }
                }

                yield return null;
            }
        }
        else
        {
            while (blackFade.color.a > 0)
            {
                fadeProgress = screenColour.a - (timeToFade * Time.deltaTime);
                screenColour = new Color(screenColour.r, screenColour.g, screenColour.b, fadeProgress);
                blackFade.color = screenColour;
                if (fadeProgress < 0.01f)
                {
                    
                    blackFade.gameObject.SetActive(false);
                    if (intoLD)
                    {
                        firstTextBox.SetActive(true);
                        firstNPCText.GetComponent<TextMeshProUGUI>().text = npcStatements[progress];
                        
                    }
                    
                    yield return null;

                }
                yield return null;
            }
        }
    }

    private void ChangeCam(GameObject currentCam, GameObject desiredCam)
    {
        currentCam.SetActive(false);
        desiredCam.SetActive(true);
    }

    public IEnumerator WaitForSeconds(bool intoLD, float countdownValue = 2) //Waits for a specified period of time 
    {
        currentCountdownValue = countdownValue;
        while (currentCountdownValue > 0)
        {
            yield return new WaitForSeconds(1);
            currentCountdownValue--;
        }
        StartCoroutine(BlackTransition(currentCam, desiredCam, intoLD, false));
    }

    private void ClearDialogue()
    {
        switch(convoID)
        {
            case 0:
                 notebook.GetComponent<Notebook>().chaseEddieComplete = true;
                break;
            case 1:
                notebook.GetComponent<Notebook>().scarletEddieComplete = true;
                break;
            case 2: notebook.GetComponent<Notebook>().juiceboxChaseComplete = true;
                break;
        }
        firstNPCText.GetComponent<TextMeshProUGUI>().text = null;
        secondNPCText.GetComponent<TextMeshProUGUI>().text = null;
        thirdNPCText.GetComponent<TextMeshProUGUI>().text = null;
        fourthNPCText.GetComponent<TextMeshProUGUI>().text = null;
        fifthNPCText.GetComponent<TextMeshProUGUI>().text = null;
        sixthNPCText.GetComponent<TextMeshProUGUI>().text = null;
        firstTextBox.SetActive(false);
        secondTextBox.SetActive(false);
        thirdTextBox.SetActive(false);
        fourthTextBox.SetActive(false);
        fifthTextBox.SetActive(false);
        sixthTextBox.SetActive(false);
        convoProgress = 0;
        progress = 0;

    }
    
}
