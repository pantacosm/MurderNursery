using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInteraction : MonoBehaviour
{
    [SerializeField]
    GameObject uiCanvas;

    GraphicRaycaster uiRaycaster;
    PointerEventData clickData;
    List<RaycastResult> clickResults;

    // Start is called before the first frame update
    void Start()
    {
        uiRaycaster = uiCanvas.GetComponent<GraphicRaycaster>();
        clickData = new PointerEventData(EventSystem.current);
        clickResults = new List<RaycastResult>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasReleasedThisFrame)
        {
            GetUIElementClicked();
        }
    }

    void GetUIElementClicked()
    {
        clickData.position = Mouse.current.position.ReadValue();
        clickResults.Clear();

        uiRaycaster.Raycast(clickData, clickResults);

        foreach (RaycastResult result in clickResults)
        {
            GameObject uiElement = result.gameObject;
            Debug.Log(uiElement.name);
        }
    }
}
