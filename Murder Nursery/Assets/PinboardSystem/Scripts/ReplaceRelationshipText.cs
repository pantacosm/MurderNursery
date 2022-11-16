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

    private RelationshipDetails RD;

    string replacingText;

    private void Start()
    {
        PM = FindObjectOfType<PinboardManager>();
        RD = PM.GetComponent<RelationshipDetails>();
    }

    //// Updates undiscovered "?????" text with full conclusion 
    void ReplaceRelationshipDetails(List<string> detailsList, List<string> relationshipList, int detailsIndex, int conclusionIndex)
    {
        replacingText = relationshipOptionsUI.transform.Find("RelationshipOptionsText").GetComponent<TextMeshProUGUI>().text;

        
        if (RD.textToReplace == detailsList[detailsIndex] && replacingText == RD.conclusionsList[conclusionIndex])
        {
            foreach (var item in relationshipList)
            {
                if(item == detailsList[detailsIndex])
                {
                    relationshipList[relationshipList.IndexOf(item)] = RD.conclusionsList[conclusionIndex];
                    RD.UpdateRelationship(relationshipList);
                    Destroy(relationshipOptionsUI);
                    break;
                }
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Goon : Juice Box
        ReplaceRelationshipDetails(RD.goonJuiceDetails, RD.goonJuiceList, 0, 0);
        ReplaceRelationshipDetails(RD.goonJuiceDetails, RD.goonJuiceList, 1, 1);

        // Goon : Cool Guy
        ReplaceRelationshipDetails(RD.goonCoolguyDetails, RD.goonCoolguyList, 0, 2);


   
    }
}
