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
            this.GetComponent<PinboardThread>().MakeLine(firstThreadItem.transform.position.x, firstThreadItem.transform.position.y, secondThreadItem.transform.position.x, secondThreadItem.transform.position.y, Color.red);
            print("Line created");
            CheckThreadStart();
            firstThreadItem = null;
            secondThreadItem = null;
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
                pinBoardManager.GetComponent<PinboardManager>().PrintEvidence();
            }
            if(firstThreadItem.tag == "ScarletSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().scarletThreadedLikes.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "EddieSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().eddieThreadedLikes.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "JuiceBoxSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().juiceBoxThreadedLikes.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "GraceSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().graceThreadedLikes.Add(newEvidenceText);
            }
            
        }
        if(firstThreadItem.gameObject.name == "Dislikes")
        {
            newEvidenceImage = secondThreadItem.GetComponent<EvidenceSlot>().evidenceImage;
            newEvidenceText = secondThreadItem.GetComponent<EvidenceSlot>().evidenceText;
            if (firstThreadItem.tag == "ChaseSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().chaseThreadedDislikes.Add(newEvidenceText);
                pinBoardManager.GetComponent<PinboardManager>().PrintEvidence();
            }
            if(firstThreadItem.tag == "ScarletSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().scarletThreadedDislikes.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "EddieSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().eddieThreadedDislikes.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "JuiceBoxSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().juiceBoxThreadedDislikes.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "GraceSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().graceThreadedDislikes.Add(newEvidenceText);
            }
        }
        if(firstThreadItem.gameObject.name == "Events")
        {
            newEvidenceImage = secondThreadItem.GetComponent<EvidenceSlot>().evidenceImage;
            newEvidenceText = secondThreadItem.GetComponent<EvidenceSlot>().evidenceText;
            if (firstThreadItem.tag == "ChaseSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().chaseThreadedEvents.Add(newEvidenceText);
                pinBoardManager.GetComponent<PinboardManager>().PrintEvidence();
            }
            if(firstThreadItem.tag == "ScarletSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().scarletThreadedEvents.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "EddieSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().eddieThreadedEvents.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "JuiceBoxSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().juiceBoxThreadedEvents.Add(newEvidenceText);
            }
            if(firstThreadItem.tag == "GraceSlot")
            {
                pinBoardManager.GetComponent<PinboardManager>().graceThreadedEvents.Add(newEvidenceText);
            }
        }
    }
}
