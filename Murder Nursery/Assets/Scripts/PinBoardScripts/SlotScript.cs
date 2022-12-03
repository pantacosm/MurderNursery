using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour, IDropHandler
{
    [SerializeField]
    Transform content;


    [SerializeField]
    int slotID = 0;


    bool itemInSlot;
    public GameObject pinboardManager;
    public GameObject chaseZone;
    public int chaseCount = 0;
    public int scarletCount = 0;
    public void Start()
    {
        chaseCount = 0;
        scarletCount = 0;
    }
    public void OnDrop(PointerEventData eventData)
    {
   
        if(eventData.pointerDrag != null)
    {
            if(eventData.pointerDrag.GetComponent<DragAndDrop>().itemID == slotID)
            {
                Debug.Log("Correct Slot");
                switch(eventData.pointerDrag.GetComponent<DragAndDrop>().itemID)
                {
                    case 0: print("Chase Evidence Placed");
                        pinboardManager.GetComponent<PinboardManager>().chaseEvidenceSlots[chaseCount].GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
                        pinboardManager.GetComponent<PinboardManager>().chaseEvidenceSlots[chaseCount].GetComponent<EvidenceSlot>().slotFilled = true;
                        pinboardManager.GetComponent<PinboardManager>().chaseEvidenceSlots[chaseCount].GetComponent<EvidenceSlot>().evidenceText = eventData.pointerDrag.GetComponent<EvidenceClass>().evidenceText;
                        chaseCount++;
                        break;
                    case 1: print("Scarlet Evidence Placed");
                        pinboardManager.GetComponent<PinboardManager>().scarletEvidenceSlots[scarletCount].GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
                        pinboardManager.GetComponent<PinboardManager>().scarletEvidenceSlots[scarletCount].GetComponent<EvidenceSlot>().slotFilled = true;
                        pinboardManager.GetComponent<PinboardManager>().scarletEvidenceSlots[scarletCount].GetComponent<EvidenceSlot>().evidenceText = eventData.pointerDrag.GetComponent<EvidenceClass>().evidenceText;
                        scarletCount++;
                        break;
                }
                //pinboardManager.GetComponent<PinboardManager>().correctConclusions++;
                //pinboardManager.GetComponent<PinboardManager>().evidencePiecesPlaced++;
                //pinboardManager.GetComponent<PinboardManager>().CalculateAnswerPercentages();
            }
            else if(eventData.pointerDrag.GetComponent<DragAndDrop>().itemID < slotID || eventData.pointerDrag.GetComponent<DragAndDrop>().itemID > slotID)
            {
                Debug.Log("Incorrect Slot");
                //pinboardManager.GetComponent<PinboardManager>().incorrectConclusions++;
                //pinboardManager.GetComponent<PinboardManager>().evidencePiecesPlaced++;
                //pinboardManager.GetComponent<PinboardManager>().CalculateAnswerPercentages();
            }

            Instantiate(eventData.pointerDrag.GetComponent<DragAndDrop>().itemPrefab, content);
            Destroy(eventData.pointerDrag.GetComponent<DragAndDrop>().itemPrefab);

            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
        }
        
    }

}
