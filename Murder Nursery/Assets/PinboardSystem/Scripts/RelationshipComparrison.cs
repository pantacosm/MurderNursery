using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// shows the relationship between two selected characters from the pin-board
public class RelationshipComparrison : MonoBehaviour
{
    private InventoryManager pinboardVisibility;

    [HideInInspector]
    public RelationshipDetails details;

    [HideInInspector]
    public string textToChange;

    [SerializeField]
    GameObject charactersSelected;

    [SerializeField]
    GameObject relationshipPanel;

    // used for opening relationship options panel
    public GameObject relationshipOptionsPanel;

    TextMeshProUGUI charNameTextLeft;
    TextMeshProUGUI charNameTextRight;

    private bool goonSelected;
    private bool coolguySelected;
    private bool juiceboxSelected;
    private bool femmeSelected;
    private bool deadGirlSelected;

    // array of text containing undiscovered info about characters' relationship
    [HideInInspector]
    public string[] relationShipContents;
    
    // Start is called before the first frame update
    void Start()
    {
        pinboardVisibility = FindObjectOfType<InventoryManager>();
        details = GetComponent<RelationshipDetails>();

        charNameTextLeft = charactersSelected.transform.Find("NameLeft").GetComponent<TextMeshProUGUI>();
        charNameTextRight = charactersSelected.transform.Find("NameRight").GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {

        UpdateCharactersSelected();

        if(Input.GetKeyUp(KeyCode.O))
        {
            details.AddToRelationshipOptionsUI("Goon dislikes Juice Box cos he's dating Femme.");
        }

    }

    // Updates relationshipPanel text to show which characters relationship is being viewed
    void UpdateCharactersSelected()
    {
        GoonSelected();
        CoolGuySelected();
        JuiceBoxSelected();
        FemmeSelected();
        DeadGirlSelected();
    }

    public void UpdateRelationshipContents(string contentsText)
    {
        details.UpdateRelationship(contentsText);
    }

    void SetActivePanel()
    {
        relationshipPanel.SetActive(true);
        pinboardVisibility.UIVisibility.pinboardUI.SetActive(false);
    }

    // Called on OnClick() in Pinboard Panel buttons (Click characters name, must click two names to show their relationship)
    public void Goon()
    {
        goonSelected = true;
    }

    public void JuiceBox()
    {
        juiceboxSelected = true;
    }

    public void CoolGuy()
    {
        coolguySelected = true;
    }

    public void Femme()
    {
        femmeSelected = true;
    }

    public void DeadGirl()
    {
        deadGirlSelected = true;
    }

    // once two names are selected it shows their relationship with each other
    void GoonSelected()
    {
        if(goonSelected)
        {
            charNameTextLeft.text = "Goon";
            if(juiceboxSelected)
            {
                charNameTextRight.text = "Juice Box";
                juiceboxSelected = false;
                goonSelected = false;
                SetActivePanel();
                details.ClearDetails();
                UpdateRelationshipContents("Goon ????? Juice Box because ?????.");
                UpdateRelationshipContents("Juice Box likes Goon.");
            }
            if(coolguySelected)
            {
                charNameTextRight.text = "Cool Guy";
                coolguySelected = false;
                goonSelected = false;
                details.ClearDetails();
                UpdateRelationshipContents("Goon likes Cool Guy.");
                SetActivePanel();

            }
            if(femmeSelected)
            {
                charNameTextRight.text = "Femme";
                femmeSelected = false;
                goonSelected = false;
                SetActivePanel();
            }
            if(deadGirlSelected)
            {
                charNameTextRight.text = "Dead Girl";
                deadGirlSelected = false;
                goonSelected = false;
                SetActivePanel();
            }
        }
    }

    void CoolGuySelected()
    {
        if(coolguySelected)
        {
            charNameTextLeft.text = "Cool Guy";
            if(juiceboxSelected)
            {
                charNameTextRight.text = "Juice Box";
                juiceboxSelected = false;
                coolguySelected = false;
                SetActivePanel();
            }
            if(goonSelected)
            {
                charNameTextRight.text = "Goon";
                goonSelected = false;
                coolguySelected = false;
                SetActivePanel();
            }
            if(femmeSelected)
            {
                charNameTextRight.text = "Femme";
                femmeSelected = false;
                coolguySelected = false;
                SetActivePanel();
            }
            if(deadGirlSelected)
            {
                charNameTextRight.text = "Dead Girl";
                deadGirlSelected = false;
                coolguySelected = false;
                SetActivePanel();
            }
        }
    }

    void JuiceBoxSelected()
    {
        if(juiceboxSelected)
        {
            charNameTextLeft.text = "Juice Box";
            if(coolguySelected)
            {
                charNameTextRight.text = "Cool Guy";
                juiceboxSelected = false;
                coolguySelected = false;
                SetActivePanel();
            }
            if(goonSelected)
            {
                
                charNameTextRight.text = "Goon";
                goonSelected = false;
                juiceboxSelected = false;
                SetActivePanel();
            }
            if(femmeSelected)
            {
                
                charNameTextRight.text = "Femme";
                femmeSelected = false;
                juiceboxSelected = false;
                SetActivePanel();
            }
            if(deadGirlSelected)
            {
                
                charNameTextRight.text = "Dead Girl";
                deadGirlSelected = false;
                juiceboxSelected = false;
                SetActivePanel();
            }
        }
    }

    void FemmeSelected()
    {
        if(femmeSelected)
        {
            charNameTextLeft.text = "Femme";
            if(juiceboxSelected)
            {
                
                charNameTextRight.text = "Juice Box";
                juiceboxSelected = false;
                femmeSelected = false;
                SetActivePanel();
            }
            if(goonSelected)
            {
                
                charNameTextRight.text = "Goon";
                goonSelected = false;
                femmeSelected = false;
                SetActivePanel();
            }
            if(coolguySelected)
            {
                
                charNameTextRight.text = "Cool Guy";
                femmeSelected = false;
                coolguySelected = false;
                SetActivePanel();
            }
            if(deadGirlSelected)
            {
                
                charNameTextRight.text = "Dead Girl";
                deadGirlSelected = false;
                femmeSelected = false;
                SetActivePanel();
            }
        }
    }

    void DeadGirlSelected()
    {
        if(deadGirlSelected)
        {
            charNameTextLeft.text = "Dead Girl";
            if(juiceboxSelected)
            {
                
                charNameTextRight.text = "Juice Box";
                juiceboxSelected = false;
                deadGirlSelected = false;
                SetActivePanel();
            }
            if(goonSelected)
            {
                
                charNameTextRight.text = "Goon";
                goonSelected = false;
                deadGirlSelected = false;
                SetActivePanel();
            }
            if(femmeSelected)
            {
                
                charNameTextRight.text = "Femme";
                femmeSelected = false;
                deadGirlSelected = false;
                SetActivePanel();
            }
            if(coolguySelected)
            {
                
                charNameTextRight.text = "Cool Guy";
                deadGirlSelected = false;
                coolguySelected = false;
                SetActivePanel();
            }
        }
    }
}
