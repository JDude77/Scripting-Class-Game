using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    #region Attributes
    [SerializeField]
    private GameObject uiObject, textObject, reticleObject;
    [SerializeField]
    private Text text, inventoryText;
    private Image reticle;
    private bool reticleMode;
    #endregion

    #region Getters & Setters

    public GameObject getUIObject()
    {
        return uiObject;
    }//End UI Object Getter

    public GameObject getTextObject()
    {
        return textObject;
    }//End Text Object Getter

    public GameObject getReticleObject()
    {
        return reticleObject;
    }//End Reticle Object Getter

    public Text getText()
    {
        return text;
    }//End Text Getter

    public void setInventoryText(List<GameObject> inventory)
    {
        inventoryText.text = "Inventory:";
        if (inventory.Count != 0)
        {
            foreach (GameObject obj in inventory)
            {
                inventoryText.text += " " + obj.name;
            }//End foreach
        }//End if
        else
        {
            inventoryText.text += " Empty";
        }//End else
    }//End Inventory Text Setter

    public Image getReticle()
    {
        return reticle;
    }//End Reticle Getter

    public void setText(string text)
    {
        this.text.text = text;
    }//End Text Setter
    #endregion

    #region Behaviours
    private void Start()
    {
        uiObject = GameObject.FindGameObjectWithTag("UI");
        text = uiObject.GetComponentInChildren<Text>();
        textObject = text.gameObject;
        reticle = uiObject.GetComponentInChildren<Image>();
        reticleObject = reticle.gameObject;
        inventoryText = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Text>();
        setInventoryText(new List<GameObject>());
        reticleMode = false;
    }//End Start

    private void Update()
    {
        if(reticleMode)
        {
            reticle.color = Color.Lerp(reticle.color, new Color(0.9f, 0.9f, 0.9f, 0.75f), 0.1f);
        }//End if
        else
        {
            reticle.color = Color.Lerp(reticle.color, new Color(0.9f, 0.9f, 0.9f, 0.25f), 0.1f);
        }//End else
    }//End Update

    public void setReticleMode(bool highlight)
    {
        reticleMode = highlight;
    }//End setReticleMode
    #endregion
}
