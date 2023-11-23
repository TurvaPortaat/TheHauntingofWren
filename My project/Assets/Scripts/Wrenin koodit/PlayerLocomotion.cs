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
        Debug.Log("Handling all movement...");
        HandleMovement();
        HandleRotation();
    }

    public void HandleMovement()
    {
        Debug.Log("Handling movement...");
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
        Debug.Log("Handling rotation...");
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward*inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;
        
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed*Time.deltaTime);

        transform.rotation = playerRotation;
    }
}