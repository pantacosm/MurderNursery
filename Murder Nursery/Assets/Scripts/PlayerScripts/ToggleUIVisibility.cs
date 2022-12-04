using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// attached to inventory manager object (called any time we want to update ui visibility)
public class ToggleUIVisibility : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryUI;

    [SerializeField]
    GameObject jotterUI;

    [SerializeField]
    public GameObject pinboardUI;

    [SerializeField]
    GameObject evidenceJotter;

    [HideInInspector]
    public bool inventoryOpen = false;

    [HideInInspector]
    public bool pinboardOpen = false;

    [HideInInspector]
    public bool jotterOpen = false;

    public AudioSource playerAudioSource;
    public AudioClip openInventorySound;
    public AudioClip openPinBoardSound;
    public AudioClip openJotterSound;

    public void ToggleInventory()
    {
        if(inventoryOpen = !inventoryOpen)
        {
            playerAudioSource.PlayOneShot(openInventorySound, 0.2f) ;
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
            evidenceJotter.SetActive(false);
            pinboardOpen = false;
        }

        if(jotterOpen)
        {
            jotterUI.SetActive(false);
            jotterOpen = false;
        }
    }

    public void TogglePinboard()
    {
        if(pinboardOpen = !pinboardOpen)
        {
            playerAudioSource.PlayOneShot(openPinBoardSound, 0.5f);
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

    public void ToggleJotter()
    {
        if(jotterOpen = !jotterOpen)
        {
            playerAudioSource.PlayOneShot(openJotterSound, 0.5f);
            jotterUI.SetActive(true);
            jotterOpen = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            jotterUI.SetActive(false);
            jotterOpen = false;

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
