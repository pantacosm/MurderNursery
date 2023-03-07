using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MagnifyingGlass : MonoBehaviour
{
    PinboardManager PM;

    public bool usingMagnifyingGlass;

    [SerializeField]
    GameObject magnifyingBlur; // activates a blur effect whilst using the MG

    [SerializeField]
    GameObject thirdPersonCam;

    public GameObject magGlassCam; // first person camera

    [SerializeField]
    GameObject storeItemText; // text pop up to inform player they can pick up the evidence

    GameObject evidenceItem; // item the player is currently viewing through the magnifying glass

    private void Start()
    {
        PM = FindObjectOfType<PinboardManager>();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && evidenceItem)
        {
            GameObject evidenceUI = evidenceItem.GetComponent<EvidenceItem>().evidenceToAdd; // evidence to add to pinboard

            if(!evidenceUI.GetComponent<EvidenceClass>().evidenceFound) // check the evidence hasnt already been found
            {
                // update the pinboard with new evidence
                PM.discoveredEvidence.Add(evidenceUI.GetComponent<EvidenceClass>());
                PM.UpdateEvidenceImages(evidenceUI.GetComponent<EvidenceClass>());
                evidenceUI.GetComponent<EvidenceClass>().evidenceFound = true;
            }

            storeItemText.SetActive(false);
            Destroy(evidenceItem);
        }
    }

    // transitions between third person / first person camera &
    // toggles a magnifying glass to be used for finding evidence
    public void ToggleMagnifyingGlass() 
    {
        if(usingMagnifyingGlass = !usingMagnifyingGlass)
        {
            usingMagnifyingGlass = true;
            thirdPersonCam.SetActive(false);
            magGlassCam.SetActive(true);
            magnifyingBlur.SetActive(true);
            
        }
        else
        {
            usingMagnifyingGlass = false;
            magGlassCam.SetActive(false);
            thirdPersonCam.SetActive(true);
            magnifyingBlur.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Evidence Item") && usingMagnifyingGlass)
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = true; // allows player to see the item
            other.gameObject.GetComponent<ParticleSystem>().Play(); // plays the particle effect attached to item

            storeItemText.GetComponent<TextMeshProUGUI>().text = "Press [E] to store evidence " + other.name;
            storeItemText.SetActive(true);

            evidenceItem = other.gameObject;
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
