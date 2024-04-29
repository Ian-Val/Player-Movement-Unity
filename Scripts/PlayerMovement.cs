using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Vector2 playerInput;
    private bool isRunning;
    private bool isJump;
    private float movementSpeed;
    private Rigidbody rb;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;

    private void Awake() //Before first frame
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update() //Every single frame (5-300hz)
    {
        //Gets WASD Input
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");

        //Gets LEFTSHIFT Input
        if (isRunning)
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isRunning = false;
            }
        }
        else {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isRunning = true;
            }
        }
        
    }
    private void FixedUpdate() //Every physics update (60 hz)
    {
        //Sets movement speed based on Sprint Input
        if (isRunning)
        {
            movementSpeed = runSpeed;
        }
        else {
            movementSpeed = walkSpeed;
        }
        //Sets the direction we want to move in
        Vector3 movementVector = transform.forward * playerInput.y + transform.right * playerInput.x;
        //If the movementvector is greater 1 set it to be normalized (max length of 1)
        if (movementVector.magnitude > 1.0f) { 
            movementVector.Normalize();
        }
        //Finally, set the rb velocity to be the movement vector
        rb.velocity = movementVector * movementSpeed * Time.deltaTime + new Vector3(0, -9.7f, 0); //
    }
}
