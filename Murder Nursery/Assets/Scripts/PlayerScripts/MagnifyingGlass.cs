using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MagnifyingGlass : MonoBehaviour
{
    PinboardManager PM;

    [HideInInspector]
    public bool usingMagnifyingGlass; // used in player movement script for switching from third/first person movement

    [HideInInspector]
    public GameObject evidenceItem; // item the player is currently viewing through the magnifying glass

    [SerializeField]
    GameObject thirdPersonCam;

    [SerializeField]
    GameObject firstPersonCam; // first person camera

    public GameObject magnifyingBlur; // activates a blur effect whilst using the MG

    [SerializeField]
    GameObject magGlass; // hide mag glass when inspecting item

    [SerializeField]
    GameObject storeItemText; // text pop up to inform player they can pick up the evidence

    public GameObject evidenceHelpText;


    private void Start()
    {
        PM = FindObjectOfType<PinboardManager>();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && evidenceItem)
        {
            GameObject evidenceUI = evidenceItem.GetComponent<EvidenceItem>().evidenceToAdd; // evidence to add to pinboard
            storeItemText.SetActive(false);

            if(!evidenceUI.GetComponent<EvidenceClass>().evidenceFound) // check the evidence hasnt already been found
            {
                // update the pinboard with new evidence
                PM.discoveredEvidence.Add(evidenceUI.GetComponent<EvidenceClass>());
                PM.UpdateEvidenceImages(evidenceUI.GetComponent<EvidenceClass>());
                evidenceUI.GetComponent<EvidenceClass>().evidenceFound = true;
            }

            // check if item has a fingerprint for inspection
            if(evidenceItem.GetComponentInChildren<Fingerprint>())
            {
                evidenceItem.GetComponent<EvidenceItem>().InspectItem();
                magnifyingBlur.SetActive(false);
                evidenceItem.GetComponent<ParticleSystem>().Stop();
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(evidenceItem);
            }

        }
    }

    // transitions between third person / first person camera &
    // toggles a magnifying glass to be used for finding evidence
    public void ToggleMagnifyingGlass() 
    {
        {
            if(usingMagnifyingGlass = !usingMagnifyingGlass)
            {
                usingMagnifyingGlass = true;
                thirdPersonCam.SetActive(false);
                firstPersonCam.SetActive(true);
                gameObject.SetActive(true);
                magnifyingBlur.SetActive(true);   
                evidenceHelpText.SetActive(true);
            }
            else
            {
                usingMagnifyingGlass = false;
                firstPersonCam.SetActive(false);
                thirdPersonCam.SetActive(true);
                magnifyingBlur.SetActive(false);
                storeItemText.SetActive(false);
                evidenceHelpText.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Evidence Item") && usingMagnifyingGlass)
        {
            if (other.gameObject.GetComponentInChildren<Fingerprint>())
            {
                GameObject fingerprint = other.gameObject.GetComponentInChildren<Fingerprint>().gameObject;
                fingerprint.GetComponent<SpriteRenderer>().enabled = true;
            }

            other.gameObject.GetComponent<MeshRenderer>().enabled = true; // allows player to see the item
            other.gameObject.GetComponent<ParticleSystem>().Play(); // plays the particle effect attached to item
            evidenceItem = other.gameObject;

            if(evidenceItem.GetComponentInChildren<Fingerprint>())
            {
                storeItemText.GetComponent<TextMeshProUGUI>().text = "Press [E] to inspect " + other.name;
            }
            else
            {
                storeItemText.GetComponent<TextMeshProUGUI>().text = "Press [E] to store evidence " + other.name;
            }
            storeItemText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Evidence Item") && usingMagnifyingGlass)
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<ParticleSystem>().Stop();

            storeItemText.SetActive(false);

            evidenceItem = null;
        }
    }

    
}
