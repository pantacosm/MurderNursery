using System.Collections;
using System.Collections.Generic;
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
        ResetPosition();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void ResetPosition()
    {
        transform.position = originalPos;
    }
}
