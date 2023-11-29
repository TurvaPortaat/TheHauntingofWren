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
        //Debug.Log("Handling movement...");
        moveDirection = cameraObject.forward* inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right* inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection* movementSpeed;

        Vector3 movementVelocity = moveDirection;
        playerRigidbody.velocity = movementVelocity; 
    }

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
