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

    // used for opening relationship options panel
    public GameObject relationshipOptionsPanel;

    [SerializeField]
    GameObject relationshipOptionsUI;

    [SerializeField]
    Transform optionsContent;

    // set based on which relationship content we currently want to replace
    [HideInInspector]
    public string textToReplace;

    [Header ("False/Undiscovered Relationship Contents")]
    public string goonJuiceContent1;
    public string goonJuiceContent2;
    public string goonCoolContent1;

    // included as a parameter when calling AddToRelationshipOptionsUI(string textToAdd)
    // (used for replacing relationship content)
    [Header("Relationship Conclusions")]
    public string goonJuiceConclusion1;
    public string goonJuiceConclusion2;
    public string goonCoolConclusion1;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.O))
        {
            AddToRelationshipOptionsUI(goonJuiceConclusion1);
            AddToRelationshipOptionsUI(goonJuiceConclusion2);
            AddToRelationshipOptionsUI(goonCoolConclusion1);
        }
    }

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

    // Called from RelationshipComparrison or when replacing text when we want to add/update content in the relationship panel
    public void UpdateRelationship(string[] relationshipText)
    {
        ClearDetails();

        foreach (var item in relationshipText)
        {
            GameObject relationshipObj = Instantiate(relationshipUI, relationshipContent);
            var contentText = relationshipObj.transform.Find("RelationshipText").GetComponent<TextMeshProUGUI>();
            contentText.text = item;
        }
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
