using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;

    private bool canPickUp;

    void PickUp()
    {
        InventoryManager.inventory.AddItem(item);
        Destroy(gameObject);

    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.R) && canPickUp)
        {
            PickUp();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canPickUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canPickUp = false;
        }
    }
}
