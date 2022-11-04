using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PinboardManager : MonoBehaviour
{
    public static PinboardManager pinboard;

    [SerializeField]
    Transform GoonLikesContent;

    [SerializeField]
    Transform GoonDislikesContent;

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
            UpdateGoonLikes("COOL GUY");
        }

        if(Input.GetKeyUp(KeyCode.KeypadMinus))
        {
            UpdateGoonDislikes("JUICEBOX");
        }
    }

    void UpdateGoonLikes(string goonLikesText)
    {
        GameObject likesObj = Instantiate(CharacterTraitsUI, GoonLikesContent);
        var likesText = likesObj.gameObject.transform.Find("TraitsText").GetComponent<TextMeshProUGUI>();
        likesText.text = goonLikesText;
    }

    void UpdateGoonDislikes(string goonDislikesText)
    {
        GameObject dislikesObj = Instantiate(CharacterTraitsUI, GoonDislikesContent);
        var dislikesText = dislikesObj.gameObject.transform.Find("TraitsText").GetComponent<TextMeshProUGUI>();
        dislikesText.text = goonDislikesText;
    }




}
