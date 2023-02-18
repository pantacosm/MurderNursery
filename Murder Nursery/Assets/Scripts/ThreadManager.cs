using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ThreadManager : MonoBehaviour
{
    
    public GameObject firstThreadItem; //The first end of the thread selected by the player
    public GameObject secondThreadItem; //The second end of the thread selected by the player
    public Image newEvidenceImage; //Stores a new evidence image
    public string newEvidenceText; //Stores a new evidence text
    public GameObject pinBoardManager; //Stores the pinboard manager
    

    // Update is called once per frame
    void Update()
    {
        if (firstThreadItem != null && secondThreadItem != null) //Checks if the player has selected two items to thread
        {
            if (!CheckIfThreaded(secondThreadItem.GetComponent<EvidenceSlot>().evidenceText)) //Checks if the evidence has already been threaded
            {
                if (secondThreadItem.name != "Likes" && secondThreadItem.name != "Dislikes" && secondThreadItem.name != "Events") //Checks if the second item is valid and not a category 
                {
                    GameObject newThread = this.GetComponent<PinboardThread>().MakeLine(firstThreadItem.transform.position.x, firstThreadItem.transform.position.y, secondThreadItem.transform.position.x, secondThreadItem.transform.position.y, Color.red); //Creates the thread
                    print("Line created");
                    CheckThreadStart(); //Stores the evidence 
                    secondThreadItem.GetComponent<EvidenceSlot>().thread = newThread;
                    firstThreadItem = null; //Resets the selected items 
                    secondThreadItem = null; //Resets the selected items
                }
            }
        }
    }

    public void CheckThreadStart() //Checks and stores the evidence piece threaded //CHANGE FOR EFFICICENCY 
    {
        if(firstThreadItem.gameObject.name == "Likes") //Stores the likes for each character 
        {
            newEvidenceImage = secondThreadItem.GetComponent<EvidenceSlot>().evidenceImage;
            newEvidenceText = secondThreadItem.GetComponent<EvidenceSlot>().evidenceText;
            if (firstThreadItem.tag == "ChaseSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().chaseThreadedLikes.Add(newEvidenceText);
                pinBoardManager.GetComponent<PinboardManager>().threadedEvidence.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "ScarletSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().scarletThreadedLikes.Add(newEvidenceText);
                pinBoardManager.GetComponent<PinboardManager>().threadedEvidence.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "EddieSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().eddieThreadedLikes.Add(newEvidenceText);
                pinBoardManager.GetComponent<PinboardManager>().threadedEvidence.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "JuiceBoxSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().juiceBoxThreadedLikes.Add(newEvidenceText);
                pinBoardManager.GetComponent<PinboardManager>().threadedEvidence.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "GraceSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().graceThreadedLikes.Add(newEvidenceText);
                pinBoardManager.GetComponent<PinboardManager>().threadedEvidence.Add(newEvidenceText);
            }
            
        }
        if(firstThreadItem.gameObject.name == "Dislikes") //Stores the dislikes for each character 
        {
            newEvidenceImage = secondThreadItem.GetComponent<EvidenceSlot>().evidenceImage;
            newEvidenceText = secondThreadItem.GetComponent<EvidenceSlot>().evidenceText;
            if (firstThreadItem.tag == "ChaseSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().chaseThreadedDislikes.Add(newEvidenceText);
                pinBoardManager.GetComponent<PinboardManager>().threadedEvidence.Add(newEvidenceText);

            }
            if(firstThreadItem.tag == "ScarletSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().scarletThreadedDislikes.Add(newEvidenceText);
                pinBoardManager.GetComponent<PinboardManager>().threadedEvidence.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "EddieSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().eddieThreadedDislikes.Add(newEvidenceText);
                pinBoardManager.GetComponent<PinboardManager>().threadedEvidence.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "JuiceBoxSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().juiceBoxThreadedDislikes.Add(newEvidenceText);
                pinBoardManager.GetComponent<PinboardManager>().threadedEvidence.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "GraceSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().graceThreadedDislikes.Add(newEvidenceText);
                pinBoardManager.GetComponent<PinboardManager>().threadedEvidence.Add(newEvidenceText);
            }
        }
        if(firstThreadItem.gameObject.name == "Events") //Stores the events for each character
        {
            newEvidenceImage = secondThreadItem.GetComponent<EvidenceSlot>().evidenceImage;
            newEvidenceText = secondThreadItem.GetComponent<EvidenceSlot>().evidenceText;
            if (firstThreadItem.tag == "ChaseSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().chaseThreadedEvents.Add(newEvidenceText);
                pinBoardManager.GetComponent<PinboardManager>().threadedEvidence.Add(newEvidenceText);

            }
            if(firstThreadItem.tag == "ScarletSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().scarletThreadedEvents.Add(newEvidenceText);
                pinBoardManager.GetComponent<PinboardManager>().threadedEvidence.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "EddieSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().eddieThreadedEvents.Add(newEvidenceText);
                pinBoardManager.GetComponent<PinboardManager>().threadedEvidence.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "JuiceBoxSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().juiceBoxThreadedEvents.Add(newEvidenceText);
                pinBoardManager.GetComponent<PinboardManager>().threadedEvidence.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "GraceSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().graceThreadedEvents.Add(newEvidenceText);
                pinBoardManager.GetComponent<PinboardManager>().threadedEvidence.Add(newEvidenceText);
            }
        }
    }

    private bool CheckIfThreaded(string evidenceToCheck) //Checks if the evidence has already been threaded
    {
        bool evidenceThreaded = false;
        foreach(string found in pinBoardManager.GetComponent<PinboardManager>().threadedEvidence) //Checks if the evidence is already on the threaded evidence list 
        {
            if(evidenceToCheck == found)
            {
                return evidenceThreaded = true;
            }
        }
        return evidenceThreaded;
    }
}
