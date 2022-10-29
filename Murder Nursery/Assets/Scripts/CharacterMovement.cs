using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    PlayerControls playerControls;
    CharacterController controller;
    Animator animator;

    Vector2 movementInput;
    Vector3 movement;
    bool isMoving = false;
    bool isRunning = false;
    float velocity;
    
    [SerializeField]
    float acceleration = 0.3f;

    [SerializeField]
    float deceleration = 3.0f;

    [SerializeField]
    float speed = 3.0f;

    [SerializeField]
    float rotationSpeed = 15.0f;

    void Awake()
    {
        playerControls = new PlayerControls();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

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
        if(!isRunning)
        {
            movement.x = movementInput.x;
            movement.z = movementInput.y;
        }
        else if(isRunning)
        {
            movement.x = movementInput.x * speed;
            movement.z = movementInput.y * speed;
        }

        isMoving = movementInput.x != 0 || movementInput.y != 0;
    }

    void HandleAnimation()
    {
        //bool isWalking = animator.GetBool("isWalking");
        //bool isRunning = animator.GetBool("isRunning");

        //// set walking animation
        //if(isMoving && !isWalking)
        //{
        //    animator.SetBool("isWalking", true);
        //}
        //else if(!isMoving && isWalking)
        //{
        //    animator.SetBool("isWalking", false);
        //}

        //// set run animation
        //if(isMoving && !isRunning)
        //{
        //    animator.SetBool("isRunning", true);
        //}
        //else if(!isMoving && isRunning)
        //{
        //    animator.SetBool("isRunning", false);
        //}

        // blends between walk/run animations as velocity increases / decreases
        if(isMoving && velocity < 1.0f)
        {
            velocity += Time.deltaTime * acceleration;
            velocity = Mathf.Clamp(velocity, 0, 1);
        }
        if(!isMoving && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * deceleration;
            velocity = Mathf.Clamp(velocity, 0, 1);
        }

        if(velocity > 0.5f)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        animator.SetFloat("Velocity", velocity);
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
