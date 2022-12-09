using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ThreadManager : MonoBehaviour
{
    
    public GameObject firstThreadItem;
    public GameObject secondThreadItem;
    public Image newEvidenceImage;
    public string newEvidenceText;
    public GameObject pinBoardManager;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (firstThreadItem != null && secondThreadItem != null)
        {
            if (!CheckIfThreaded(secondThreadItem.GetComponent<EvidenceSlot>().evidenceText))
            {
                if (secondThreadItem.name != "Likes" && secondThreadItem.name != "Dislikes" && secondThreadItem.name != "Events")
                {
                    this.GetComponent<PinboardThread>().MakeLine(firstThreadItem.transform.position.x, firstThreadItem.transform.position.y, secondThreadItem.transform.position.x, secondThreadItem.transform.position.y, Color.red);
                    print("Line created");
                    CheckThreadStart();
                    firstThreadItem = null;
                    secondThreadItem = null;
                }
            }
        }
    }

    public void CheckThreadStart()
    {
        if(firstThreadItem.gameObject.name == "Likes")
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
        if(firstThreadItem.gameObject.name == "Dislikes")
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
        if(firstThreadItem.gameObject.name == "Events")
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

    private bool CheckIfThreaded(string evidenceToCheck)
    {
        bool evidenceThreaded = false;
        foreach(string found in pinBoardManager.GetComponent<PinboardManager>().threadedEvidence)
        {
            if(evidenceToCheck == found)
            {
                return evidenceThreaded = true;
            }
        }
        return evidenceThreaded;
    }
}
