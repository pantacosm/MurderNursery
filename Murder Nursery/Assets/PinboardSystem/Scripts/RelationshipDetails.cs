using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RelationshipDetails : MonoBehaviour
{
    [SerializeField]
    GameObject relationshipUI;

    [SerializeField]
    Transform relationshipContent;

    [SerializeField]
    GameObject relationshipOptionsUI;

    [SerializeField]
    Transform optionsContent;

    public void ClearDetails()
    {
        // Clear content before updating the next relationship
        if (relationshipContent.childCount > 0)
        {
            foreach (Transform content in relationshipContent)
            {
                Destroy(content.gameObject);
            }
        }
    }

    // Called from RelationshipComparrison when we want to add new content to the relationship panel
    public void UpdateRelationship(string relationshipText)
    {
        GameObject relationshipObj = Instantiate(relationshipUI, relationshipContent);
        var contentButton = relationshipObj.transform.Find("RelationshipButton").GetComponent<Button>();
        var contentText = contentButton.transform.Find("RelationshipText").GetComponent<TextMeshProUGUI>();
        contentText.text = relationshipText;
    }

    // called when we want to update the relationship options panel with statements
    // for the player to choose to replace undiscovered (?????) or false statements
    public void AddToRelationshipOptionsUI(string textToAdd)
    {
        GameObject optionsObj = Instantiate(relationshipOptionsUI, optionsContent);
        var optionsText = optionsObj.transform.Find("RelationshipOptionsText").GetComponent<TextMeshProUGUI>();
        optionsText.text = textToAdd;
    }
}
