using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] traps; // Array of traps to be triggered

    private void OnTriggerEnter(Collider other) // Called when a collider enters the trigger
    {
        if (other.CompareTag("Player")) // Check if the collider belongs to the Player
        {
            foreach (var trap in traps) // Loop through each trap in the array
            {
                ITriggerable triggerableTrap = trap.GetComponent<ITriggerable>(); // Get the ITriggerable component
                if (triggerableTrap != null) // Check if the component exists
                {
                    triggerableTrap.TriggerTrap(); // Trigger the trap
                }
            }
        }
    }
}
