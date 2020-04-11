using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeakScript : Interactive
{
    [SerializeField]
    protected string speech;
    [SerializeField]
    protected GameObject speechObject;

    public override void interact()
    {
        base.interact();
        speechObject = Instantiate(speechObject, transform);
        //speechObject.transform.parent = null;
        speechObject.transform.position = new Vector3(transform.position.x, transform.position.y + 6, transform.position.z);
        speechObject.transform.localScale = new Vector3(1f, 1f, 1f);
        speechObject.GetComponentInChildren<TextMeshProUGUI>().text = speech;
    }//End Interact
    protected override void Update()
    {
        base.Update();
        if(stages.getCurrentStage() == questStageForUse + 1)
        {
            speechObject.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.position);
        }//End if
        else if(stages.getCurrentStage() > questStageForUse + 1)
        {
            Destroy(speechObject);
            Destroy(this);
        }//End else if
    }//End Update
}
