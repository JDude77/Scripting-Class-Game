using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Attributes
    private UIScript ui;
    private int slots, usedSlots;
    [SerializeField]
    private List<GameObject> inventory;
    #endregion

    //Start is called before the first frame update
    private void Start()
    {
        ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UIScript>();
        slots = 1;        
        inventory = new List<GameObject>();
        usedSlots = inventory.Count;
    }//End Start

    public void addToInventory(GameObject objectToAdd)
    {
        if(usedSlots < slots)
        {
            inventory.Add(objectToAdd);
            usedSlots = inventory.Count;
            ui.setInventoryText(inventory);
        }//End if
    }//End addToInventory

    public void removeFromInventory(GameObject objectToRemove)
    {
        if(usedSlots != 0)
        {
            if(inventory.Contains(objectToRemove))
            {
                inventory.Remove(objectToRemove);
                usedSlots = inventory.Count;
                ui.setInventoryText(inventory);
            }//End if
        }//End if
    }//End removeFromInventory
}
