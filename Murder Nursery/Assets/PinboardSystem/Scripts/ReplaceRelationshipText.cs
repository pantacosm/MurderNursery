using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class ReplaceRelationshipText : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject relationshipUI;

    [SerializeField]
    GameObject relationshipOptionsUI;

    OpenRelationshipOptionsPanel optionsPanel;

    private PinboardManager PM;

    RelationshipComparrison RC;

    private void Start()
    {
        PM = FindObjectOfType<PinboardManager>();
        RC = PM.GetComponent<RelationshipComparrison>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        string replacingText = relationshipOptionsUI.transform.Find("RelationshipOptionsText").GetComponent<TextMeshProUGUI>().text;
        optionsPanel = relationshipUI.GetComponent<OpenRelationshipOptionsPanel>();

        Debug.Log(replacingText);
    }
}
