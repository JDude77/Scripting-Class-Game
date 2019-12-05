using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Attributes
    private CharacterController controller;
    private float playerSpeed = 6f;
    private Vector3 velocity;
    private float gravity = -9.81f;
    private Transform groundCheck;
    private float groundDistance = 0.2f;
    private LayerMask groundMask;
    private bool isGrounded;
    #endregion

    #region Getters & Setters
    #region Controller
    public CharacterController getController()
    {
        return controller;
    }//End controller getter
    public void setController(CharacterController newController)
    {
        controller = newController;
    }//End controller setter
    #endregion
    #region Player Speed
    //Getter
    public float getPlayerSpeed()
    {
        return playerSpeed;
    }//End player speed getter
    //Setter
    public void setPlayerSpeed(float newPlayerSpeed)
    {
        playerSpeed = newPlayerSpeed;
    }//End player speed setter
    #endregion
    #endregion
    //Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        groundCheck = transform.Find("GroundCheck").transform;
        groundMask = LayerMask.GetMask("Ground");
    }//End Start

    //Update is called once per frame
    private void Update()
    {
        handleGravity();
        doMovement();
    }//End Update

    #region Behaviours
    //Make the player fall
    private void handleGravity()
    {
        //Check that the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //If the player is grounded and the gravity is still increasing
        if (isGrounded && velocity.y < 0)
        {
            //Stop the player falling so quickly
            velocity.y = -1f;
        }//End if
    }//End handleGravity

    private void doMovement()
    {
        //Get player movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Calculate the direction of horizontal movement that the player should be doing
        Vector3 directionOfMovement = transform.right * x + transform.forward * z;

        //Apply horizontal movement according to player speed and framerate
        controller.Move(directionOfMovement * playerSpeed * Time.deltaTime);

        //Adjust velocity according to gravity and framerate
        velocity.y += gravity * Time.deltaTime;

        //Apply vertical movement according to framerate
        controller.Move(velocity * Time.deltaTime);
    }//End doMovement

    #endregion
}
