using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifyingGlass : MonoBehaviour
{
    public bool usingMagnifyingGlass;

    [SerializeField]
    GameObject thirdPersonCam;

    [SerializeField]
    GameObject magGlassCam;

    [SerializeField]
    GameObject magGlassLens;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.M))
        {
            ToggleMagnifyingGlass();
        }
    }

    public void ToggleMagnifyingGlass()
    {
        if(usingMagnifyingGlass = !usingMagnifyingGlass)
        {
            usingMagnifyingGlass = true;
            thirdPersonCam.SetActive(false);
            magGlassCam.SetActive(true);
            if(magGlassCam.activeInHierarchy)
            {
                magGlassLens.SetActive(true);
            }
        }
        else
        {
            usingMagnifyingGlass = false;
            magGlassCam.SetActive(false);
            magGlassLens.SetActive(false);
            thirdPersonCam.SetActive(true);
        }
    }
}
