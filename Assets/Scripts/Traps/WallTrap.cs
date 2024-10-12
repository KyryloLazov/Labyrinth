using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrap : MonoBehaviour, ITriggerable
{
    [SerializeField] private float timeBeforeRecovery = 1f;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TriggerTrap()
    {
        animator.SetTrigger("TriggerTrap");
        StartCoroutine(Recovery());
    }

    private IEnumerator Recovery()
    {
        yield return new WaitForSeconds(timeBeforeRecovery);
        animator.SetTrigger("Recover");
    }
}
