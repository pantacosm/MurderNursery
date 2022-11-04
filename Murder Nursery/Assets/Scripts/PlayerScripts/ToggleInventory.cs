using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleInventory : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryUI;

    [SerializeField]
    GameObject pinboardUI;

    [HideInInspector]
    public bool inventoryOpen = false;

    [HideInInspector]
    public bool pinboardOpen = false;


    // Update is called once per frame
    void Update()
    {
        if(inventoryOpen == false && Input.GetKeyUp(KeyCode.B))
        {
            OpenInventory();
        }
        else if(inventoryOpen == true && Input.GetKeyUp(KeyCode.B))
        {
            CloseInventory();
        }

        if(Input.GetKeyUp(KeyCode.P))
        {
            TogglePinboard();
        }
    }

    public void OpenInventory()
    {
        inventoryUI.SetActive(true);
        inventoryOpen = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseInventory()
    {
        inventoryUI.SetActive(false);
        inventoryOpen = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void TogglePinboard()
    {
        if(pinboardOpen = !pinboardOpen)
        {
            pinboardUI.SetActive(true);
            pinboardOpen = true;
        }
        else
        {
            pinboardUI.SetActive(false);
            pinboardOpen = false;
        }
    }
}
