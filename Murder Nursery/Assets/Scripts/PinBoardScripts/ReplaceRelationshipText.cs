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

    [SerializeField]
    Transform content;

    Transform scarletStory;
    Transform juiceBoxStory;
    Transform eddieStory;
    Transform chaseStory;
    Transform graceStory;

    private PinboardManager PM;

    //private RelationshipDetails RD;

    string textToReplace;
    string replacingText;

    private void Start()
    {
        PM = FindObjectOfType<PinboardManager>();
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

    void UpdateStoryText(string storyString, Transform story, string objectName)
    {
        if(content.Find(storyString))
        {
            Debug.Log(storyString);
            story = content.Find(storyString);
            foreach (Transform item in story)
            {
                if(item.GetComponent<OpenRelationshipOptionsPanel>())
                {
                    string name = item.GetComponent<OpenRelationshipOptionsPanel>().name;
                    if(name == objectName && PM.objectNameBeingReplaced == objectName)
                    {
                        textToReplace = item.GetComponent<TextMeshProUGUI>().text;
                        item.GetComponent<TextMeshProUGUI>().text = item.GetComponent<TextMeshProUGUI>().text.Replace(textToReplace, replacingText);
                        break;
                    }
                }
            }

        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        replacingText = gameObject.GetComponent<TextMeshProUGUI>().text;

        UpdateStoryText("ScarletStory", scarletStory, "One");
        UpdateStoryText("ScarletStory", scarletStory, "Two");
        UpdateStoryText("ScarletStory", scarletStory, "Three");
        UpdateStoryText("ScarletStory", scarletStory, "Four");
        UpdateStoryText("ScarletStory", scarletStory, "Five");
        UpdateStoryText("ScarletStory", scarletStory, "Six");
        UpdateStoryText("ScarletStory", scarletStory, "Seven");
        UpdateStoryText("ScarletStory", scarletStory, "Eight");
        UpdateStoryText("ScarletStory", scarletStory, "Nine");
        UpdateStoryText("ScarletStory", scarletStory, "Ten");
        UpdateStoryText("ScarletStory", scarletStory, "Eleven");
        UpdateStoryText("ScarletStory", scarletStory, "Twelve");
        UpdateStoryText("ScarletStory", scarletStory, "Thirteen");
        UpdateStoryText("ScarletStory", scarletStory, "Fourteen");
        UpdateStoryText("ScarletStory", scarletStory, "Fifteen");

        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "One");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "Two");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "Three");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "Four");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "Five");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "Six");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "Seven");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "Eight");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "Nine");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "Ten");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "Eleven");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "Twelve");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "Thirteen");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "Fourteen");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "Fifteen");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "Sixteen");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "Seventeen");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "Eighteen");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "Nineteen");

        UpdateStoryText("ChaseStory", chaseStory, "One");
        UpdateStoryText("ChaseStory", chaseStory, "Two");
        UpdateStoryText("ChaseStory", chaseStory, "Three");
        UpdateStoryText("ChaseStory", chaseStory, "Four");
        UpdateStoryText("ChaseStory", chaseStory, "Five");
        UpdateStoryText("ChaseStory", chaseStory, "Six");
        UpdateStoryText("ChaseStory", chaseStory, "Seven");
        UpdateStoryText("ChaseStory", chaseStory, "Eight");
        UpdateStoryText("ChaseStory", chaseStory, "Nine");
        UpdateStoryText("ChaseStory", chaseStory, "Ten");
        UpdateStoryText("ChaseStory", chaseStory, "Eleven");
        UpdateStoryText("ChaseStory", chaseStory, "Twelve");
        UpdateStoryText("ChaseStory", chaseStory, "Thirteen");
        UpdateStoryText("ChaseStory", chaseStory, "Fourteen");

        UpdateStoryText("EddieStory", eddieStory, "One");
        UpdateStoryText("EddieStory", eddieStory, "Two");
        UpdateStoryText("EddieStory", eddieStory, "Three");
        UpdateStoryText("EddieStory", eddieStory, "Four");
        UpdateStoryText("EddieStory", eddieStory, "Five");
        UpdateStoryText("EddieStory", eddieStory, "Six");
        UpdateStoryText("EddieStory", eddieStory, "Seven");
        UpdateStoryText("EddieStory", eddieStory, "Eight");
        UpdateStoryText("EddieStory", eddieStory, "Nine");
        UpdateStoryText("EddieStory", eddieStory, "Ten");
        UpdateStoryText("EddieStory", eddieStory, "Eleven");
        UpdateStoryText("EddieStory", eddieStory, "Twelve");
        UpdateStoryText("EddieStory", eddieStory, "Thirteen");
        UpdateStoryText("EddieStory", eddieStory, "Fourteen");
        UpdateStoryText("EddieStory", eddieStory, "Fifteen");
        UpdateStoryText("EddieStory", eddieStory, "Sixteen");

        UpdateStoryText("GraceStory", graceStory, "One");
        UpdateStoryText("GraceStory", graceStory, "Two");
        UpdateStoryText("GraceStory", graceStory, "Three");
        UpdateStoryText("GraceStory", graceStory, "Four");
        UpdateStoryText("GraceStory", graceStory, "Five");
        UpdateStoryText("GraceStory", graceStory, "Six");
        UpdateStoryText("GraceStory", graceStory, "Seven");
        UpdateStoryText("GraceStory", graceStory, "Eight");
        UpdateStoryText("GraceStory", graceStory, "Nine");
        UpdateStoryText("GraceStory", graceStory, "Ten");
        UpdateStoryText("GraceStory", graceStory, "Eleven");
        UpdateStoryText("GraceStory", graceStory, "Twelve");
        UpdateStoryText("GraceStory", graceStory, "Thirteen");
        UpdateStoryText("GraceStory", graceStory, "Fourteen");
        UpdateStoryText("GraceStory", graceStory, "Fifteen");
        UpdateStoryText("GraceStory", graceStory, "Sixteen");
        UpdateStoryText("GraceStory", graceStory, "Seventeen");




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
