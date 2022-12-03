using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField]
    Item item;

    private bool canPickUp;

    void PickUp()
    {
        InventoryManager.inventory.AddItem(item);
        Destroy(gameObject);

    }

    private void Update()
    {
        // once we are in range of an items trigger & press R, the item is added to the players inventory
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
