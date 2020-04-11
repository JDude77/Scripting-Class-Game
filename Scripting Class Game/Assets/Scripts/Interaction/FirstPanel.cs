using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPanel : Interactive
{
    // Start is called before the first frame update
    protected override void Start()
    {
        isInteractive = true;
    }//End Start

    public override void interact()
    {
        base.interact();
        gameObject.GetComponent<Explode>().explode();
    }
}
