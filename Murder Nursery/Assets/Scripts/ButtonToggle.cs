using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToggle : MonoBehaviour
{
    private bool menuOpen = false;
    public GameObject menu;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        menuOpen = !menuOpen;
        menu.SetActive(menuOpen);

    }
}
