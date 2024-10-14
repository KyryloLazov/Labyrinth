using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed; // Walking speed of the player
    [SerializeField] private float sprintSpeed; // Sprinting speed of the player

    private float currentSpeed; // Current speed, either walk or sprint speed
    private Rigidbody rb; // Reference to the player's Rigidbody component
    private Vector3 MoveDirection; // Direction in which the player is moving
    private AudioSource audioSource; // Reference to the AudioSource for footstep sounds

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Initialize the Rigidbody component
        currentSpeed = walkSpeed; // Set the default movement speed to walking
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component for footstep sounds
    }

    void Update()
    {
        GetDirection(); // Calculate movement direction based on input
        Sprint(); // Check if the player is sprinting or walking
        PlaySound(); // Play or stop footstep sounds based on movement
    }

    // Get the player's movement direction based on input
    private void GetDirection()
    {
        float x = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or left/right arrow keys)
        float z = Input.GetAxis("Vertical"); // Get vertical input (W/S or up/down arrow keys)

        // Calculate the movement direction based on input
        MoveDirection = transform.right * x + transform.forward * z;
    }

    // Adjust the player's movement speed based on whether the sprint key (Left Shift) is held down
    private void Sprint()
    {
        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed; // Set speed to sprint if LeftShift is pressed, otherwise walk
    }

    // Play footstep sound when the player is moving, stop it when stationary
    private void PlaySound()
    {
        if (MoveDirection != Vector3.zero && !audioSource.isPlaying) // If moving and no sound is playing, start playing footstep sound
        {
            audioSource.Play();
        }
        else if (MoveDirection == Vector3.zero) // If not moving, stop the footstep sound
        {
            audioSource.Stop();
        }
    }

    // Update the player's position based on movement direction and current speed
    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Apply movement to the player's Rigidbody
    private void MovePlayer()
    {
        rb.MovePosition(rb.position + MoveDirection * currentSpeed * Time.deltaTime); // Move the player by calculating the new position
    }
}
