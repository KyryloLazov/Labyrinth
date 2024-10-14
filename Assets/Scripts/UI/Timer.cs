using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component to display the timer
    private float timeElapsed; // Time elapsed since the timer started
    private bool isTiming; // Flag to check if the timer is currently running

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component attached to this GameObject
        timeElapsed = 0f; // Initialize the elapsed time to zero
        isTiming = true; // Start the timer by default
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the timer is running
        if (isTiming)
        {
            timeElapsed += Time.deltaTime; // Increment the elapsed time by the time since the last frame
            UpdateTimerDisplay(); // Update the timer display
        }
    }

    // Method to update the timer display
    void UpdateTimerDisplay()
    {
        // Calculate minutes and seconds from the elapsed time
        float minutes = Mathf.Floor(timeElapsed / 60); // Calculate total minutes
        float seconds = Mathf.Floor(timeElapsed % 60); // Calculate remaining seconds
        // Update the timer text with formatted minutes and seconds
        timerText.text = $"{minutes:00}:{seconds:00}"; // Format to always show two digits
    }

    // Method to stop the timer
    public void StopTimer()
    {
        isTiming = false; // Set the timing flag to false to stop the timer
    }

    // Method to start the timer
    public void StartTimer()
    {
        isTiming = true; // Set the timing flag to true to start the timer
    }
}
