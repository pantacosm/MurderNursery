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

    public void OnDrop(PointerEventData eventData)
    {
   
        if(eventData.pointerDrag != null)
    {
            if(eventData.pointerDrag.GetComponent<DragAndDrop>().itemID == slotID)
            {
                Debug.Log("Correct Slot");
            }
            else
            {
                Debug.Log("Incorrect Slot");
            }

            Instantiate(eventData.pointerDrag.GetComponent<DragAndDrop>().itemPrefab, content);

            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
        }
        
    }

}
