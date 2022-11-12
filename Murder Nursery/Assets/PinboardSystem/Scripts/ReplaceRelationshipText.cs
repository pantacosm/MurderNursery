using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

// attached to relationship options ui, allows player to click text to replace current relationship text
public class ReplaceRelationshipText : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    GameObject relationshipOptionsUI;

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
        if(RC.textToReplace == RC.goonJuiceContent1 && replacingText == RC.goonJuiceConclusion1)
        {
            RC.goonJuiceContent1 = RC.goonJuiceConclusion1;
            Destroy(relationshipOptionsUI);
            RC.UpdateRelationshipContents(new string[] {RC.goonJuiceContent1, RC.goonJuiceContent2 });
        }

        if(RC.textToReplace == RC.goonJuiceContent2 && replacingText == RC.goonJuiceConclusion2)
        {
            RC.goonJuiceContent2 = RC.goonJuiceConclusion2;
            Destroy(relationshipOptionsUI);
            RC.UpdateRelationshipContents(new string[] {RC.goonJuiceContent1, RC.goonJuiceContent2 });
        }

        if(RC.textToReplace == RC.goonCoolContent1 && replacingText == RC.goonCoolConclusion1)
        {
            RC.goonCoolContent1 = RC.goonCoolConclusion1;
            Destroy(relationshipOptionsUI);
            RC.UpdateRelationshipContents(new string[] {RC.goonCoolContent1});
        }





        
    }
}
