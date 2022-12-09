using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private PlayerControls playerControls;
    private Animator animator;
    private InventoryManager inventory;

    [HideInInspector]
    public GameObject manager;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;
    private Vector3 movement;
    private Vector2 movementInput;
    private bool isMoving;
    private float velocity;
    public GameObject dressUpManager;


    [SerializeField]
    private float playerSpeed = 4.0f;

    [SerializeField]
    private float acceleration = 2.0f;

    [SerializeField]
    private float deceleration = 3.0f;

    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private GameObject dialogueZone;

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        inventory = FindObjectOfType<InventoryManager>();
        cameraTransform = Camera.main.transform;

        // holds a map of inputs for the player
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
    }

    void Update()
    {
        isMoving = movement != Vector3.zero;

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (isMoving)
        {
            gameObject.transform.forward = movement;
        }

        // stops player movement & disables camera whilst UI open
        if (inventory.UIVisibility.inventoryOpen || inventory.UIVisibility.pinboardOpen 
            || dialogueZone.activeInHierarchy || manager.GetComponent<SceneTransition>().interrogationActive 
            || inventory.UIVisibility.jotterOpen || dressUpManager.GetComponent<DressUp>().inDressUp)
        {
            animator.Play("Idle");
            animator.SetFloat("Velocity", 0);

            GameObject.FindGameObjectWithTag("Camera").GetComponent<Cinemachine.CinemachineInputProvider>().enabled = false;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Camera").GetComponent<Cinemachine.CinemachineInputProvider>().enabled = true;
            HandleMovement();
        }

        HandleAnimation();
    }

    // Called when we want the player to be able to move (character moves forward in direction camera is facing)
    void HandleMovement()
    {
        movementInput = playerControls.PlayerInputMap.Move.ReadValue<Vector2>();
        movement = new Vector3(movementInput.x, 0, movementInput.y);
        movement = cameraTransform.forward * movement.z + cameraTransform.transform.right * movement.x;
        movement.y = 0;

        controller.Move(movement * Time.deltaTime * playerSpeed);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void HandleAnimation()
    {
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

        animator.SetFloat("Velocity", velocity);
    }

    // enables / disables input system
    private void OnEnable()
    {
        playerControls.PlayerInputMap.Enable();
    }

    private void OnDisable()
    {
        playerControls.PlayerInputMap.Disable();
    }

    // hide mouse cursor when player is focus
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            //Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
