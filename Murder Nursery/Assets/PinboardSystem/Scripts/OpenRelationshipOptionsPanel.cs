using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// allows player to click relationship text to open an options panel for replacing the text
// with the correct text (uncovers the information about the characters relationship)
public class OpenRelationshipOptionsPanel : MonoBehaviour
{

    RelationshipComparrison RC;

    [SerializeField]
    GameObject relationshipUI;

    [HideInInspector]
    public Button buttonObj;

    string currentText;

    private void Start()
    {
        RC = FindObjectOfType<RelationshipComparrison>();
    }

    public void SetActivePanel()
    {
        RC.relationshipOptionsPanel.SetActive(true);
        buttonObj = relationshipUI.transform.Find("RelationshipButton").GetComponent<Button>();
    }

}
