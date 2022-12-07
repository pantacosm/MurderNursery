using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

// attached to relationship options ui, allows player to click text to replace current relationship text
public class ReplaceRelationshipText : MonoBehaviour, IPointerClickHandler
{
    //[SerializeField]
    //GameObject relationshipOptionsUI;

    //private PinboardManager PM;

    //private RelationshipDetails RD;

    string replacingText;

    private void Start()
    {
        //PM = FindObjectOfType<PinboardManager>();
        //RD = PM.GetComponent<RelationshipDetails>();
    }

    //// Updates undiscovered "?????" text with full conclusion 
    //void ReplaceRelationshipDetails(List<string> detailsList, List<string> relationshipList, int detailsIndex, int conclusionIndex)
    //{
    //    replacingText = relationshipOptionsUI.transform.Find("RelationshipOptionsText").GetComponent<TextMeshProUGUI>().text;

        
    //    if (RD.textToReplace == detailsList[detailsIndex] && replacingText == RD.conclusionsList[conclusionIndex])
    //    {
    //        foreach (var item in relationshipList)
    //        {
    //            if (item == detailsList[detailsIndex])
    //            {
    //                string oldText = "?????";
    //                if (detailsList[detailsIndex].Contains(oldText))
    //                {
    //                    detailsList[detailsIndex] = detailsList[detailsIndex].Replace(oldText, RD.conclusionsList[conclusionIndex]);
    //                    relationshipList[relationshipList.IndexOf(item)] = detailsList[detailsIndex];  //RD.conclusionsList[conclusionIndex];
    //                }

    //                RD.UpdateRelationship(relationshipList);
    //                //Destroy(relationshipOptionsUI);
    //                break;
    //            }
    //        }
    //    }
    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        //// Goon : Juice Box
        //ReplaceRelationshipDetails(RD.goonJuiceDetails, RD.goonJuiceList, 0, 0);
        //ReplaceRelationshipDetails(RD.goonJuiceDetails, RD.goonJuiceList, 1, 1);
        //ReplaceRelationshipDetails(RD.goonJuiceDetails, RD.goonJuiceList, 2, 2);

        //// Goon : Cool Guy
        //ReplaceRelationshipDetails(RD.goonCoolguyDetails, RD.goonCoolguyList, 0, 1);
        //ReplaceRelationshipDetails(RD.goonCoolguyDetails, RD.goonCoolguyList, 1, 6);
        //ReplaceRelationshipDetails(RD.goonCoolguyDetails, RD.goonCoolguyList, 2, 7);

        //// Goon : Dead Girl
        //ReplaceRelationshipDetails(RD.goonDeadgirlDetails, RD.goonDeadGirlList, 0, 10);
        //ReplaceRelationshipDetails(RD.goonDeadgirlDetails, RD.goonDeadGirlList, 1, 11);
        //ReplaceRelationshipDetails(RD.goonDeadgirlDetails, RD.goonDeadGirlList, 2, 12);

        //// Goon : Femme
        //ReplaceRelationshipDetails(RD.goonFemmeDetails, RD.goonFemmeList, 0, 11);
        //ReplaceRelationshipDetails(RD.goonFemmeDetails, RD.goonFemmeList, 1, 1);
        //ReplaceRelationshipDetails(RD.goonFemmeDetails, RD.goonFemmeList, 2, 8);

        //// Juice : Cool Guy
        //ReplaceRelationshipDetails(RD.juiceCoolguyDetails, RD.juiceCoolguyList, 0, 3);
        //ReplaceRelationshipDetails(RD.juiceCoolguyDetails, RD.juiceCoolguyList, 1, 4);
        //ReplaceRelationshipDetails(RD.juiceCoolguyDetails, RD.juiceCoolguyList, 2, 5);

        //// Juice : Femme
        //ReplaceRelationshipDetails(RD.juiceFemmeDetails, RD.juiceFemmeList, 0, 10);
        //ReplaceRelationshipDetails(RD.juiceFemmeDetails, RD.juiceFemmeList, 1, 11);
        //ReplaceRelationshipDetails(RD.juiceFemmeDetails, RD.juiceFemmeList, 2, 8);

        //// Juice : Dead Girl
        //ReplaceRelationshipDetails(RD.juiceDeadgirlDetails, RD.juiceDeadGirlList, 0, 10);
        //ReplaceRelationshipDetails(RD.juiceDeadgirlDetails, RD.juiceDeadGirlList, 1, 10);
        //ReplaceRelationshipDetails(RD.juiceDeadgirlDetails, RD.juiceDeadGirlList, 2, 7);

        //// Cool Guy : Femme
        //ReplaceRelationshipDetails(RD.coolguyFemmeDetails, RD.coolGuyFemmeList, 0, 10);
        //ReplaceRelationshipDetails(RD.coolguyFemmeDetails, RD.coolGuyFemmeList, 1, 11);
        //ReplaceRelationshipDetails(RD.coolguyFemmeDetails, RD.coolGuyFemmeList, 2, 8);

        //// Cool Guy : Dead Girl
        //ReplaceRelationshipDetails(RD.coolguyDeadgirlDetails, RD.coolGuyDeadGirlList, 0, 1);
        //ReplaceRelationshipDetails(RD.coolguyDeadgirlDetails, RD.coolGuyDeadGirlList, 1, 1);
        //ReplaceRelationshipDetails(RD.coolguyDeadgirlDetails, RD.coolGuyDeadGirlList, 2, 9);

        //// Femme : Dead Girl
        //ReplaceRelationshipDetails(RD.femmeDeadgirlDetails, RD.femmeDeadGirlList, 0, 13);
        //ReplaceRelationshipDetails(RD.femmeDeadgirlDetails, RD.femmeDeadGirlList, 1, 11);
        //ReplaceRelationshipDetails(RD.femmeDeadgirlDetails, RD.femmeDeadGirlList, 2, 14);

   
    }
}
