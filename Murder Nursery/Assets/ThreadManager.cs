using System.Collections;
using System.Collections.Generic;
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
        }
        if(firstThreadItem.gameObject.name == "Dislikes")
        {
            newEvidenceImage = secondThreadItem.GetComponent<EvidenceSlot>().evidenceImage;
            newEvidenceText = secondThreadItem.GetComponent<EvidenceSlot>().evidenceText;
            pinBoardManager.GetComponent<PinboardManager>().chaseThreadedDislikes.Add(newEvidenceText);
            pinBoardManager.GetComponent<PinboardManager>().PrintEvidence();
        }
        if(firstThreadItem.gameObject.name == "Events")
        {
            newEvidenceImage = secondThreadItem.GetComponent<EvidenceSlot>().evidenceImage;
            newEvidenceText = secondThreadItem.GetComponent<EvidenceSlot>().evidenceText;
            pinBoardManager.GetComponent<PinboardManager>().chaseThreadedEvents.Add(newEvidenceText);
            pinBoardManager.GetComponent<PinboardManager>().PrintEvidence();
        }
    }
}
