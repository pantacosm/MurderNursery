using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    
    public GameObject itemPrefab; // the item we wish to drag

    RectTransform rectTrans;
    Canvas myCanvas;
    CanvasGroup canvasGroup;
    
    public int itemID;
    public GameObject hoverOverText;
    public string displayText;
    private Vector2 originalPos;
    public GameObject slotPrefab;
    public GameObject pinboardManager;
    private int i = 0;

    private void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        myCanvas = FindObjectOfType<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        hoverOverText = GameObject.FindGameObjectWithTag("TestText");
        pinboardManager = GameObject.FindGameObjectWithTag("PinBoard Manager");
    }

    // Called when object is clicked on
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            itemPrefab = this.gameObject;
            canvasGroup.blocksRaycasts = false;
            itemPrefab.GetComponent<Image>().maskable = false;
            originalPos = transform.position;
            //hoverOverText.SetActive(true);
            //hoverOverText.GetComponent<TextMeshProUGUI>().text = this.GetComponent<EvidenceClass>().evidenceText;
            //hoverOverText.transform.position = this.transform.position;
        }
        
    }

    // Objects transform position follows mouse position
    public void OnDrag(PointerEventData eventData)
    {
        //rectTrans.anchoredPosition += eventData.delta / myCanvas.scaleFactor;
        gameObject.transform.position = Input.mousePosition;
       // hoverOverText.transform.position = Input.mousePosition;
    }

    // Called when mouse click is released
    public void OnEndDrag(PointerEventData eventData)
    {
        //hoverOverText.SetActive(false);
        canvasGroup.blocksRaycasts = true;
        itemPrefab.GetComponent<Image>().maskable = true;
        pinboardManager.GetComponent<PinboardManager>().slots[i].SetActive(true);
        pinboardManager.GetComponent<PinboardManager>().slots[i].transform.position = eventData.position;
        pinboardManager.GetComponent<PinboardManager>().slots[i].GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
        pinboardManager.GetComponent <PinboardManager>().slots[i].GetComponent<EvidenceSlot>().slotFilled = true;
        pinboardManager.GetComponent<PinboardManager>().slots[i].GetComponent<EvidenceSlot>().evidenceText = eventData.pointerDrag.GetComponent<EvidenceClass>().evidenceText;
        pinboardManager.GetComponent<PinboardManager>().slots[i].GetComponent<EvidenceSlot>().evidenceID = eventData.pointerDrag.GetComponent<EvidenceClass>().evidenceID;
        i++;
        eventData.Reset();
        ResetPosition();


    }


    public void OnMouseExit()
    {
        //hoverOverText.SetActive(false);
    }


    // objects position is set back to original position before being dragged
    public void ResetPosition()
    {
        transform.position = originalPos;
    }

}
