using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeTrap : MonoBehaviour
{
    [SerializeField] private bool isRight = true; // Boolean to determine the axe's swing direction

    private Animator animator; // Reference to the Animator component

    private void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component attached to this GameObject
        animator.SetBool("isRight", isRight); // Set the animation parameter based on the isRight value
    }
}
