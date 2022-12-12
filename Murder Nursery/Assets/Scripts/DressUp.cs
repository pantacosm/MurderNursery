using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DressUp : MonoBehaviour
{
    private bool interactable = false;
    public string activeOutfit = null;
    public GameObject interactableText;
    public GameObject dressUpMenu;
    public bool inDressUp = false;
    public GameObject artistButton;
    public GameObject wizardButton;
    public GameObject gangsterButton;
    public GameObject detectiveButton;
    private GameObject inactiveButton;
    private Vector3 firstButton;
    private Vector3 secondButton;
    private Vector3 thirdButton;
    public AudioSource playerAudio;
    public AudioClip openBoxSound;
    public AudioClip changeOutfitSound;
    
    // Start is called before the first frame update
    void Start()
    {
        activeOutfit = "Detective Outfit";
        firstButton = new Vector3(410.5f, 540.0f, 0.0f);
        secondButton = new Vector3(960.0f, 540.0f, 0.0f);
        thirdButton = new Vector3(1533.5f, 540.0f, 0.0f);
        inactiveButton = detectiveButton;
    }

    


    // Update is called once per frame
    void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.E))
        {

            inDressUp = true;
            interactableText.SetActive(false);
            dressUpMenu.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            playerAudio.PlayOneShot(openBoxSound, 0.5f);
        }

        if(inDressUp && Input.GetKeyDown(KeyCode.Escape))
        {
            ExitDressUp();
            playerAudio.PlayOneShot(openBoxSound, 0.5f);
            Cursor.visible = false;
        }

    }

    public bool CheckOutfit(string requiredOutfit)
    {
        if(requiredOutfit == activeOutfit)
        {
            return true;
        }
        if(requiredOutfit != activeOutfit)
        {
            return false;
        }
        return false;
    }

    public void ChangeToArtistOutfit()
    {
        activeOutfit = "Artist Outfit";
        print("You are now wearing the " + activeOutfit);
        UpdateOutfitChoices(artistButton);
        ExitDressUp();
        playerAudio.PlayOneShot(changeOutfitSound, 0.5f);
        //Add code here for visual changes
    }

    public void ChangeToWizardOutfit()
    {
        activeOutfit = "Wizard Outfit";
        print("You are now wearing the " + activeOutfit);
        UpdateOutfitChoices(wizardButton);
        ExitDressUp();
        playerAudio.PlayOneShot(changeOutfitSound, 0.5f);
        //Add code here for visual changes
    }

    public void ChangeToGangsterOutfit()
    {
        activeOutfit = "Gangster Outfit";
        print("You are now wearing the " + activeOutfit);
        UpdateOutfitChoices(gangsterButton);
        ExitDressUp();
        playerAudio.PlayOneShot(changeOutfitSound, 0.5f);
        //Add code here for visual changes;
    }

    public void ChangeToDetectiveOutfit()
    {
        activeOutfit = "Detective Outfit";
        print("You are now wearing the " + activeOutfit);
        UpdateOutfitChoices(detectiveButton);
        ExitDressUp();
        playerAudio.PlayOneShot(changeOutfitSound, 0.5f);
        //Add code here for visual changes
    }

    private void UpdateOutfitChoices(GameObject buttonClicked)
    {
        if(buttonClicked.transform.position == firstButton)
        {
            buttonClicked.SetActive(false);
            inactiveButton.transform.position = firstButton;
            inactiveButton.SetActive(true);
            inactiveButton = buttonClicked;
        }
        if(buttonClicked.transform.position == secondButton)
        {
            buttonClicked.SetActive(false);
            inactiveButton.transform.position = secondButton;
            inactiveButton.SetActive(true);
            inactiveButton = buttonClicked;
        }
        if(buttonClicked.transform.position == thirdButton)
        {
            buttonClicked.SetActive(false);
            inactiveButton.transform.position = thirdButton;
            inactiveButton.SetActive(true);
            inactiveButton = buttonClicked;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "DetectiveDrew")
        {
            interactable = true;
            interactableText.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        
            interactable = false;
            interactableText.SetActive(false);
        
    }

    public void ExitDressUp()
    {
        dressUpMenu.SetActive(false);
        interactableText.SetActive(true);
        inDressUp = false;
        Cursor.visible = false;
    }
}
