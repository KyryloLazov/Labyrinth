using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeTrap : MonoBehaviour
{
    [SerializeField] private bool isRight = true;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isRight", isRight);
    }


}
