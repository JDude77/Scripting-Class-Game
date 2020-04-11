using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    #region Attributes
    private float mouseSensitivity = 100f;
    private Transform playerBody;
    private float xRotation = 0f;
    private GameObject player;
    #endregion

    #region Getters & Setters
    #region Mouse Sensitivity
    //Getter
    public float getMouseSensitivity()
    {
        return mouseSensitivity;
    }//End mouse sensitivity getter
    
    //Setter
    public void setMouseSensitivity(float newMouseSensitivity)
    {
        mouseSensitivity = newMouseSensitivity;
    }//End mouse sensitivity setter
    #endregion
    #region Player Body
    //Getter
    public Transform getPlayerBody()
    {
        return playerBody;
    }//End player body getter
    //Setter
    public void setPlayerBody(Transform newPlayerBody)
    {
        playerBody = newPlayerBody;
    }//End player body setter
    #endregion
    #endregion

    //Start is called before the first frame update
    private void Start()
    {
        playerBody = GetComponentInParent<CharacterController>().transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player = playerBody.gameObject;
    }//End Start

    // Update is called once per frame
    private void Update()
    {
            //Get movement of mouse according to mouse sensitivity and make sure it's the same across framerate
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            rotatePlayerHorizontal(mouseX);
            rotateCameraVertical(mouseY);
    }//End Update

    #region Behaviours
    //Handle player left and right rotation
    private void rotatePlayerHorizontal(float mouseX)
    {
        //REMEMBER TO CHANGE TO ALLOW INVERTED X CONTROL
        playerBody.Rotate(Vector3.up * mouseX);
    }//End rotatePlayerHorizontal

    //Handle camera up and down tilting
    private void rotateCameraVertical(float mouseY)
    {
        //REMEMBER TO CHANGE TO ALLOW INVERTED Y CONTROL
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }//End rotateCameraVertical
    #endregion
}
