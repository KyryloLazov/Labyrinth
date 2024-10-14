using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float arrowSpeed; // Speed at which the arrow will travel

    void Update()
    {
        // Move the arrow forward at the specified speed
        transform.Translate(Vector3.forward * arrowSpeed * Time.deltaTime);

        // Destroy the arrow object after 3 seconds to prevent memory leaks
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroy the arrow when it collides with any object
        Destroy(gameObject);
    }
}
