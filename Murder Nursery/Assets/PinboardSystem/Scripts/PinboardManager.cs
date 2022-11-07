using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// displays characters traits likes/dislikes/events on a pin-board style ui
public class PinboardManager : MonoBehaviour
{
    public static PinboardManager pinboard;

    public Transform GoonLikes;
    public Transform GoonDislikes;
    public Transform GoonEvents;

    public Transform CoolGuyLikes;
    public Transform CoolGuyDislikes;
    public Transform CoolGuyEvents;

    public Transform JuiceboxLikes;
    public Transform JuiceboxDislikes;
    public Transform JuiceboxEvents;

    public Transform FemmeLikes;
    public Transform FemmeDislikes;
    public Transform FemmeEvents;

    public Transform DeadGirlLikes;
    public Transform DeadGirlDislikes;
    public Transform DeadGirlEvents;

    [SerializeField]
    GameObject CharacterTraitsUI;

    [SerializeField]
    GameObject RelationshipOptionsUI;

    [SerializeField]
    Transform RelationshipOptionsContent;


    // Start is called before the first frame update
    void Awake()
    {
        pinboard = this;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.KeypadPlus))
        {
            UpdatePinboard(GoonLikes, "COOL GUY");
            UpdatePinboard(GoonEvents, "Has a thing for femme.");
            UpdatePinboard(GoonEvents, "Did odd jobs for Cool Guy.");

            UpdatePinboard(CoolGuyLikes, "RUNNING");
            UpdatePinboard(CoolGuyLikes, "CANDY BARS");

            UpdatePinboard(JuiceboxLikes, "GOON");
            UpdatePinboard(JuiceboxLikes, "JUICE BOXES");
            UpdatePinboard(JuiceboxLikes, "ART");
            UpdatePinboard(JuiceboxEvents, "Fell out of a tree cos of Goon.");
            UpdatePinboard(JuiceboxEvents, "Juice box addiction.");
            UpdatePinboard(JuiceboxEvents, "Close to dead girl.");

            UpdatePinboard(FemmeLikes, "DRESS-UP");

            UpdateRelationshipOptions("Goon does not like Juice Box");
        }

        if(Input.GetKeyUp(KeyCode.KeypadMinus))
        {
            UpdatePinboard(GoonDislikes, "JUICE BOX");
            UpdatePinboard(GoonDislikes, "COPS");

            UpdatePinboard(FemmeDislikes, "DEAD GIRL");
            UpdatePinboard(FemmeDislikes, "UGGOS");
            UpdatePinboard(FemmeDislikes, "BOYS");
        }        
    }

    // Called when we want to update the pin board after discovering a characters likes/dislikes/events
    // content determines whos likes/dislikes/events we are updating / string is what we want the content to say
    public void UpdatePinboard(Transform content, string pinboardText)
    {
        GameObject pinboardObj = Instantiate(CharacterTraitsUI, content);
        var contentText = pinboardObj.transform.Find("TraitsText").GetComponent<TextMeshProUGUI>();
        contentText.text = pinboardText;
    }

    public void UpdateRelationshipOptions(string optionsText)
    {
        GameObject optionsObj = Instantiate(RelationshipOptionsUI, RelationshipOptionsContent);
        var relationshipText = optionsObj.transform.Find("RelationshipOptionsText").GetComponent<TextMeshProUGUI>();
        relationshipText.text = optionsText;
    }

}
