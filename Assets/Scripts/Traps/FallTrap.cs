using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrap : MonoBehaviour
{
    //[SerializeField] private float fallSpeed = 5f;
    [SerializeField] private float riseSpeed = 3f;
    [SerializeField] private float delayBeforFall = 2f;
    [SerializeField] private float delayBeforeRise = 1f;
    //[SerializeField] private float depth = 4f;

    private Rigidbody rb;
    private Vector3 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        startPos = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.useGravity = false;  // Виключаємо гравітацію після падіння
            StartCoroutine(RaiseTrap());
        }
    }

    IEnumerator RaiseTrap()
    {
        yield return new WaitForSeconds(delayBeforeRise);
        while (Vector3.Distance(transform.position, startPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, riseSpeed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(delayBeforFall);
        rb.useGravity = true;
    }
}
