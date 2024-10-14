using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrap : MonoBehaviour, ITriggerable
{
    [SerializeField] private float timeBeforeRecovery = 1f; // Time to wait before the trap resets (recovers)

    private Animator animator; // Reference to the Animator component to control animations

    // Initialize the Animator component
    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator attached to the WallTrap
    }

    // Method to trigger the trap's activation
    public void TriggerTrap()
    {
        animator.SetTrigger("TriggerTrap"); // Activate the trap by triggering the "TriggerTrap" animation
        StartCoroutine(Recovery()); // Start the recovery coroutine
    }

    // Coroutine to handle the trap's recovery after a delay
    private IEnumerator Recovery()
    {
        yield return new WaitForSeconds(timeBeforeRecovery); // Wait for the specified recovery time
        animator.SetTrigger("Recover"); // Trigger the recovery animation
    }
}
