using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakAndOpenDoor : SpeakScript
{
    [SerializeField]
    private GameObject scienceDevice;

    public override void interact()
    {
        base.interact();
        //Also delete outside doors
        GameObject[] outsideDoor = GameObject.FindGameObjectsWithTag("Outer Door");
        foreach (GameObject door in outsideDoor)
        {
            Destroy(door);
        }//End foreach
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().removeFromInventory(scienceDevice);
    }
}
