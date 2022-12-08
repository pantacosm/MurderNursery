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
        if(content.Find(storyString) && PM.objectNameBeingReplaced == objectName)
        {
            Debug.Log(storyString);
            story = content.Find(storyString);
            foreach (Transform item in story)
            {
                if(item.GetComponent<OpenRelationshipOptionsPanel>())
                {
                    string name = item.GetComponent<OpenRelationshipOptionsPanel>().name;
                    if(name == objectName)
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

        UpdateStoryText("ScarletStory", scarletStory, "ScarletOne");
        UpdateStoryText("ScarletStory", scarletStory, "ScarletTwo");
        UpdateStoryText("ScarletStory", scarletStory, "ScarletThree");
        UpdateStoryText("ScarletStory", scarletStory, "ScarletFour");
        UpdateStoryText("ScarletStory", scarletStory, "ScarletFive");
        UpdateStoryText("ScarletStory", scarletStory, "ScarletSix");
        UpdateStoryText("ScarletStory", scarletStory, "ScarletSeven");
        UpdateStoryText("ScarletStory", scarletStory, "ScarletEight");
        UpdateStoryText("ScarletStory", scarletStory, "ScarletNine");
        UpdateStoryText("ScarletStory", scarletStory, "ScarletTen");
        UpdateStoryText("ScarletStory", scarletStory, "ScarletEleven");
        UpdateStoryText("ScarletStory", scarletStory, "ScarletTwelve");
        UpdateStoryText("ScarletStory", scarletStory, "ScarletThirteen");
        UpdateStoryText("ScarletStory", scarletStory, "ScarletFourteen");
        UpdateStoryText("ScarletStory", scarletStory, "ScarletFifteen");

        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxOne");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxTwo");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxThree");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxFour");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxFive");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxSix");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxSeven");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxEight");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxNine");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxTen");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxEleven");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxTwelve");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxThirteen");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxFourteen");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxFifteen");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxSixteen");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxSeventeen");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxEighteen");
        UpdateStoryText("JuiceBoxStory", juiceBoxStory, "JuiceBoxNineteen");

        UpdateStoryText("ChaseStory", chaseStory, "ChaseOne");
        UpdateStoryText("ChaseStory", chaseStory, "ChaseTwo");
        UpdateStoryText("ChaseStory", chaseStory, "ChaseThree");
        UpdateStoryText("ChaseStory", chaseStory, "ChaseFour");
        UpdateStoryText("ChaseStory", chaseStory, "ChaseFive");
        UpdateStoryText("ChaseStory", chaseStory, "ChaseSix");
        UpdateStoryText("ChaseStory", chaseStory, "ChaseSeven");
        UpdateStoryText("ChaseStory", chaseStory, "ChaseEight");
        UpdateStoryText("ChaseStory", chaseStory, "ChaseNine");
        UpdateStoryText("ChaseStory", chaseStory, "ChaseTen");
        UpdateStoryText("ChaseStory", chaseStory, "ChaseEleven");
        UpdateStoryText("ChaseStory", chaseStory, "ChaseTwelve");
        UpdateStoryText("ChaseStory", chaseStory, "ChaseThirteen");
        UpdateStoryText("ChaseStory", chaseStory, "ChaseFourteen");

        UpdateStoryText("EddieStory", eddieStory, "EddieOne");
        UpdateStoryText("EddieStory", eddieStory, "EddieTwo");
        UpdateStoryText("EddieStory", eddieStory, "EddieThree");
        UpdateStoryText("EddieStory", eddieStory, "EddieFour");
        UpdateStoryText("EddieStory", eddieStory, "EddieFive");
        UpdateStoryText("EddieStory", eddieStory, "EddieSix");
        UpdateStoryText("EddieStory", eddieStory, "EddieSeven");
        UpdateStoryText("EddieStory", eddieStory, "EddieEight");
        UpdateStoryText("EddieStory", eddieStory, "EddieNine");
        UpdateStoryText("EddieStory", eddieStory, "EddieTen");
        UpdateStoryText("EddieStory", eddieStory, "EddieEleven");
        UpdateStoryText("EddieStory", eddieStory, "EddieTwelve");
        UpdateStoryText("EddieStory", eddieStory, "EddieThirteen");
        UpdateStoryText("EddieStory", eddieStory, "EddieFourteen");
        UpdateStoryText("EddieStory", eddieStory, "EddieFifteen");
        UpdateStoryText("EddieStory", eddieStory, "EddieSixteen");

        UpdateStoryText("GraceStory", graceStory, "GraceOne");
        UpdateStoryText("GraceStory", graceStory, "GraceTwo");
        UpdateStoryText("GraceStory", graceStory, "GraceThree");
        UpdateStoryText("GraceStory", graceStory, "GraceFour");
        UpdateStoryText("GraceStory", graceStory, "GraceFive");
        UpdateStoryText("GraceStory", graceStory, "GraceSix");
        UpdateStoryText("GraceStory", graceStory, "GraceSeven");
        UpdateStoryText("GraceStory", graceStory, "GraceEight");
        UpdateStoryText("GraceStory", graceStory, "GraceNine");
        UpdateStoryText("GraceStory", graceStory, "GraceTen");
        UpdateStoryText("GraceStory", graceStory, "GraceEleven");
        UpdateStoryText("GraceStory", graceStory, "GraceTwelve");
        UpdateStoryText("GraceStory", graceStory, "GraceThirteen");
        UpdateStoryText("GraceStory", graceStory, "GraceFourteen");
        UpdateStoryText("GraceStory", graceStory, "GraceFifteen");
        UpdateStoryText("GraceStory", graceStory, "GraceSixteen");
        UpdateStoryText("GraceStory", graceStory, "GraceSeventeen");




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
