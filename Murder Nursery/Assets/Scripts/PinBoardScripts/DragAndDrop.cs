using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    public GameObject itemPrefab;

    RectTransform rectTrans;
    Canvas myCanvas;
    CanvasGroup canvasGroup;

    [HideInInspector]
    public Image itemImage;
    
    public int itemID;
    public GameObject hoverOverText;

    private Vector2 originalPos;

    private void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        myCanvas = FindObjectOfType<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        itemImage = GetComponent<Image>();
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemPrefab = this.gameObject;
        canvasGroup.blocksRaycasts = false;
        itemImage.maskable = false;
        itemPrefab.GetComponent<Image>().maskable = false;
        originalPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTrans.anchoredPosition += eventData.delta / myCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        itemImage.maskable = true;
        itemPrefab.GetComponent<Image>().maskable = true;
        ResetPosition();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnMouseOver()
    {
        hoverOverText.SetActive(true);
        hoverOverText.GetComponent<TextMeshProUGUI>().text = this.GetComponent<EvidenceClass>().evidenceText;
    }

    public void OnMouseExit()
    {
        hoverOverText.SetActive(false);
    }

    public void ResetPosition()
    {
        transform.position = originalPos;
    }
}
