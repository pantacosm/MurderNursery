using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MagnifyingGlass : MonoBehaviour
{
    public bool usingMagnifyingGlass;

    [SerializeField]
    GameObject thirdPersonCam;

    public GameObject magGlassCam; // first person camera

    [SerializeField]
    GameObject storeItemText; // text pop up to inform player they can pick up the evidence

    GameObject itemToDestroy; // destroy item when player picks it up

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && itemToDestroy)
        {
            Destroy(itemToDestroy);
            storeItemText.SetActive(false);
        }
    }

    // transitions between third person / first person camera &
    // toggles a magnifying lens to be used for finding evidence
    public void ToggleMagnifyingGlass() 
    {
        if(usingMagnifyingGlass = !usingMagnifyingGlass)
        {
            usingMagnifyingGlass = true;
            thirdPersonCam.SetActive(false);
            magGlassCam.SetActive(true);
            
        }
        else
        {
            usingMagnifyingGlass = false;
            magGlassCam.SetActive(false);
            thirdPersonCam.SetActive(true);
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

            itemToDestroy = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Evidence Item") && usingMagnifyingGlass)
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<ParticleSystem>().Stop();

            storeItemText.SetActive(false);
        }
    }

    
}
