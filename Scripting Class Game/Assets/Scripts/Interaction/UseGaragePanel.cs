using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseGaragePanel : Interactive
{
    public override void interact()
    {
        base.interact();
        GameObject garageDoor = GameObject.FindGameObjectWithTag("Garage Door");
        Destroy(garageDoor);
    }
}
