using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// allows player to click relationship text to open an options panel for replacing the text
// with the correct text (uncovers the information about the characters relationship)
public class OpenRelationshipOptionsPanel : MonoBehaviour, IPointerClickHandler
{
    //[SerializeField]
    //GameObject relationshipUI;

    //RelationshipDetails RD;

    PinboardManager PM;

    [SerializeField]
    Transform storyContent;

    [SerializeField]
    Transform storyEvidenceContent;

    Transform scarletStory;
    GameObject evidenceObject;

    [Header("Scarlet")]
    [SerializeField]
    GameObject scarletOne;
    [SerializeField]
    GameObject scarletTwo;
    [SerializeField]
    GameObject scarletThree;
    [SerializeField]
    GameObject scarletFour;
    [SerializeField]
    GameObject scarletFive;
    [SerializeField]
    GameObject scarletSix;
    [SerializeField]
    GameObject scarletSeven;
    [SerializeField]
    GameObject scarletEight;
    [SerializeField]
    GameObject scarletNine;
    [SerializeField]
    GameObject scarletTen;
    [SerializeField]
    GameObject scarletEleven;
    [SerializeField]
    GameObject scarletTwelve;
    [SerializeField]
    GameObject scarletThirteen;
    [SerializeField]
    GameObject scarletFourteen;
    [SerializeField]
    GameObject scarletFifteen;

    [Header("Juice Box")]
    [SerializeField]
    GameObject juiceBoxOne;
    [SerializeField]
    GameObject juiceBoxTwo;
    [SerializeField]
    GameObject juiceBoxThree;
    [SerializeField]
    GameObject juiceBoxFour;
    [SerializeField]
    GameObject juiceBoxFive;
    [SerializeField]
    GameObject juiceBoxSix;
    [SerializeField]
    GameObject juiceBoxSeven;
    [SerializeField]
    GameObject juiceBoxEight;
    [SerializeField]
    GameObject juiceBoxNine;
    [SerializeField]
    GameObject juiceBoxTen;
    [SerializeField]
    GameObject juiceBoxEleven;
    [SerializeField]
    GameObject juiceBoxTwelve;
    [SerializeField]
    GameObject juiceBoxThirteen;
    [SerializeField]
    GameObject juiceBoxFourteen;
    [SerializeField]
    GameObject juiceBoxFifteen;
    [SerializeField]
    GameObject juiceBoxSixteen;
    [SerializeField]
    GameObject juiceBoxSeventeen;
    [SerializeField]
    GameObject juiceBoxEighteen;
    [SerializeField]
    GameObject juiceBoxNineteen;

    [Header("Chase")]
    [SerializeField]
    GameObject chaseOne;
    [SerializeField]
    GameObject chaseTwo;
    [SerializeField]
    GameObject chaseThree;
    [SerializeField]
    GameObject chaseFour;
    [SerializeField]
    GameObject chaseFive;
    [SerializeField]
    GameObject chaseSix;
    [SerializeField]
    GameObject chaseSeven;
    [SerializeField]
    GameObject chaseEight;
    [SerializeField]
    GameObject chaseNine;
    [SerializeField]
    GameObject chaseTen;
    [SerializeField]
    GameObject chaseEleven;
    [SerializeField]
    GameObject chaseTwelve;
    [SerializeField]
    GameObject chaseThirteen;
    [SerializeField]
    GameObject chaseFourteen;

    [Header("Eddie")]
    [SerializeField]
    GameObject eddieOne;
    [SerializeField]
    GameObject eddieTwo;
    [SerializeField]
    GameObject eddieThree;
    [SerializeField]
    GameObject eddieFour;
    [SerializeField]
    GameObject eddieFive;
    [SerializeField]
    GameObject eddieSix;
    [SerializeField]
    GameObject eddieSeven;
    [SerializeField]
    GameObject eddieEight;
    [SerializeField]
    GameObject eddiexNine;
    [SerializeField]
    GameObject eddieTen;
    [SerializeField]
    GameObject eddieEleven;
    [SerializeField]
    GameObject eddieTwelve;
    [SerializeField]
    GameObject eddieThirteen;
    [SerializeField]
    GameObject eddieFourteen;
    [SerializeField]
    GameObject eddieFifteen;
    [SerializeField]
    GameObject eddieSixteen;

    [Header("Grace")]
    [SerializeField]
    GameObject graceOne;
    [SerializeField]
    GameObject graceTwo;
    [SerializeField]
    GameObject graceThree;
    [SerializeField]
    GameObject graceFour;
    [SerializeField]
    GameObject graceFive;
    [SerializeField]
    GameObject graceSix;
    [SerializeField]
    GameObject graceSeven;
    [SerializeField]
    GameObject graceEight;
    [SerializeField]
    GameObject graceNine;
    [SerializeField]
    GameObject graceTen;
    [SerializeField]
    GameObject graceEleven;
    [SerializeField]
    GameObject graceTwelve;
    [SerializeField]
    GameObject graceThirteen;
    [SerializeField]
    GameObject graceFourteen;
    [SerializeField]
    GameObject graceFifteen;
    [SerializeField]
    GameObject graceSixteen;
    [SerializeField]
    GameObject graceSeventeen;


    private void Start()
    {
        //RD = FindObjectOfType<RelationshipDetails>();
        PM = FindObjectOfType<PinboardManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //RD.relationshipOptionsPanel.SetActive(true);
        
        //string textToReplace = relationshipUI.transform.Find("RelationshipText").GetComponent<TextMeshProUGUI>().text;
        //RD.textToReplace = textToReplace;

        PM.objectNameBeingReplaced = gameObject.name;

        UpdateStory("One", scarletOne, "ScarletStory");
        //UpdateStory("Two", scarletTwo);
        //UpdateStory("Three", scarletThree);
        //UpdateStory("Four", scarletFour);
        //UpdateStory("Five", scarletFive);
        //UpdateStory("Six", scarletSix);
        //UpdateStory("Seven", scarletSeven);
        //UpdateStory("Eight", scarletEight);
        //UpdateStory("Nine", scarletNine);
        //UpdateStory("Ten", scarletTen);
        //UpdateStory("Eleven", scarletEleven);
        //UpdateStory("Twelve", scarletTwelve);
        //UpdateStory("Thirteen", scarletThirteen);
        //UpdateStory("Fourteen", scarletFourteen);
        //UpdateStory("Fifteen", scarletFifteen);

        UpdateStory("One", juiceBoxOne, "JuiceBoxStory");
        //UpdateStory("Two", juiceBoxTwo);
        //UpdateStory("Three", juiceBoxThree);
        //UpdateStory("Four", juiceBoxFour);
        //UpdateStory("Five", juiceBoxFive);
        //UpdateStory("Six", juiceBoxSix);
        //UpdateStory("Seven", juiceBoxSeven);
        //UpdateStory("Eight", juiceBoxEight);
        //UpdateStory("Nine", juiceBoxNine);
        //UpdateStory("Ten", juiceBoxTen);
        //UpdateStory("Eleven", juiceBoxEleven);
        //UpdateStory("Twelve", juiceBoxTwelve);
        //UpdateStory("Thirteen", juiceBoxThirteen);
        //UpdateStory("Fourteen", juiceBoxFourteen);
        //UpdateStory("Fifteen", juiceBoxFifteen);
        //UpdateStory("Sixteen", juiceBoxSixteen);
        //UpdateStory("Seventeen", juiceBoxSeventeen);
        //UpdateStory("Eighteen", juiceBoxEighteen);
        //UpdateStory("Nineteen", juiceBoxNineteen);

        UpdateStory("One", chaseOne, "ChaseStory");
        //UpdateStory("Two", chaseTwo);
        //UpdateStory("Three", chaseThree);
        //UpdateStory("Four", chaseFour);
        //UpdateStory("Five", chaseFive);
        //UpdateStory("Six", chaseSix);
        //UpdateStory("Seven", chaseSeven);
        //UpdateStory("Eight", chaseEight);
        //UpdateStory("Nine", chaseNine);
        //UpdateStory("Ten", chaseTen);
        //UpdateStory("Eleven", chaseEleven);
        //UpdateStory("Twelve", chaseTwelve);
        //UpdateStory("Thirteen", chaseThirteen);
        //UpdateStory("Fourteen", chaseFourteen);

        //UpdateStory("One", eddieOne);
        //UpdateStory("Two", eddieTwo);
        //UpdateStory("Three", eddieThree);
        //UpdateStory("Four", eddieFour);
        //UpdateStory("Five", eddieFive);
        //UpdateStory("Six", eddieSix);
        //UpdateStory("Seven", eddieSeven);
        //UpdateStory("Eight", eddieEight);
        //UpdateStory("Nine", eddiexNine);
        //UpdateStory("Ten", eddieTen);
        //UpdateStory("Eleven", eddieEleven);
        //UpdateStory("Twelve", eddieTwelve);
        //UpdateStory("Thirteen", eddieThirteen);
        //UpdateStory("Fourteen", eddieFourteen);
        //UpdateStory("Fifteen", eddieFifteen);
        //UpdateStory("Sixteen", eddieSixteen);

        //UpdateStory("One", graceOne);
        //UpdateStory("Two", graceTwo);
        //UpdateStory("Three", graceThree);
        //UpdateStory("Four", graceFour);
        //UpdateStory("Five", graceFive);
        //UpdateStory("Six", graceSix);
        //UpdateStory("Seven", graceSeven);
        //UpdateStory("Eight", graceEight);
        //UpdateStory("Nine", graceNine);
        //UpdateStory("Ten", graceTen);
        //UpdateStory("Eleven", graceEleven);
        //UpdateStory("Twelve", graceTwelve);
        //UpdateStory("Thirteen", graceThirteen);
        //UpdateStory("Fourteen", graceFourteen);
        //UpdateStory("Fifteen", graceFifteen);
        //UpdateStory("Sixteen", graceSixteen);
        //UpdateStory("Seventeen", graceSeventeen);
        
        

    }

    // Sets active object to view & select evidence to slot into the story
    void UpdateStory(string objectName, GameObject storyEvidence, string storyString)
    {
        if (gameObject.name == objectName && storyContent.Find(storyString))
        {
            storyEvidence.SetActive(true);
        }
        else
        {
            storyEvidence.SetActive(false);
        }
    }
    
}
