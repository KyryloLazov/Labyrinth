using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // Check if the collider belongs to the Player
        {
            other.GetComponent<PlayerInteraction>().Death(); // Call the Death method on the PlayerInteraction component
        }
    }
}
