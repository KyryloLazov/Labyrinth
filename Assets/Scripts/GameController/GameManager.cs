using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false; // Flag to check if the game is currently paused

    void Update()
    {
        // Check for Escape key input to toggle pause/resume
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame(); // Resume game if it is currently paused
            else
                PauseGame(); // Pause game if it is currently running
        }
    }

    private void PauseGame()
    {
        isPaused = true; // Set the paused flag to true
        Time.timeScale = 0f; // Stop the game time
        UIManager.Instance.ShowPauseMenu(); // Show the pause menu
    }

    public void ResumeGame()
    {
        isPaused = false; // Set the paused flag to false
        Time.timeScale = 1f; // Resume the game time
        UIManager.Instance.ExitPauseMenu(); // Hide the pause menu
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Ensure game time is running before restarting
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void ExitGame()
    {
        // Exit the game application
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode if in the Unity editor
#endif
    }
}
