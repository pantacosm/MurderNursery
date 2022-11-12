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

    [HideInInspector]
    public string currentText;

    private void Start()
    {
        RC = FindObjectOfType<RelationshipComparrison>();
    }

    public void SetActivePanel()
    {
        RC.relationshipOptionsPanel.SetActive(true);
        buttonObj = relationshipUI.transform.Find("RelationshipButton").GetComponent<Button>();
        currentText = buttonObj.transform.Find("RelationshipText").GetComponent<TextMeshProUGUI>().text;
        Debug.Log(currentText);
    }

}
