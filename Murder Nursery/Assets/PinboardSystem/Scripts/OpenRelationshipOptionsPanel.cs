using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// allows player to click relationship text to open an options panel for replacing the text
// with the correct text (uncovers the information about the characters relationship)
public class OpenRelationshipOptionsPanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject relationshipUI;

    RelationshipDetails RD;

    private void Start()
    {
        RD = FindObjectOfType<RelationshipDetails>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        RD.relationshipOptionsPanel.SetActive(true);

        string textToReplace = relationshipUI.transform.Find("RelationshipText").GetComponent<TextMeshProUGUI>().text;
        RD.textToReplace = textToReplace;
    }
}
