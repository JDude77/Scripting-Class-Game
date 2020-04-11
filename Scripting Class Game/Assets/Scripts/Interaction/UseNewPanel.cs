using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseNewPanel : Interactive
{
    public override void interact()
    {
        base.interact();
        GameObject[] innerDoors = GameObject.FindGameObjectsWithTag("Inner Door");
        foreach(GameObject door in innerDoors)
        {
            door.GetComponent<Animator>().SetBool("Door Opened", true);
        }//End foreach
    }//End interact
}
