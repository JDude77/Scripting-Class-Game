using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplacePanel : Interactive
{
    [SerializeField]
    private GameObject replacementPanel;

    public override void interact()
    {
        base.interact();
        Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        inventory.removeFromInventory(replacementPanel);
        GameObject tempNewPanel = Instantiate(replacementPanel, gameObject.transform);
        tempNewPanel.transform.parent = null;
        Destroy(gameObject);
    }//End interact
}
