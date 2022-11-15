using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReputationManager : MonoBehaviour
{
    [SerializeField]
    GameObject JotterUI;

    [SerializeField]
    GameObject friendshipStarPrefab;

    [SerializeField]
    GameObject skullPrefab;

    [SerializeField]
    Transform GoonContent;

    [SerializeField]
    Transform FemmeContent;

    [SerializeField]
    Transform JuiceBoxContent;

    [SerializeField]
    Transform CoolGuyContent;

    [SerializeField]
    GameObject characterPanel;

    [SerializeField]
    Transform characterTierContent;

    [SerializeField]
    GameObject notesPrefab;

    [SerializeField]
    Transform goonNotesContent;

    [SerializeField]
    Transform femmeNotesContent;

    [SerializeField]
    Transform juiceboxNotesContent;

    [SerializeField]
    Transform coolguyNotesContent;

    // keeps track of our reputation with each character ( -1 = Bully, 5 = Friend, 10 = Best Friend etc.)
    [Header( "Reputation Points" )]
    public int goonPoints = 0;
    public int coolGuyPoints = 0;
    public int femmePoints = 0;
    public int juiceBoxPoints = 0;

    [Header( "Reputation Notes" )]
    public string[] goonNotes;
    public string[] femmeNotes;
    public string[] juiceboxNotes;
    public string[] coolguyNotes;

    public enum FriendshipTier {Bully, Stranger, Classmates, Friends, BestFriends};

    [HideInInspector]
    public FriendshipTier goonTier = FriendshipTier.Stranger;

    [HideInInspector]
    public FriendshipTier coolGuyTier = FriendshipTier.Stranger;

    [HideInInspector]
    public FriendshipTier femmeTier = FriendshipTier.Stranger;

    [HideInInspector]
    public FriendshipTier juiceBoxTier = FriendshipTier.Stranger;

    private void Start()
    {
        goonNotesContent.gameObject.SetActive(false);
        coolguyNotesContent.gameObject.SetActive(false);
        femmeNotesContent.gameObject.SetActive(false);
        juiceboxNotesContent.gameObject.SetActive(false);

    }

    private void Update()
    {
        HandleRep(GoonContent, goonPoints);
        HandleRep(JuiceBoxContent, juiceBoxPoints);
        HandleRep(FemmeContent, femmePoints);
        HandleRep(CoolGuyContent, coolGuyPoints);
    }

    // Called as an onClick() Event when we click a character to view in the Jotter (updated FriendshipNotes UI details)
    public void UpdateGoon()
    {
        characterPanel.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = "Goon";
        UpdateTierText(goonTier);
        UpdateCharacterTierContent(GoonContent, goonPoints);
        goonNotesContent.gameObject.SetActive(true);
        coolguyNotesContent.gameObject.SetActive(false);
        femmeNotesContent.gameObject.SetActive(false);
        juiceboxNotesContent.gameObject.SetActive(false);

    }

    public void UpdateCoolGuy()
    {
        characterPanel.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = "Cool Guy";
        UpdateTierText(coolGuyTier);
        UpdateCharacterTierContent(CoolGuyContent, coolGuyPoints);
        goonNotesContent.gameObject.SetActive(false);
        coolguyNotesContent.gameObject.SetActive(true);
        femmeNotesContent.gameObject.SetActive(false);
        juiceboxNotesContent.gameObject.SetActive(false);


    }

    public void UpdateFemme()
    {
        characterPanel.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = "Femme";
        UpdateTierText(femmeTier);
        UpdateCharacterTierContent(FemmeContent, femmePoints);
        goonNotesContent.gameObject.SetActive(false);
        coolguyNotesContent.gameObject.SetActive(false);
        femmeNotesContent.gameObject.SetActive(true);
        juiceboxNotesContent.gameObject.SetActive(false);


    }

    public void UpdateJuiceBox()
    {
        characterPanel.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = "Juice Box";
        UpdateTierText(juiceBoxTier);
        UpdateCharacterTierContent(JuiceBoxContent, juiceBoxPoints);
        goonNotesContent.gameObject.SetActive(false);
        coolguyNotesContent.gameObject.SetActive(false);
        femmeNotesContent.gameObject.SetActive(false);
        juiceboxNotesContent.gameObject.SetActive(true);

    }


    // Called any time we want to add to or update a characters notes in the JotterUI
    public void UpdateNotes(Transform content, string noteToAdd)
    {
        GameObject notesObj = Instantiate(notesPrefab, content);
        var contentText = notesObj.transform.Find("NotesText").GetComponent<TextMeshProUGUI>();
        contentText.text = noteToAdd;
    }

    // Called when we want to add/subtract rep points (calculation done inside parameter when called "goonPoints += 1")
    public void UpdateReputation(int pointsToUpdate)
    {
        // points capped between -1 & 10

        if(goonPoints <= -1) {goonPoints = -1;}
        print("Goon points = " + goonPoints);
        if(femmePoints <= -1) {femmePoints = -1;}
        if(coolGuyPoints <= -1) {coolGuyPoints = -1;}
        if(juiceBoxPoints <= -1) {juiceBoxPoints = -1;}

        if(goonPoints >= 10) {goonPoints = 10;}
        if(femmePoints >= 10) {femmePoints = 10;}
        if(coolGuyPoints >= 10) {coolGuyPoints = 10;}
        if(juiceBoxPoints >= 10) {juiceBoxPoints = 10;}

    }

    // Called any time we want to update the friendship tier images (e.g. how many stars are shown) 
    void UpdateRepTier(Transform content, GameObject prefab)
    {
        Instantiate(prefab, content);
    }

    // Updates amount of images are loaded in (stars or skull) inside the FriendshipNotes UI
    void UpdateCharacterTierContent(Transform content, int points)
    {
        // Clean up content before adding new content
        if (characterTierContent.childCount > 0)
        {
            foreach (Transform item in characterTierContent)
            {
                Destroy(item.gameObject);
            }
        }

        // Checks the content inside characters FrienshipTierUI of the Jotter and loads in the same amount 
        for (int i = 0; i < content.childCount; i++)
        {
            if(points == -1)
            {
                Instantiate(skullPrefab, characterTierContent);
            }
            else if(i < 5)
            {
                Instantiate(friendshipStarPrefab, characterTierContent);
            }
        }
    }

    // Updates reputation text in the JotterUI depending their friendship tier enum
    void UpdateTierText(FriendshipTier tier)
    {
        string textToDisaply = "";

        if(tier == FriendshipTier.Bully)
        {
            textToDisaply = "Reputation: Bully";
        }
        if(tier == FriendshipTier.Stranger)
        {
            textToDisaply = "Reputation: Strangers";
        }
        if(tier == FriendshipTier.Classmates)
        {
            textToDisaply = "Reputation: Classmates";
        }
        if(tier == FriendshipTier.Friends)
        {
            textToDisaply = "Reputation: Friends";
        }
        if(tier == FriendshipTier.BestFriends)
        {
            textToDisaply = "Reputation: Best Friends";
        }

        characterPanel.transform.Find("TierText").GetComponent<TextMeshProUGUI>().text = textToDisaply;
    }

    // Updates characters rep details depending on the amount of points you have with them
    void HandleRep(Transform content, int points)
    {
        // Handles gaining / losing Skull & updating Friendship Tier enum
        if (points == -1 && content.childCount == 0)
        {
            UpdateRepTier(content, skullPrefab);
            if(goonPoints == -1)
            {
                goonTier = FriendshipTier.Bully;
            }
            if(femmePoints == -1)
            {
                femmeTier = FriendshipTier.Bully;
            }
            if(coolGuyPoints == -1)
            {
                coolGuyTier = FriendshipTier.Bully;
            }
            if(juiceBoxPoints == -1)
            {
                juiceBoxTier = FriendshipTier.Bully;
            }
        }
        if(points == 0 && content.childCount > 0)
        {
            Destroy(content.GetChild(0).gameObject);
        }

        // Handles gaining Stars & updating Friendship Tier enum
        if (points == 2 || points == 3 || points == 5 || points == 7 || points == 10)
        {
            if(content.childCount < 5)
            {
                UpdateRepTier(content, friendshipStarPrefab);
            }
        }

        if(points >= 0 && points < 2)
        {
            if(goonPoints == points)
            {
                goonTier = FriendshipTier.Stranger;
            }
            if(coolGuyPoints == points)
            {
                coolGuyTier = FriendshipTier.Stranger;
            }
            if(femmePoints == points)
            {
                femmeTier = FriendshipTier.Stranger;
            }
            if(juiceBoxPoints == points)
            {
                juiceBoxTier = FriendshipTier.Stranger;
            }
        }
        if(points >= 2 && points < 5)
        {
            if(goonPoints == points)
            {
                goonTier = FriendshipTier.Classmates;
            }
            if(coolGuyPoints == points)
            {
                coolGuyTier = FriendshipTier.Classmates;
            }
            if(femmePoints == points)
            {
                femmeTier = FriendshipTier.Classmates;
            }
            if(juiceBoxPoints == points)
            {
                juiceBoxTier = FriendshipTier.Classmates;
            }
        }
        if(points >= 5 && points < 10)
        {
            if(goonPoints == points)
            {
                goonTier = FriendshipTier.Friends;
            }
            if(coolGuyPoints == points)
            {
                coolGuyTier = FriendshipTier.Friends;
            }
            if(femmePoints == points)
            {
                femmeTier = FriendshipTier.Friends;
            }
            if(juiceBoxPoints == points)
            {
                juiceBoxTier = FriendshipTier.Friends;
            }
        }
        if(points >= 10)
        {
            if(goonPoints == points)
            {
                goonTier = FriendshipTier.BestFriends;
            }
            if(coolGuyPoints == points)
            {
                coolGuyTier = FriendshipTier.BestFriends;
            }
            if(femmePoints == points)
            {
                femmeTier = FriendshipTier.BestFriends;
            }
            if(juiceBoxPoints == points)
            {
                juiceBoxTier = FriendshipTier.BestFriends;
            }
        }

        // Destroys Stars if rep points are decreased
        if(content.childCount > 0 && points < 2 && points != -1)
        {
            Destroy(content.GetChild(0).gameObject);
        }

        if(content.childCount > 1 && points < 3)
        {
            Destroy(content.GetChild(1).gameObject);
        }

        if(content.childCount > 2 && points < 5)
        {
            Destroy(content.GetChild(2).gameObject);
        }

        if(content.childCount > 3 && points < 7)
        {
            Destroy(content.GetChild(3).gameObject);
        }

        if(content.childCount > 4 && points < 10)
        {
            Destroy(content.GetChild(4).gameObject);
        }
    }


}
