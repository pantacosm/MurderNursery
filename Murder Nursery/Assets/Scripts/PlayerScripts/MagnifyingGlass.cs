using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifyingGlass : MonoBehaviour
{
    public bool usingMagnifyingGlass;

    [SerializeField]
    GameObject thirdPersonCam;

    [SerializeField]
    GameObject magGlassCam; // first person camera

    [SerializeField]
    GameObject magGlassLens; // mag glass object


    // transitions between third person / first person camera &
    // toggles a magnifying lens to be used for finding evidence
    public void ToggleMagnifyingGlass() 
    {
        if(usingMagnifyingGlass = !usingMagnifyingGlass)
        {
            usingMagnifyingGlass = true;
            thirdPersonCam.SetActive(false);
            magGlassCam.SetActive(true);
            magGlassLens.SetActive(true);
            
        }
        else
        {
            usingMagnifyingGlass = false;
            magGlassCam.SetActive(false);
            magGlassLens.SetActive(false);
            thirdPersonCam.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Item") && usingMagnifyingGlass)
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            print("evidence");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Item") && usingMagnifyingGlass)
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
