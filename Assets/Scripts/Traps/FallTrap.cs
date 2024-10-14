using System.Collections;
using UnityEngine;

public class FallTrap : MonoBehaviour
{
    [SerializeField] private float riseSpeed = 3f; // Speed at which the trap rises
    [SerializeField] private float delayBeforeFall = 2f; // Delay before the trap starts to fall
    [SerializeField] private float delayBeforeRise = 1f; // Delay before the trap starts to rise
    [SerializeField] private GameObject hitBox; // Reference to the hitbox GameObject

    private Rigidbody rb; // Reference to the Rigidbody component
    private Vector3 startPos; // Initial position of the trap
    private bool isRising = false; // Flag to check if the trap is currently rising

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to this GameObject
        startPos = transform.position; // Store the initial position of the trap
        StartCoroutine(FallAndRiseCycle()); // Start the coroutine for falling and rising
    }

    // Coroutine to handle the fall and rise cycle of the trap
    IEnumerator FallAndRiseCycle()
    {
        while (true) // Infinite loop for continuous cycle
        {
            // Wait for the specified delay before the trap falls
            yield return new WaitForSeconds(delayBeforeFall);
            rb.useGravity = true; // Enable gravity for the trap
            hitBox.SetActive(true); // Activate the hitbox

            // Wait until the trap is no longer falling (uses OnCollisionEnter)
            yield return new WaitUntil(() => !rb.useGravity); // Wait until the trap hits the ground

            // Wait for the specified delay before the trap starts to rise
            yield return new WaitForSeconds(delayBeforeRise);

            // Lift the trap back to its original position
            while (Vector3.Distance(transform.position, startPos) > 0.1f) // While the trap is not at its start position
            {
                isRising = true; // Set rising flag to true
                transform.position = Vector3.MoveTowards(transform.position, startPos, riseSpeed * Time.deltaTime); // Move the trap upwards
                yield return null; // Wait for the next frame
            }

            isRising = false; // Reset rising flag
            rb.useGravity = false; // Disable gravity for the trap
            hitBox.SetActive(false); // Deactivate the hitbox
        }
    }

    // Detect collision with ground
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && isRising == false) // Check if collided with ground and not rising
        {
            rb.useGravity = false; // Disable gravity when hitting the ground
            hitBox.SetActive(false); // Deactivate the hitbox
        }
    }
}
