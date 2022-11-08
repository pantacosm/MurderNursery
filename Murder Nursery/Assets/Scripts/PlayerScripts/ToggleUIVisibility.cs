using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleUIVisibility : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryUI;

    [SerializeField]
    public GameObject pinboardUI;

    [HideInInspector]
    public bool inventoryOpen = false;

    [HideInInspector]
    public bool pinboardOpen = false;

    public void ToggleInventory()
    {
        if(inventoryOpen = !inventoryOpen)
        {
            inventoryUI.SetActive(true);
            inventoryOpen = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            inventoryUI.SetActive(false);
            inventoryOpen = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if(pinboardOpen)
        {
            pinboardUI.SetActive(false);
            pinboardOpen = false;
        }
    }

    public void TogglePinboard()
    {
        if(pinboardOpen = !pinboardOpen)
        {
            pinboardUI.SetActive(true);
            pinboardOpen = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            pinboardUI.SetActive(false);
            pinboardOpen = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if(inventoryOpen)
        {
            inventoryUI.SetActive(false);
            inventoryOpen = false;
        }
    }
}
