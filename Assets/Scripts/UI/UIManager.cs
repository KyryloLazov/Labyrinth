using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] Timer timer; // Reference to a Timer object that handles game time
    [SerializeField] ScrollCounter counter; // Reference to a ScrollCounter object that tracks collected scrolls
    [SerializeField] GameObject PauseMenu; // UI element for the pause menu
    [SerializeField] GameObject DeathScreen; // UI element for the death screen
    [SerializeField] GameObject WinScreen; // UI element for the win screen

    // Singleton instance of the UIManager
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            // Check if the instance is null and output an error if the UIManager is not assigned
            if (_instance == null)
            {
                Debug.LogError("UIManager is not present!");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this; // Assign this instance to the static _instance variable to create the Singleton
    }

    // Updates the scroll counter UI when a new scroll is collected
    public void UpdateScrolls(int scrolls)
    {
        counter.UpdateScrollsCount(scrolls); // Update the UI display with the current number of scrolls
    }

    // Displays the pause menu and unlocks the cursor
    public void ShowPauseMenu()
    {
        Cursor.lockState = CursorLockMode.None; // Unlocks the cursor for UI interaction
        PauseMenu.SetActive(true); // Show the pause menu
    }

    // Hides the pause menu and locks the cursor back to the game
    public void ExitPauseMenu()
    {
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor to the center of the screen for gameplay
        PauseMenu.SetActive(false); // Hide the pause menu
    }

    // Shows the death screen when the player dies and stops the timer
    public void ShowDeathScreen()
    {
        timer.StopTimer(); // Stops the in-game timer
        Cursor.lockState = CursorLockMode.None; // Unlocks the cursor for UI interaction
        DeathScreen.SetActive(true); // Show the death screen
    }

    // Shows the win screen when the player wins and stops the timer
    public void ShowWinScreen()
    {
        timer.StopTimer(); // Stops the in-game timer
        Cursor.lockState = CursorLockMode.None; // Unlocks the cursor for UI interaction
        WinScreen.SetActive(true); // Show the win screen
    }
}
