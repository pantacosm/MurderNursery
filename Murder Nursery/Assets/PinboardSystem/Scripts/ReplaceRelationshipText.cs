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

        //// Goon : Juice Box Details
        if (RD.textToReplace == RD.goonJuiceDetails[0] && replacingText == RD.conclusionsList[0])
        {
            foreach (var item in RD.goonJuiceList)
            {
                if(item == RD.goonJuiceDetails[0])
                {
                    RD.goonJuiceList[RD.goonJuiceList.IndexOf(item)] = RD.conclusionsList[0];
                    RD.UpdateRelationship(RD.goonJuiceList);
                    Destroy(relationshipOptionsUI);
                    break;
                }
            }
        }

        if (RD.textToReplace == RD.goonJuiceDetails[1] && replacingText == RD.conclusionsList[1])
        {
            foreach (var item in RD.goonJuiceList)
            {
                if(item == RD.goonJuiceDetails[1])
                {
                    RD.goonJuiceList[RD.goonJuiceList.IndexOf(item)] = RD.conclusionsList[1];
                    RD.UpdateRelationship(RD.goonJuiceList);
                    Destroy(relationshipOptionsUI);
                    break;
                }
            }
        }

        //// Goon : Cool Guy Details
        if (RD.textToReplace == RD.goonCoolguyDetails[0] && replacingText == RD.conclusionsList[2])
        {
            foreach (var item in RD.goonCoolguyList)
            {
                if(item == RD.goonCoolguyDetails[0])
                {
                    RD.goonCoolguyList[RD.goonCoolguyList.IndexOf(item)] = RD.conclusionsList[2];
                    RD.UpdateRelationship(RD.goonCoolguyList);
                    Destroy(relationshipOptionsUI);
                    break;
                }
            }
        }


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
