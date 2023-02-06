using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DressUp : MonoBehaviour
{
    private bool interactable = false;//Signals that the player is within interaction range
    private string activeOutfit = null; //Stores the outfit currently worn by the player
    [HideInInspector]
    public bool inDressUp = false; //Signals that the player is in the dressup menu

    [Header("UI Elements")]
    public GameObject interactableText; //Text that is displayed when the player is within range of the dress up box
    public GameObject dressUpMenu; //UI element containing all of the dress up menu components 
    public GameObject artistButton; //Button used for changing outfits
    public GameObject wizardButton; //''
    public GameObject gangsterButton; //''
    public GameObject detectiveButton;//''
    private GameObject inactiveButton;//Stores button which contains the outfit the player is currently wearing

    //Position vectors for UI management
    private Vector3 firstButton;
    private Vector3 secondButton;
    private Vector3 thirdButton;

    [Header("Audio")]
    public AudioSource playerAudio; //Audio heard by the player
    public AudioClip openBoxSound; //Sound played when entering dress up menu
    public AudioClip changeOutfitSound; //Sound played when changing an outfit
    
    // Start is called before the first frame update
    void Start()
    {
        activeOutfit = "Detective Outfit"; //Sets the active outfit to the detective outfit at the start of the game 
        firstButton = new Vector3(410.5f, 540.0f, 0.0f); //Sets the initial positions of the buttons
        secondButton = new Vector3(960.0f, 540.0f, 0.0f);//''
        thirdButton = new Vector3(1533.5f, 540.0f, 0.0f);//''
        inactiveButton = detectiveButton; //Sets the inactive button as the detective button
    }

    


    // Update is called once per frame
    void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.E)) //Allows the player to open the dress up menu 
        {
            inDressUp = true; //Signals that the player is in dress up 
            interactableText.SetActive(false); 
            dressUpMenu.SetActive(true); //Activates the dress up menu UI
            Cursor.visible = true; //CURSOR STUFF - UPDATE
            Cursor.lockState = CursorLockMode.None;
            playerAudio.PlayOneShot(openBoxSound, 0.5f); //Plays the toggle dress up menu sound 
        }

        if(inDressUp && Input.GetKeyDown(KeyCode.Escape)) //Allows the player to leave the dress up menu 
        {
            ExitDressUp();
            playerAudio.PlayOneShot(openBoxSound, 0.5f); //Plays the toggle dress up menu sound 
            Cursor.visible = false; //CURSOR STUFF- UPDATE
        }

    }

    public bool CheckOutfit(string requiredOutfit) //Used to check if the player is wearing the relevant outfit 
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

    public void ChangeToArtistOutfit() //Changes the player's current outfit to the artist outfit
    {
        activeOutfit = "Artist Outfit";
        print("You are now wearing the " + activeOutfit);
        UpdateOutfitChoices(artistButton);
        ExitDressUp();
        playerAudio.PlayOneShot(changeOutfitSound, 0.5f); //Plays the outfit change sound
        //Add code here for visual changes
    }

    public void ChangeToWizardOutfit() //Changes the player's current outfit to the wizard outfit 
    {
        activeOutfit = "Wizard Outfit";
        print("You are now wearing the " + activeOutfit);
        UpdateOutfitChoices(wizardButton);
        ExitDressUp();
        playerAudio.PlayOneShot(changeOutfitSound, 0.5f); //Plays the outfit change sound
        //Add code here for visual changes
    }

    public void ChangeToGangsterOutfit() //Changes the player's current outfit to the gangster outfit
    {
        activeOutfit = "Gangster Outfit";
        print("You are now wearing the " + activeOutfit);
        UpdateOutfitChoices(gangsterButton);
        ExitDressUp();
        playerAudio.PlayOneShot(changeOutfitSound, 0.5f); //Plays the outfit change sound
        //Add code here for visual changes;
    }

    public void ChangeToDetectiveOutfit() //Changes the player's current outfit to the detective outfit 
    {
        activeOutfit = "Detective Outfit";
        print("You are now wearing the " + activeOutfit);
        UpdateOutfitChoices(detectiveButton);
        ExitDressUp();
        playerAudio.PlayOneShot(changeOutfitSound, 0.5f); //Plays the outfit change sound
        //Add code here for visual changes
    }

    private void UpdateOutfitChoices(GameObject buttonClicked) //Updates the dress up menu UI to display the current available outfits
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
    public void OnTriggerEnter(Collider other) //Used to detect if the player is within range of the dress up box
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

    public void ExitDressUp() //Used to exit the dress up menu 
    {
        dressUpMenu.SetActive(false);
        interactableText.SetActive(true);
        inDressUp = false;
        Cursor.visible = false;
    }
}
