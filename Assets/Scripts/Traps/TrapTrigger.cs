using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] traps;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            foreach(var trap in traps)
            {
                ITriggerable triggerableTrap = trap.GetComponent<ITriggerable>();
                if (triggerableTrap != null)
                {
                    triggerableTrap.TriggerTrap();
                }
            }
            
        }
    }
}
