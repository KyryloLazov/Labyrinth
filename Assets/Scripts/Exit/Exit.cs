using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour // Class to handle the exit mechanism for the player
{
    [SerializeField] int scrollNeeded = 2; // Number of scrolls required to win

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the player
        if (collision.transform.tag == "Player")
        {
            // Check if the player has collected the required number of scrolls
            if (collision.transform.GetComponent<PlayerInteraction>().CheckScrolls() == scrollNeeded)
            {
                // Show the win screen if the scroll requirement is met
                UIManager.Instance.ShowWinScreen();
            }
        }
    }
}
