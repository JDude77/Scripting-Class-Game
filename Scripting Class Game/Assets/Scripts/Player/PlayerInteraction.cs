using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    #region Attributes
    private GameObject player;
    private Camera playerCam;
    [SerializeField]
    private GameObject other;
    private float interactRange;
    private int interactLayer;
    [SerializeField]
    private Material interactibleMaterial;
    [SerializeField]
    private Material nonInteractibleMaterial;
    #endregion

    #region Getters & Setters
    //Player Getter
    public GameObject getPlayer()
    {
        return player;
    }//End player getter
    //Player Setter
    public void setPlayer(GameObject player)
    {
        this.player = player;
    }//End player setter
    
    //Other Interactible Getter
    public GameObject getOther()
    {
        return other;
    }//End other interactible getter
    //Other Interactible Setter
    public void setOther(GameObject other)
    {
        this.other = other;
    }//End other interactible setter

    //Interaction Range Getter
    public float getInteractRange()
    {
        return interactRange;
    }//End interaction range getter
    //Interaction Range Setter
    public void setInteractRange(float interactRange)
    {
        this.interactRange = interactRange;
    }//End interaction range setter

    //Interaction Layer Getter
    public int getInteractionLayer()
    {
        return interactLayer;
    }//End interaction layer getter
    //Interaction Layer Setter
    public void setInteractionLayer(int interactLayer)
    {
        this.interactLayer = interactLayer;
    }//End interaction layer setter
    #endregion

    //Initialise variables on player start
    private void Start()
    {
        //Set the player to whatever is currently set as the player
        player = GameObject.FindGameObjectWithTag("Player");
        //Find camera
        playerCam = FindObjectOfType<Camera>();
        //Set the interaction range to a test value of ten
        interactRange = 1.5f;
        //Set the interaction layer to... the interaction layer
        interactLayer = LayerMask.GetMask("Interactible");
    }//End Start

    //Check for interaction
    private void Update()
    {
        //Send out raycast in direction of player forward
        Ray interact = new Ray(playerCam.transform.position, playerCam.transform.forward);
        Debug.DrawRay(interact.origin, interact.direction * interactRange, Color.red);
        //If the raycast hits an interactible
        if (Physics.Raycast(interact, out RaycastHit hitInfo, interactRange, interactLayer))
        {
            //Set other to the object being hit
            other = hitInfo.transform.gameObject;
            //Change material as indication of hit
            other.GetComponent<MeshRenderer>().material = interactibleMaterial;
        }//End if
        //If the raycast doesn't hit an interactible
        else
        {
            if(other != null)
            {
                other.GetComponent<MeshRenderer>().material = nonInteractibleMaterial;
                other = null;
            }
        }//End else
    }//End Update
}