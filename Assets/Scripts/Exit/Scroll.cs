using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private AudioSource audioSource; // Reference to the AudioSource component for playing sound

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to the object
    }

    // Called when another object with a Collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered is tagged as "Player"
        if (other.tag == "Player")
        {
            audioSource.Play(); // Play the scroll pick-up sound
            other.GetComponent<PlayerInteraction>().PickScroll(); // Call the PickScroll function from the PlayerInteraction script
            Destroy(gameObject, 1f); // Destroy the scroll object after being picked up
        }
    }
}
