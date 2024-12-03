using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Ink.Runtime;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;



    private PlayerControls playerControls;
    [SerializeField] PlayerController player;
    private bool playerInRange;
    
  

private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        playerControls = new PlayerControls();
   
    }
 

    private void OnEnable()
    {
        playerControls.Enable();

    }

    private void Update()
    {
        playerInRange = player.interactable;
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
          visualCue.SetActive(true);
          if (playerControls.Travel.Interact1.triggered)
           {
              DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
           }
        }
        else
        {
            visualCue.SetActive(false);
        }

    }
  
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}