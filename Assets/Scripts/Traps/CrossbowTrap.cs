using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowTrap : MonoBehaviour, ITriggerable
{
    [SerializeField] private GameObject arrowPrefab; // Reference to the arrow prefab
    [SerializeField] private Transform spawnPoint; // Position where arrows will be spawned
    [SerializeField] private float delayBetweenShots; // Delay between consecutive shots
    [SerializeField] private int arrowAmount; // Number of arrows to be shot

    private AudioSource audioSource; // Reference to the AudioSource component for sound effects

    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to this GameObject
    }

    // Method to trigger the trap
    public void TriggerTrap()
    {
        StartCoroutine(Shoot()); // Start the shooting coroutine
    }

    // Coroutine to handle shooting arrows
    private IEnumerator Shoot()
    {
        // Loop to shoot the specified number of arrows
        for (int i = 0; i < arrowAmount; i++)
        {
            audioSource.Play(); // Play the shooting sound effect
            GameObject gameObject = Instantiate(arrowPrefab, spawnPoint.position, Quaternion.identity); // Instantiate the arrow prefab at the spawn point
            yield return new WaitForSeconds(delayBetweenShots); // Wait for the specified delay before shooting the next arrow
        }
    }
}
