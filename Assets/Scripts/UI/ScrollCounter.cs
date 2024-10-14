using System.Collections;
using System.Collections.Generic;
using TMPro; // Namespace for TextMeshPro
using UnityEngine;

public class ScrollCounter : MonoBehaviour
{
    [SerializeField] private int scrollsNeeded; // The total number of scrolls needed to achieve a goal
    private TextMeshProUGUI counterText; // Reference to the TextMeshProUGUI component to display the scroll count

    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component attached to this GameObject
        counterText.text = $"Scrolls: 0/{scrollsNeeded}"; // Initialize the counter text to show 0 collected scrolls
    }

    // Method to update the scroll count display
    public void UpdateScrollsCount(int scrolls)
    {
        // Check if the number of scrolls is less than or equal to the required amount
        if (scrolls <= scrollsNeeded)
        {
            // Update the counter text with the current number of scrolls collected
            counterText.text = $"Scrolls: {scrolls}/{scrollsNeeded}";
        }
    }
}
