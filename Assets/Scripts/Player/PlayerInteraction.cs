using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private int scrollsPicked = 0; // Variable to track the number of scrolls picked by the player

    // Method to check the current number of scrolls picked
    public int CheckScrolls()
    {
        return scrollsPicked; // Return the number of scrolls collected
    }

    // Method to be called when a scroll is picked
    public void PickScroll()
    {
        scrollsPicked += 1; // Increment the scrolls picked count
        UIManager.Instance.UpdateScrolls(scrollsPicked); // Update the UI with the new scroll count
    }

    // Method to handle player death
    public void Death()
    {
        UIManager.Instance.ShowDeathScreen(); // Show the death screen via UIManager
    }
}
