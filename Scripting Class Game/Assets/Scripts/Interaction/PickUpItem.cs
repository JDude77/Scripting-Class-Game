using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : Interactive
{
    [SerializeField]
    private GameObject itemToPickUp;

    public override void interact()
    {
        base.interact();
        Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        inventory.addToInventory(itemToPickUp);
        Destroy(gameObject);
    }//End interact
}
