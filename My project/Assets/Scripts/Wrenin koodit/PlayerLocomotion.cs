using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;

    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidbody;

    public float movementSpeed = 7;
    public float rotationSpeed = 15;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        //playerRigidbody = GetComponentInChildren<Rigidbody>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    public void HandleAllMovement()
    {
        //Debug.Log("Handling all movement...");
        HandleMovement();
        HandleRotation();
    }

    public void HandleMovement()
    {
        // Calculate the move direction based on camera input
        Vector3 cameraForward = cameraObject.forward;
        Vector3 cameraRight = cameraObject.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        moveDirection = cameraForward * inputManager.verticalInput + cameraRight * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;

        // Apply movement only if there is input
        if (moveDirection != Vector3.zero)
        {
            // Rotate the player to face the move direction
            Quaternion rotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            // Move the player
            Vector3 movementVelocity = moveDirection * movementSpeed;
            playerRigidbody.velocity = new Vector3(movementVelocity.x, playerRigidbody.velocity.y, movementVelocity.z);
        }
        else
        {
            // If there is no input, stop the player
            playerRigidbody.velocity = Vector3.zero;
        }
    }
    /*public void HandleMovement()
    {
        
        moveDirection = cameraObject.forward* inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right* inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection* movementSpeed;

        Vector3 movementVelocity = moveDirection;
        playerRigidbody.velocity = movementVelocity;

        //Debug.Log("Player movement velocity: " + movementVelocity); - ei ollu tää
    }*/

    /*public void HandleRotation()
    {
        //Debug.Log("Handling rotation...");
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward*inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            transform.rotation = playerRotation;
        }
    }*/
    public void HandleRotation()
    {
        // Check if there is any movement (non-zero velocity)
        if (playerRigidbody.velocity.magnitude > 0.1f)
        {
            // Get the direction of movement from the velocity
            Vector3 targetDirection = playerRigidbody.velocity.normalized;

            // Only rotate if there is significant movement
            if (targetDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
                Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                transform.rotation = playerRotation;
            }
        }
    }
}
