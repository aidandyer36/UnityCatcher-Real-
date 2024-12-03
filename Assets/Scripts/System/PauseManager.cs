using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PauseManager : MonoBehaviour
{
    public static bool paused = false;
    public GameObject menu;


    PauseAction action;

    private void Awake()
    {
        action = new PauseAction();
        menu.SetActive(false);
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        action.Pause.PauseGame.performed += _ => DeterminePause();
    }

    void Update()
    {
        if (menu.activeSelf && action.Pause.ExitGame.triggered)
        {
            Debug.Log("Pressed Exit");
            SceneManager.LoadScene(0);
        }
    }
    private void DeterminePause()
    {
        if (paused)
            ResumeGame();
        else
            PauseGame();
    }
    public void PauseGame() 
    {
        Time.timeScale = 0;
        paused = true;
        menu.SetActive(true);
    }

    public void ResumeGame() 
    {
        Time.timeScale = 1;
        paused = false;
        menu.SetActive(false);
    }
}
