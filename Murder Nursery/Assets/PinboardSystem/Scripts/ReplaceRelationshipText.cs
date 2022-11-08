using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class ReplaceRelationshipText : MonoBehaviour, IPointerClickHandler
{
    RelationshipComparrison RC;

    [SerializeField]
    GameObject relationshipUI;

    [SerializeField]
    GameObject relationshipOptionsUI;

    string contentText;
    Toggle contentToggle;

    string contentOptionsText;

    private void Start()
    {
        RC = FindObjectOfType<RelationshipComparrison>();

        contentToggle = relationshipUI.transform.Find("Toggle").GetComponent<Toggle>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        RC.relationshipOptionsPanel.SetActive(true);
        contentOptionsText = relationshipOptionsUI.transform.Find("RelationshipOptionsText").GetComponent<TextMeshProUGUI>().text;

        if(contentToggle.isOn == false)
        {
            contentText = relationshipUI.transform.Find("RelationshipText").GetComponent<TextMeshProUGUI>().text;
            Debug.Log(contentText);
        }

    }
}
