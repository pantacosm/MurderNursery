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

    [HideInInspector]
    public string textToReplace;

    // stores characters name text
    [SerializeField]
    GameObject charactersSelected;

    [SerializeField]
    GameObject relationshipPanel;

    // used for opening relationship options panel
    public GameObject relationshipOptionsPanel;

    // updates based on the character relationship we are viewing (displays Goon & Juice Box etc.)
    TextMeshProUGUI charNameTextLeft;
    TextMeshProUGUI charNameTextRight;

    // set once we select which characters relationship to view
    private bool goonSelected;
    private bool coolguySelected;
    private bool juiceboxSelected;
    private bool femmeSelected;
    private bool deadGirlSelected;

    [Header ("False/Undiscovered Relationship Contents")]
    public string goonJuiceContent1;
    public string goonJuiceContent2;
    public string goonCoolContent1;

    [Header("Relationship Conclusions")]
    public string goonJuiceConclusion1;
    public string goonJuiceConclusion2;
    public string goonCoolConclusion1;
    
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
            details.AddToRelationshipOptionsUI(goonJuiceConclusion1);
            details.AddToRelationshipOptionsUI(goonJuiceConclusion2);
            details.AddToRelationshipOptionsUI(goonCoolConclusion1);
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

    // Called when we want to update info in the relationship panel
    public void UpdateRelationshipContents(string[] contents)
    {
        details.ClearDetails();
        foreach (var item in contents)
        {
            details.UpdateRelationship(item);
        }
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
                SetActivePanel();
                UpdateRelationshipContents(new string[] {goonJuiceContent1, goonJuiceContent2 });
            }
            if(coolguySelected)
            {
                charNameTextRight.text = "Cool Guy";
                coolguySelected = false;
                goonSelected = false;
                SetActivePanel();
                UpdateRelationshipContents(new string[] {goonCoolContent1 });

            }
            if(femmeSelected)
            {
                charNameTextRight.text = "Femme";
                femmeSelected = false;
                goonSelected = false;
                SetActivePanel();
                UpdateRelationshipContents(new string[] { } );
            }
            if(deadGirlSelected)
            {
                charNameTextRight.text = "Dead Girl";
                deadGirlSelected = false;
                goonSelected = false;
                SetActivePanel();
                UpdateRelationshipContents(new string[] { } );
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
                UpdateRelationshipContents(new string[] { } );
            }
            if(goonSelected)
            {
                charNameTextRight.text = "Goon";
                goonSelected = false;
                coolguySelected = false;
                SetActivePanel();
                UpdateRelationshipContents(new string[] { } );
            }
            if(femmeSelected)
            {
                charNameTextRight.text = "Femme";
                femmeSelected = false;
                coolguySelected = false;
                SetActivePanel();
                UpdateRelationshipContents(new string[] { } );
            }
            if(deadGirlSelected)
            {
                charNameTextRight.text = "Dead Girl";
                deadGirlSelected = false;
                coolguySelected = false;
                SetActivePanel();
                UpdateRelationshipContents(new string[] { } );
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
                UpdateRelationshipContents(new string[] { } );
            }
            if(goonSelected)
            {
                
                charNameTextRight.text = "Goon";
                goonSelected = false;
                juiceboxSelected = false;
                SetActivePanel();
                UpdateRelationshipContents(new string[] { } );
            }
            if(femmeSelected)
            {
                
                charNameTextRight.text = "Femme";
                femmeSelected = false;
                juiceboxSelected = false;
                SetActivePanel();
                UpdateRelationshipContents(new string[] { } );
            }
            if(deadGirlSelected)
            {
                
                charNameTextRight.text = "Dead Girl";
                deadGirlSelected = false;
                juiceboxSelected = false;
                SetActivePanel();
                UpdateRelationshipContents(new string[] { } );
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
                UpdateRelationshipContents(new string[] { } );
            }
            if(goonSelected)
            {
                
                charNameTextRight.text = "Goon";
                goonSelected = false;
                femmeSelected = false;
                SetActivePanel();
                UpdateRelationshipContents(new string[] { } );
            }
            if(coolguySelected)
            {
                
                charNameTextRight.text = "Cool Guy";
                femmeSelected = false;
                coolguySelected = false;
                SetActivePanel();
                UpdateRelationshipContents(new string[] { } );
            }
            if(deadGirlSelected)
            {
                
                charNameTextRight.text = "Dead Girl";
                deadGirlSelected = false;
                femmeSelected = false;
                SetActivePanel();
                UpdateRelationshipContents(new string[] { } );
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
                UpdateRelationshipContents(new string[] { } );
            }
            if(goonSelected)
            {
                
                charNameTextRight.text = "Goon";
                goonSelected = false;
                deadGirlSelected = false;
                SetActivePanel();
                UpdateRelationshipContents(new string[] { } );
            }
            if(femmeSelected)
            {
                
                charNameTextRight.text = "Femme";
                femmeSelected = false;
                deadGirlSelected = false;
                SetActivePanel();
                UpdateRelationshipContents(new string[] { } );
            }
            if(coolguySelected)
            {
                
                charNameTextRight.text = "Cool Guy";
                deadGirlSelected = false;
                coolguySelected = false;
                SetActivePanel();
                UpdateRelationshipContents(new string[] { } );
            }
        }
    }
}
