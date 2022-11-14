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

    private void Start()
    {
        PM = FindObjectOfType<PinboardManager>();
        RD = PM.GetComponent<RelationshipDetails>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        string replacingText = relationshipOptionsUI.transform.Find("RelationshipOptionsText").GetComponent<TextMeshProUGUI>().text;
        
        // Goon : Juice Box Details
        foreach (var item in RD.goonJuiceDetails)
        {
            foreach (var conclusion in RD.conclusionsList)
            {
                int itemIndex = 0;
                int conclusionIndex = 1;
                if(RD.goonJuiceDetails.IndexOf(item) == itemIndex && RD.conclusionsList.IndexOf(conclusion) == conclusionIndex)
                {
                    Debug.Log(itemIndex);
                    RD.goonJuiceList[itemIndex] = RD.conclusionsList[conclusionIndex];
                    Destroy(relationshipOptionsUI);
                    RD.UpdateRelationship(RD.goonJuiceList);
                }
                break;
            }
            break;
        }


        //if (RD.textToReplace == RD.go && replacingText == RD.goonJuiceConclusion1)
        //{
        //    RD.goonJuiceContent1 = RD.goonJuiceConclusion1;
        //    Destroy(relationshipOptionsUI);
        //    RD.UpdateRelationship(new string[] { RD.goonJuiceContent1, RD.goonJuiceContent2 });
        //}

        //if (RD.textToReplace == RD.goonJuiceContent2 && replacingText == RD.goonJuiceConclusion2)
        //{
        //    RD.goonJuiceContent2 = RD.goonJuiceConclusion2;
        //    Destroy(relationshipOptionsUI);
        //    RD.UpdateRelationship(new string[] { RD.goonJuiceContent1, RD.goonJuiceContent2 });
        //}

        //if (RD.textToReplace == RD.goonCoolContent1 && replacingText == RD.goonCoolConclusion1)
        //{
        //    RD.goonCoolContent1 = RD.goonCoolConclusion1;
        //    Destroy(relationshipOptionsUI);
        //    RD.UpdateRelationship(new string[] { RD.goonCoolContent1 });
        //}






    }
}
