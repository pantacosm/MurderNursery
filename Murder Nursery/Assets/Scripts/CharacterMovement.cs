using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    PlayerControls playerControls;
    CharacterController controller;
    Animator animator;

    int isWalkingHash;
    int isRunningHash;

    Vector2 movementInput;
    Vector3 movement;
    bool isMoving;

    [SerializeField]
    float runSpeed = 5.0f;

    [SerializeField]
    float rotationSpeed = 1.0f;

    void Awake()
    {
        playerControls = new PlayerControls();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

        // keyboard input pressed
        playerControls.PlayerInputMap.Move.started += OnMovementInput;

        // keyboard input released
        playerControls.PlayerInputMap.Move.canceled += OnMovementInput;

        // gamepad input
        playerControls.PlayerInputMap.Move.performed += OnMovementInput;
    }

    // Update is called once per frame
    void Update()
    {
        HandleAnimation();
        HandleRotation();
        HandleGravity();
        controller.Move(movement * Time.deltaTime);
    }

    void OnMovementInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        movement.x = movementInput.x * runSpeed;
        movement.z = movementInput.y * runSpeed;
        isMoving = movementInput.x != 0 || movementInput.y != 0;
    }

    void HandleAnimation()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);

        // set walking animation
        if(isMoving && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }
        else if(!isMoving && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }

        // set run animation
        if(isMoving && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        else if(!isMoving && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    void HandleRotation()
    {
        Vector3 lookAtPosition;
        // change in position the character should look at
        lookAtPosition.x = movement.x;
        lookAtPosition.y = 0;
        lookAtPosition.z = movement.z;

        // characters current rotation;
        Quaternion rotation = transform.rotation;

        if(isMoving)
        {
            // new rotation based on characters current movement direction (input being pressed)
            Quaternion targetRotation = Quaternion.LookRotation(lookAtPosition);
            transform.rotation = Quaternion.Slerp(rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void HandleGravity()
    {
        if(controller.isGrounded)
        {
            float groundedGravity = -0.5f;
            movement.y = groundedGravity;
        }
        else
        {
            float gravity = -9.8f;
            movement.y += gravity;
        }
    }

    private void OnEnable()
    {
        playerControls.PlayerInputMap.Enable();
    }

    private void OnDisable()
    {
        playerControls.PlayerInputMap.Disable();
    }
}
