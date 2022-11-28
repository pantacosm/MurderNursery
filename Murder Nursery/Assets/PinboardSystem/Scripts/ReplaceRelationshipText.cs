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
        ReplaceRelationshipDetails(RD.goonJuiceDetails, RD.goonJuiceList, 2, 3);

        // Goon : Cool Guy
        ReplaceRelationshipDetails(RD.goonCoolguyDetails, RD.goonCoolguyList, 0, 2);
        ReplaceRelationshipDetails(RD.goonCoolguyDetails, RD.goonCoolguyList, 1, 13);
        ReplaceRelationshipDetails(RD.goonCoolguyDetails, RD.goonCoolguyList, 2, 15);

        // Goon : Dead Girl
        ReplaceRelationshipDetails(RD.goonDeadgirlDetails, RD.goonDeadGirlList, 0, 25);
        ReplaceRelationshipDetails(RD.goonDeadgirlDetails, RD.goonDeadGirlList, 1, 26);
        ReplaceRelationshipDetails(RD.goonDeadgirlDetails, RD.goonDeadGirlList, 2, 27);

        // Goon : Femme
        ReplaceRelationshipDetails(RD.goonFemmeDetails, RD.goonFemmeList, 0, 19);
        ReplaceRelationshipDetails(RD.goonFemmeDetails, RD.goonFemmeList, 1, 20);
        ReplaceRelationshipDetails(RD.goonFemmeDetails, RD.goonFemmeList, 2, 21);

        // Juice : Cool Guy
        ReplaceRelationshipDetails(RD.juiceCoolguyDetails, RD.juiceCoolguyList, 0, 4);
        ReplaceRelationshipDetails(RD.juiceCoolguyDetails, RD.juiceCoolguyList, 1, 5);
        ReplaceRelationshipDetails(RD.juiceCoolguyDetails, RD.juiceCoolguyList, 2, 6);

        // Juice : Femme
        ReplaceRelationshipDetails(RD.juiceFemmeDetails, RD.juiceFemmeList, 0, 7);
        ReplaceRelationshipDetails(RD.juiceFemmeDetails, RD.juiceFemmeList, 1, 8);
        ReplaceRelationshipDetails(RD.juiceFemmeDetails, RD.juiceFemmeList, 2, 9);

        // Juice : Dead Girl
        ReplaceRelationshipDetails(RD.juiceDeadgirlDetails, RD.juiceDeadGirlList, 0, 10);
        ReplaceRelationshipDetails(RD.juiceDeadgirlDetails, RD.juiceDeadGirlList, 1, 11);
        ReplaceRelationshipDetails(RD.juiceDeadgirlDetails, RD.juiceDeadGirlList, 2, 12);

        // Cool Guy : Femme
        ReplaceRelationshipDetails(RD.coolguyFemmeDetails, RD.coolGuyFemmeList, 0, 16);
        ReplaceRelationshipDetails(RD.coolguyFemmeDetails, RD.coolGuyFemmeList, 1, 17);
        ReplaceRelationshipDetails(RD.coolguyFemmeDetails, RD.coolGuyFemmeList, 2, 18);

        // Cool Guy : Dead Girl
        ReplaceRelationshipDetails(RD.coolguyDeadgirlDetails, RD.coolGuyDeadGirlList, 0, 22);
        ReplaceRelationshipDetails(RD.coolguyDeadgirlDetails, RD.coolGuyDeadGirlList, 1, 23);
        ReplaceRelationshipDetails(RD.coolguyDeadgirlDetails, RD.coolGuyDeadGirlList, 2, 24);

        // Femme : Dead Girl
        ReplaceRelationshipDetails(RD.femmeDeadgirlDetails, RD.femmeDeadGirlList, 0, 28);
        ReplaceRelationshipDetails(RD.femmeDeadgirlDetails, RD.femmeDeadGirlList, 1, 29);
        ReplaceRelationshipDetails(RD.femmeDeadgirlDetails, RD.femmeDeadGirlList, 2, 30);

   
    }
}
