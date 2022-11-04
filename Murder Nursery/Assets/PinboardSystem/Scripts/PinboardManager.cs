using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PinboardManager : MonoBehaviour
{
    public static PinboardManager pinboard;

    [SerializeField]
    public Transform GoonLikes;

    [SerializeField]
    public Transform GoonDislikes;

    public Transform GoonEvents;

    [SerializeField]
    GameObject CharacterTraitsUI;


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
        }

        if(Input.GetKeyUp(KeyCode.KeypadMinus))
        {
            UpdatePinboard(GoonDislikes, "JUICE BOX");
        }
    }

    // Called when we want to update the pin board after discovering a characters likes/dislikes
    // content determines whos likes/dislikes we are updating / string is what we want the content to say
    public void UpdatePinboard(Transform content, string pinboardText)
    {
        GameObject likesObj = Instantiate(CharacterTraitsUI, content);
        var likesText = likesObj.gameObject.transform.Find("TraitsText").GetComponent<TextMeshProUGUI>();
        likesText.text = pinboardText;
    }




}
