using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    
    private void Start()
    {
        // Hide the pause menu on start
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(isPaused) 
            {
                Debug.Log("game is resumed...");
                ResumeGame();
            }
            else
            {
                Debug.Log("game is paused...");
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        Debug.Log("Resuming game...");
        pauseMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void PauseGame()

    {
           Debug.Log("Pausing game...");
        pauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void LoadMainMenuScene()
    {
        Debug.Log("Loading Main Menu Scene SUCCESSFULLY PRESSED...");
        LapCounter.ResetLapCounter(); //Reset lap counter
        Time.timeScale = 1f; // Resume game before loading main menu
        SceneManager.LoadScene("CarSelection Scene"); // Replace "MainMenu" with the name of your main menu scene
        Debug.Log("Loading Main Menu Scene...");
    }
}