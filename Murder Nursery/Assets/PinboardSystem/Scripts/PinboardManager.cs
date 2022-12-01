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

    [Header( "Pin-board Content")]
    [Header( "Goon")]
    public string[] goonLikes;
    public string[] goonDislikes;
    public string[] goonEvents;

    [Header( "Cool Guy")]
    public string[] coolguyLikes;
    public string[] coolguyDislikes;
    public string[] coolguyEvents;

    [Header( "Juice Box")]
    public string[] juiceboxLikes;
    public string[] juiceboxDislikes;
    public string[] juiceboxEvents;

    [Header( "Femme")]
    public string[] femmeLikes;
    public string[] femmeDislikes;
    public string[] femmeEvents;

    [Header( "Dead Girl")]
    public string[] deadgirlLikes;
    public string[] deadgirlDislikes;
    public string[] deadgirlEvents;


    // Start is called before the first frame update
    void Awake()
    {
        pinboard = this;
    }

    private void Start()
    {
        //UpdatePinboard(GoonLikes, goonLikes[0]);
        //UpdatePinboard(GoonLikes, goonLikes[1]);
        //UpdatePinboard(GoonDislikes, goonDislikes[0]);
        //UpdatePinboard(GoonEvents, goonEvents[0]);
        //UpdatePinboard(GoonEvents, goonEvents[1]);

        //UpdatePinboard(JuiceboxLikes, juiceboxLikes[0]);
        //UpdatePinboard(JuiceboxLikes, juiceboxLikes[1]);
        //UpdatePinboard(JuiceboxLikes, juiceboxLikes[2]);
        //UpdatePinboard(JuiceboxDislikes, juiceboxDislikes[0]);
        //UpdatePinboard(JuiceboxEvents, juiceboxEvents[0]);
        //UpdatePinboard(JuiceboxEvents, juiceboxEvents[1]);

        //UpdatePinboard(FemmeLikes, femmeLikes[0]);
        //UpdatePinboard(FemmeDislikes, femmeDislikes[0]);
        //UpdatePinboard(FemmeDislikes, femmeDislikes[1]);

        //UpdatePinboard(CoolGuyLikes, coolguyLikes[0]);
        //UpdatePinboard(CoolGuyLikes, coolguyLikes[1]);
    }

    // Called when we want to update the pin board after discovering a characters likes/dislikes/events
    // content determines whos likes/dislikes/events we are updating / string is what we want the content to say
    public void UpdatePinboard(Transform content, string pinboardText)
    {
        GameObject pinboardObj = Instantiate(CharacterTraitsUI, content);
        var contentText = pinboardObj.transform.Find("TraitsText").GetComponent<TextMeshProUGUI>();
        contentText.text = pinboardText;
    }

}
