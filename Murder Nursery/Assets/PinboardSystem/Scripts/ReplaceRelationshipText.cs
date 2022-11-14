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
        if(RD.textToReplace == RD.goonJuiceContent1 && replacingText == RD.goonJuiceConclusion1)
        {
            RD.goonJuiceContent1 = RD.goonJuiceConclusion1;
            Destroy(relationshipOptionsUI);
            RD.UpdateRelationship(new string[] {RD.goonJuiceContent1, RD.goonJuiceContent2 });
        }

        if(RD.textToReplace == RD.goonJuiceContent2 && replacingText == RD.goonJuiceConclusion2)
        {
            RD.goonJuiceContent2 = RD.goonJuiceConclusion2;
            Destroy(relationshipOptionsUI);
            RD.UpdateRelationship(new string[] {RD.goonJuiceContent1, RD.goonJuiceContent2 });
        }

        if(RD.textToReplace == RD.goonCoolContent1 && replacingText == RD.goonCoolConclusion1)
        {
            RD.goonCoolContent1 = RD.goonCoolConclusion1;
            Destroy(relationshipOptionsUI);
            RD.UpdateRelationship(new string[] {RD.goonCoolContent1});
        }





        
    }
}
