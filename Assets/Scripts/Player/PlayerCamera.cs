using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f; // Sensitivity for mouse movement
    [SerializeField] private Transform playerBody; // Reference to the player's body transform for rotation

    private float xRotation = 0f; // Variable to track vertical camera rotation

    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input and apply sensitivity and delta time
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Update vertical rotation based on mouse Y input
        xRotation -= mouseY;
        // Clamp the rotation to prevent flipping
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply the rotation to the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // Rotate the player's body based on mouse X input
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
