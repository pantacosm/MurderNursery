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

    [SerializeField]
    GameObject scarletContentOne;

    [SerializeField]
    GameObject scarletContentTwo;

    [SerializeField]
    GameObject scarletContentThree;

    [SerializeField]
    GameObject scarletContentFour;

    [SerializeField]
    GameObject scarletContentFive;

    [SerializeField]
    GameObject scarletContentSix;

    [SerializeField]
    GameObject scarletContentSeven;

    [SerializeField]
    GameObject scarletContentEight;

    [SerializeField]
    GameObject scarletContentNine;

    [SerializeField]
    GameObject scarletContentTen;

    [SerializeField]
    GameObject scarletContentEleven;

    [SerializeField]
    GameObject scarletContentTwelve;

    [SerializeField]
    GameObject scarletContentThirteen;

    [SerializeField]
    GameObject scarletContentFourteen;

    [SerializeField]
    GameObject scarletContentFifteen;


    [HideInInspector]
    public GameObject objToReplace;


    //string textToReplace;

    private void Start()
    {
        //RD = FindObjectOfType<RelationshipDetails>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //RD.relationshipOptionsPanel.SetActive(true);

        //string textToReplace = relationshipUI.transform.Find("RelationshipText").GetComponent<TextMeshProUGUI>().text;
        objToReplace = gameObject;
        
        UpdateScarlet();
        
    }

    void UpdateScarlet()
    {
        if(gameObject.name == "One")
        {
            scarletContentOne.SetActive(true);
        }
        else
        {
            scarletContentOne.SetActive(false);
        }

        if(gameObject.name == "Two")
        {
            scarletContentTwo.SetActive(true);
        }
        else
        {
            scarletContentTwo.SetActive(false);
        }

        if(gameObject.name == "Three")
        {
            scarletContentThree.SetActive(true);
        }
        else
        {
            scarletContentThree.SetActive(false);
        }

        if(gameObject.name == "Four")
        {
            scarletContentFour.SetActive(true);
        }
        else
        {
            scarletContentFour.SetActive(false);
        }

        if(gameObject.name == "Five")
        {
            scarletContentFive.SetActive(true);
        }
        else
        {
            scarletContentFive.SetActive(false);
        }

        if(gameObject.name == "Six")
        {
            scarletContentSix.SetActive(true);
        }
        else
        {
            scarletContentSix.SetActive(false);
        }

        if(gameObject.name == "Seven")
        {
            scarletContentSeven.SetActive(true);
        }
        else
        {
            scarletContentSeven.SetActive(false);
        }

        if(gameObject.name == "Eight")
        {
            scarletContentEight.SetActive(true);
        }
        else
        {
            scarletContentEight.SetActive(false);
        }

        if(gameObject.name == "Nine")
        {
            scarletContentNine.SetActive(true);
        }
        else
        {
            scarletContentNine.SetActive(false);
        }

        if(gameObject.name == "Ten")
        {
            scarletContentTen.SetActive(true);
        }
        else
        {
            scarletContentTen.SetActive(false);
        }

        if(gameObject.name == "Eleven")
        {
            scarletContentEleven.SetActive(true);
        }
        else
        {
            scarletContentEleven.SetActive(false);
        }

        if(gameObject.name == "Twelve")
        {
            scarletContentTwelve.SetActive(true);
        }
        else
        {
            scarletContentTwelve.SetActive(false);
        }

        if(gameObject.name == "Thirteen")
        {
            scarletContentThirteen.SetActive(true);
        }
        else
        {
            scarletContentThirteen.SetActive(false);
        }

        if(gameObject.name == "Fourteen")
        {
            scarletContentFourteen.SetActive(true);
        }
        else
        {
            scarletContentFourteen.SetActive(false);
        }

        if(gameObject.name == "Fifteen")
        {
            scarletContentFifteen.SetActive(true);
        }
        else
        {
            scarletContentFifteen.SetActive(false);
        }
    }

}
