using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;



    private PlayerControls playerControls;
    private bool playerInRange;
    Scene currentScene;
    
  

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
        
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
          visualCue.SetActive(true);
            if(this.tag == "Introduction")
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON, true);
            }
          if (playerControls.Travel.Interact1.triggered)
           {
              DialogueManager.GetInstance().EnterDialogueMode(inkJSON, false);
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