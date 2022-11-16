using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// shows the relationship between two selected characters from the pin-board
public class RelationshipComparrison : MonoBehaviour
{
    // called when we want to hide the pin-board
    private InventoryManager pinboardVisibility;

    // reference to relationship details component
    [HideInInspector]
    public RelationshipDetails details;

    // stores characters name text so we know which relationship we're currently viewing
    [SerializeField]
    GameObject charactersSelected;

    [SerializeField]
    GameObject relationshipPanel;

    // updates based on the character relationship we are viewing (displays Goon & Juice Box etc.)
    TextMeshProUGUI charNameTextLeft;
    TextMeshProUGUI charNameTextRight;

    // set once we select which characters relationship to view
    private bool goonSelected;
    private bool coolguySelected;
    private bool juiceboxSelected;
    private bool femmeSelected;
    private bool deadGirlSelected;
    
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

    // Called when two characters are selected (hides pin-board & shows relationship panel)
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
                details.UpdateRelationship(details.goonJuiceList);
                SetActivePanel();
            }
            if(coolguySelected)
            {
                charNameTextRight.text = "Cool Guy";
                coolguySelected = false;
                goonSelected = false;
                details.UpdateRelationship(details.goonCoolguyList);
                SetActivePanel();

            }
            if(femmeSelected)
            {
                charNameTextRight.text = "Femme";
                femmeSelected = false;
                goonSelected = false;
                details.UpdateRelationship(new());
                SetActivePanel();
            }
            if(deadGirlSelected)
            {
                charNameTextRight.text = "Dead Girl";
                deadGirlSelected = false;
                goonSelected = false;
                details.UpdateRelationship(new());
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
                details.UpdateRelationship(new());
                SetActivePanel();

            }
            if(goonSelected)
            {
                charNameTextRight.text = "Goon";
                goonSelected = false;
                coolguySelected = false;
                details.UpdateRelationship(new());
                SetActivePanel();

            }
            if(femmeSelected)
            {
                charNameTextRight.text = "Femme";
                femmeSelected = false;
                coolguySelected = false;
                details.UpdateRelationship(new());
                SetActivePanel();

            }
            if(deadGirlSelected)
            {
                charNameTextRight.text = "Dead Girl";
                deadGirlSelected = false;
                coolguySelected = false;
                details.UpdateRelationship(new());
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
                details.UpdateRelationship(new());
                SetActivePanel();
            }
            if(goonSelected)
            {
                
                charNameTextRight.text = "Goon";
                goonSelected = false;
                juiceboxSelected = false;
                details.UpdateRelationship(new());
                SetActivePanel();
            }
            if(femmeSelected)
            {
                
                charNameTextRight.text = "Femme";
                femmeSelected = false;
                juiceboxSelected = false;
                details.UpdateRelationship(new());
                SetActivePanel();
            }
            if(deadGirlSelected)
            {
                
                charNameTextRight.text = "Dead Girl";
                deadGirlSelected = false;
                juiceboxSelected = false;
                details.UpdateRelationship(new());
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
                details.UpdateRelationship(new());
                SetActivePanel();
            }
            if(goonSelected)
            {
                
                charNameTextRight.text = "Goon";
                goonSelected = false;
                femmeSelected = false;
                details.UpdateRelationship(new());
                SetActivePanel();
            }
            if(coolguySelected)
            {
                
                charNameTextRight.text = "Cool Guy";
                femmeSelected = false;
                coolguySelected = false;
                details.UpdateRelationship(new());
                SetActivePanel();
            }
            if(deadGirlSelected)
            {
                
                charNameTextRight.text = "Dead Girl";
                deadGirlSelected = false;
                femmeSelected = false;
                details.UpdateRelationship(new());
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
                details.UpdateRelationship(new());
                SetActivePanel();
            }
            if(goonSelected)
            {
                
                charNameTextRight.text = "Goon";
                goonSelected = false;
                deadGirlSelected = false;
                details.UpdateRelationship(new());
                SetActivePanel();
            }
            if(femmeSelected)
            {
                
                charNameTextRight.text = "Femme";
                femmeSelected = false;
                deadGirlSelected = false;
                details.UpdateRelationship(new());
                SetActivePanel();
            }
            if(coolguySelected)
            {
                
                charNameTextRight.text = "Cool Guy";
                deadGirlSelected = false;
                coolguySelected = false;
                details.UpdateRelationship(new());
                SetActivePanel();
            }
        }
    }
}
