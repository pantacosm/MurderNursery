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
    public GameObject blur;
    public GameObject interrogationManager;
    public GameObject interrogationUI;

    public void Update()
    {
        if (inventoryOpen)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    // booleans used to determines if UI elements are visible - if so, hide them & vise versa
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
            Cursor.visible=false;            
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

    public void TogglePinboard() // Called when pinboard item clicked from inventory or when X clicked on pinboard
    {
        if (!interrogationManager.GetComponent<Interrogation>().inInterrogation)
        {
            if (pinboardOpen = !pinboardOpen)
            {
                playerAudioSource.PlayOneShot(openPinBoardSound, 0.5f);
                pinboardUI.SetActive(true);
                blur.SetActive(true);
                pinboardOpen = true;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                pinboardUI.SetActive(false);
                blur.SetActive(false);
                pinboardOpen = false;
                Cursor.visible = false;



            }

            if (inventoryOpen)
            {
                inventoryUI.SetActive(false);
                inventoryOpen = false;
            }
        }
        if(interrogationManager.GetComponent<Interrogation>().inInterrogation)
        {
            pinboardUI.SetActive(false);
            pinboardOpen = false;
            interrogationUI.SetActive(true);
        }
    }

    public void ToggleJotter() // Called when jotter item clicked from inventory or when X clicked on jotter
    {
        if(jotterOpen = !jotterOpen)
        {
            playerAudioSource.PlayOneShot(openJotterSound, 0.5f);
            jotterUI.SetActive(true);
            blur.SetActive(true);
            jotterOpen = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            jotterUI.SetActive(false);
            blur.SetActive(false);
            jotterOpen = false;
            Cursor.visible = false;            
        }

        if(inventoryOpen)
        {
            inventoryUI.SetActive(false);
            inventoryOpen = false;
        }
    }
}
