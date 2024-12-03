using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using Ink.Runtime;
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour, IDataPersistence
{


    private PlayerControls playerControls;

    private Rigidbody2D rb;

    [SerializeField] private float speed, sprintSpeed, walkSpeed;
    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;
    public GameObject pausemenu; //new//
    public GameObject mapmenu; //new//
    public GameObject controlmenu; //new//
    public GameObject inventorymenu; //new//

    private Collider2D col;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    private Vector2 input;
    
    private bool isMoving;



    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Start()
    {
        playerControls.Travel.Sprint.performed += _ => Sprint(); //new//
        playerControls.Travel.Sprint.canceled += _ => SprintEnd(); //new//
        rb = GetComponent<Rigidbody2D>(); //new//
        transform.position = Vector3.zero;
    }

    private void Sprint() //new//
    {
        Vector2 movementInput = playerControls.Travel.Move.ReadValue<Vector2>(); // Read as Vector2
        if (movementInput.magnitude > 0) // Check if there is any movement
        {
            speed = sprintSpeed; //speed change//
        }
        else
        {
            speed = walkSpeed;
        }
    }

    private void SprintEnd() // Updated SprintEnd method
    {
        Vector2 movementInput = playerControls.Travel.Move.ReadValue<Vector2>(); // Read as Vector2
        if (movementInput.magnitude == 0) // Check if there is no movement
        {
            speed = walkSpeed; // Set to walk speed when not moving
        }
        else
        {
            speed = sprintSpeed; // Keep sprint speed if moving
        }
    }


    private void Update()
    {
        if (playerControls.Travel.Interact1.triggered)
        {
  
            Debug.Log("Interact1");
        }
        if (playerControls.Travel.Interact2.triggered)
        {
     
            Debug.Log("Interact2");
        }
        if (playerControls.Travel.Interact3.triggered)
        {
          
            Debug.Log("Interact3");
        }
        if (playerControls.Travel.Interact4.triggered)
        {
            Debug.Log("Interact4");
        }
        if (playerControls.Travel.Sprint.triggered)
        {
            Debug.Log("Sprinting");
        }
        if (playerControls.Travel.Interact5.triggered)
        {
            Debug.Log("Interact5");
        }



        if (PauseManager.paused) return;

        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        if (rb.constraints != RigidbodyConstraints2D.FreezePosition)
        {
            Move();
        }

    }

    private void Move()
    {
        if(!isMoving){
            Vector2 movementInput = playerControls.Travel.Move.ReadValue<Vector2>();

            Vector3 currentPosition = transform.position;
            Vector3 targetpos = transform.position;
            if(movementInput.x != 0) movementInput.y = 0;
            targetpos.x += movementInput.x;
            targetpos.y += movementInput.y; // Update Y position
            if(isWalkable(targetpos)){
                StartCoroutine(Movement(targetpos));
            }
         transform.position = currentPosition;
        
            if(movementInput != Vector2.zero){
                animator.SetFloat("moveX", movementInput.x);
                animator.SetFloat("moveY", movementInput.y);
            }
            // Animation
            if (movementInput.x != 0 || movementInput.y != 0)
                animator.SetBool("isMoving", true);
            else
                animator.SetBool("isMoving", false);

        }
        // Read the movement input as a Vector2
       
        
    }

    IEnumerator Movement(Vector3 targetpos)
    {
        isMoving = true;
        while((targetpos - transform.position).sqrMagnitude > Mathf.Epsilon){
            transform.position = Vector3.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetpos;

        isMoving = false;
    }
    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(GameData data)
    {
        data.playerPosition = this.transform.position;
    }

    private void OnDisable()
    {
        playerControls.Disable();

    }

    private bool isWalkable(Vector3 targetpos)
    {
        if(Physics2D.OverlapCircle(targetpos, 0.2f, solidObjectsLayer | interactableLayer) != null)
        {
            return false;
        }
        return true;
    }
}
