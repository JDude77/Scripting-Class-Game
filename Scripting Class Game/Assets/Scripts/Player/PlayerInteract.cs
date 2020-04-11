using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    #region Attributes
    private GameObject playerObject;
    private Camera playerCamera;
    private float interactionRange;
    private int interactionLayer;
    [SerializeField]
    private GameObject other;
    private QuestStages questStageScript;
    #endregion

    //Start is called before the first frame update
    private void Start()
    {
        questStageScript = GameObject.FindGameObjectWithTag("Quest Tracker").GetComponent<QuestStages>();
        playerObject = gameObject;
        playerCamera = playerObject.transform.GetComponentInChildren<Camera>();
        interactionRange = 2f;
        interactionLayer = LayerMask.GetMask("Interactible");
    }//End Start

    //Update is called once per frame
    private void Update()
    {
        Ray interact = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward);
        setHUDText(null);

        if (Physics.Raycast(interact, out RaycastHit hitInfo, interactionRange, interactionLayer))
        {
            other = hitInfo.transform.gameObject;
            if (other.GetComponent<Interactive>().getIsInteractive())
            {
                setHUDText(other);
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    other.GetComponent<Interactive>().interact();
                    questStageScript.nextQuestStage();
                }//End if
            }//End if
        }//End if
        else
        {
            other = null;
        }//End else
    }//End Update

    private void setHUDText(GameObject other)
    {
        UIScript ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UIScript>();
        if(other != null)
        {
            ui.setText(other.GetComponent<Interactive>().getHUDText());
            if(ui.getReticle().color != new Color(0.9f, 0.9f, 0.9f, 0.75f))
            {
                ui.setReticleMode(true);
            }
        }//End else
        else
        {
            ui.setText("");
            if(ui.getReticle().color != new Color(0.9f, 0.9f, 0.9f, 0.25f))
            {
                ui.setReticleMode(false);
            }//End if
        }//End else
    }//End setHUDText
}