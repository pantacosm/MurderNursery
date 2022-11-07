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

    public List<string> relationshipList;

    // shows a tick if player has correct relationship details
    [HideInInspector]
    public Toggle detailsCorrect;

    public void UpdateRelationship(string[] relationshipText)
    {
        if(relationshipContent.childCount > 0)
        {
            foreach (Transform content in relationshipContent)
            {
                Destroy(content.gameObject);
                relationshipList.Clear();
            }
        }

        foreach (var item in relationshipText)
        {
            relationshipList.Add(item);
        }

        foreach (string item in relationshipList)
        {
            GameObject relationshipObj = Instantiate(relationshipUI, relationshipContent);
            var contentText = relationshipObj.transform.Find("RelationshipText").GetComponent<TextMeshProUGUI>();
            detailsCorrect = relationshipObj.transform.Find("Toggle").GetComponent<Toggle>();
            contentText.text = item;
        }

    }

    public string ReplaceRelationshipDetails(string currentText, string textToReplace)
    {
        string replace = currentText.Replace(textToReplace, "Juice Boxes");
        return replace;
    }
}
