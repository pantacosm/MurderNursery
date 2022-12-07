using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

// displays characters traits likes/dislikes/events on a pin-board style ui
public class PinboardManager : MonoBehaviour
{
    public static PinboardManager pinboard;

    [HideInInspector]
    public string objectNameBeingReplaced;

    public Transform GoonLikes;
    public Transform GoonDislikes;
    public Transform GoonEvents;

    public Transform CoolGuyLikes;
    public Transform CoolGuyDislikes;
    public Transform CoolGuyEvents;

    public Transform JuiceboxLikes;
    public Transform JuiceboxDislikes;
    public Transform JuiceboxEvents;

    public Transform FemmeLikes;
    public Transform FemmeDislikes;
    public Transform FemmeEvents;

    public Transform DeadGirlLikes;
    public Transform DeadGirlDislikes;
    public Transform DeadGirlEvents;

    [SerializeField]
    GameObject CharacterTraitsUI;

    

    [Header( "Pin-board Content")]
    [Header( "Goon")]
    public string[] goonLikes;
    public string[] goonDislikes;
    public string[] goonEvents;

    [Header( "Cool Guy")]
    public string[] coolguyLikes;
    public string[] coolguyDislikes;
    public string[] coolguyEvents;

    [Header( "Juice Box")]
    public string[] juiceboxLikes;
    public string[] juiceboxDislikes;
    public string[] juiceboxEvents;

    [Header( "Femme")]
    public string[] femmeLikes;
    public string[] femmeDislikes;
    public string[] femmeEvents;

    [Header( "Dead Girl")]
    public string[] deadgirlLikes;
    public string[] deadgirlDislikes;
    public string[] deadgirlEvents;

    public List<EvidenceClass> discoveredEvidence;
    public List<EvidenceClass> undiscoveredEvidence;
    public GameObject evidenceList;
    public GameObject textPrefab;
    public int evidencePiecesPlaced = 0;
    public int correctConclusions = 0;
    public int incorrectConclusions = 0;
    public float rightPercentage = 0.00f;
    public float wrongPercentage = 0.00f;
    public GameObject correctPercentText;
    public GameObject wrongPercentText;
    public GameObject chaseSectionZoom;
    public GameObject scarletSectionZoom;
    public GameObject juiceBoxSectionZoom;
    public GameObject eddieSectionZoom;
    public GameObject graceSectionZoom;
    public GameObject pinBoard;
    public GameObject firstThreadItem;
    public GameObject lastThreadItem;

    public GameObject[] chaseEvidenceSlots;  
    public List<string> chaseThreadedLikes = new List<string>();
    public List<string> chaseThreadedDislikes = new List<string>();
    public List<string> chaseThreadedEvents = new List<string>();

    public GameObject[] scarletEvidenceSlots;
    public List<string> scarletThreadedLikes = new List<string>();
    public List<string> scarletThreadedDislikes = new List<string>();
    public List<string> scarletThreadedEvents = new List<string>();

    public GameObject[] eddieEvidenceSlots;
    public List<string> eddieThreadedLikes = new List<string>();
    public List<string> eddieThreadedDislikes = new List<string>();
    public List<string> eddieThreadedEvents = new List<string>();

    public GameObject[] juiceBoxEvidenceSlots;
    public List<string> juiceBoxThreadedLikes = new List<string>();
    public List<string> juiceBoxThreadedDislikes = new List<string>();
    public List<string> juiceBoxThreadedEvents = new List<string>();

    public GameObject[] graceEvidenceSlots;
    public List<string> graceThreadedLikes = new List<string>();
    public List<string> graceThreadedDislikes = new List<string>();
    public List<string> graceThreadedEvents = new List<string>();
    // Start is called before the first frame update
    void Awake()
    {
        pinboard = this;
    }

    private void Start()
    {
        discoveredEvidence = new List<EvidenceClass>();
        undiscoveredEvidence = new List<EvidenceClass>();
        
        //UpdatePinboard(GoonLikes, goonLikes[0]);
        //UpdatePinboard(GoonLikes, goonLikes[1]);
        //UpdatePinboard(GoonDislikes, goonDislikes[0]);
        //UpdatePinboard(GoonEvents, goonEvents[0]);
        //UpdatePinboard(GoonEvents, goonEvents[1]);

        //UpdatePinboard(JuiceboxLikes, juiceboxLikes[0]);
        //UpdatePinboard(JuiceboxLikes, juiceboxLikes[1]);
        //UpdatePinboard(JuiceboxLikes, juiceboxLikes[2]);
        //UpdatePinboard(JuiceboxDislikes, juiceboxDislikes[0]);
        //UpdatePinboard(JuiceboxEvents, juiceboxEvents[0]);
        //UpdatePinboard(JuiceboxEvents, juiceboxEvents[1]);

        //UpdatePinboard(FemmeLikes, femmeLikes[0]);
        //UpdatePinboard(FemmeDislikes, femmeDislikes[0]);
        //UpdatePinboard(FemmeDislikes, femmeDislikes[1]);

        //UpdatePinboard(CoolGuyLikes, coolguyLikes[0]);
        //UpdatePinboard(CoolGuyLikes, coolguyLikes[1]);
    }

    public void Update()
    {
        
    }

    public void PrintEvidence() 
    {
        if (chaseThreadedLikes.Count > 0)
        {
            foreach (string evidence in chaseThreadedLikes)
            {
                print("Likes: " + evidence);
            }
        }
        if(chaseThreadedDislikes.Count > 0 )
        {
            foreach(string evidence in chaseThreadedDislikes)
            {
                print("Dislikes: " + evidence);
            }
        }
        if(chaseThreadedEvents.Count > 0 )
        {
            foreach(string evidence in chaseThreadedEvents)
            {
                print("Events: " + evidence);
            }
        }
    }

    // Called when we want to update the pin board after discovering a characters likes/dislikes/events
    // content determines whos likes/dislikes/events we are updating / string is what we want the content to say
    public void UpdatePinboard(Transform content, string pinboardText)
    {
        GameObject pinboardObj = Instantiate(CharacterTraitsUI, content);
        var contentText = pinboardObj.transform.Find("TraitsText").GetComponent<TextMeshProUGUI>();
        contentText.text = pinboardText;
    }

    public void UpdateEvidenceListUI(EvidenceClass evidence)
    {
        
        GameObject newEvidence = Instantiate(textPrefab, evidenceList.transform);
        newEvidence.GetComponent<TextMeshProUGUI>().text = evidence.evidenceText;
        newEvidence.GetComponent<DragAndDrop>().itemID = evidence.evidenceID;         
    }

    public void UpdateEvidenceImages(EvidenceClass evidence)
    {
        GameObject newImage = Instantiate(evidence.evidenceImage, evidenceList.transform);
        newImage.GetComponent<DragAndDrop>().itemID = evidence.evidenceID;
    }

    public void UpdateCharacterZone(GameObject characterArea, GameObject evidence)
    {
        Instantiate(evidence, characterArea.transform);
    }
    
    public void CalculateAnswerPercentages()
    {      
        rightPercentage = (correctConclusions / evidencePiecesPlaced) * 100;      
        correctPercentText.GetComponent<TextMeshProUGUI>().text = ("Correct Answers " + rightPercentage + "%");
        wrongPercentage = (incorrectConclusions / evidencePiecesPlaced) * 100;
        wrongPercentText.GetComponent<TextMeshProUGUI>().text = ("Wrong Answers " + wrongPercentage + "%");
    }

    public void TransitionToChaseArea()
    {
        foreach(GameObject slot in chaseEvidenceSlots)
        {
            if(slot.GetComponent<EvidenceSlot>().slotFilled)
            {
                slot.SetActive(true);
            }
        }
        pinBoard.SetActive(false);
        chaseSectionZoom.SetActive(true);
    }

    public void TransitionToScarletArea()
    {
        foreach(GameObject slot in scarletEvidenceSlots)
        {
            if(slot.GetComponent<EvidenceSlot>().slotFilled)
            {
                slot.SetActive(true);
            }
        }
        pinBoard.SetActive(false);
        scarletSectionZoom.SetActive(true);
    }

    public void TransitionToEddieArea()
    {
        foreach(GameObject slot in eddieEvidenceSlots)
        {
            if(slot.GetComponent<EvidenceSlot>().slotFilled)
            {
                slot.SetActive(true);
            }
        }
        pinBoard.SetActive(false);
        eddieSectionZoom.SetActive(true);
    }

    public void TransitionToJuiceBox()
    {
        foreach(GameObject slot in juiceBoxEvidenceSlots)
        {
            if(slot.GetComponent<EvidenceSlot>().slotFilled)
            {
                slot.SetActive(true);
            }
        }
        pinBoard.SetActive(false);
        juiceBoxSectionZoom.SetActive(true);
    }

    public void TransitionToGraceArea()
    {
        foreach (GameObject slot in graceEvidenceSlots)
        {
            if (slot.GetComponent<EvidenceSlot>().slotFilled)
            {
                slot.SetActive(true);
            }
        }
            pinBoard.SetActive(false);
            graceSectionZoom.SetActive(true);
        
    }

    public void TransitionToPinboard()
    {
        pinBoard.SetActive(true);
        chaseSectionZoom.SetActive(false);
        scarletSectionZoom.SetActive(false);
        eddieSectionZoom.SetActive(false);
        juiceBoxSectionZoom.SetActive(false);
        graceSectionZoom.SetActive(false);
    }

    

}
