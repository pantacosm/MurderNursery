using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleInventory : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryUI;

    public bool inventoryOpen = false;


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
}
