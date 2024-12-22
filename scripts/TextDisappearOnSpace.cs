using UnityEngine;
using TMPro; // For TextMeshProUGUI

public class TextDisappearOnSpace : MonoBehaviour
{
    // Reference to the TextMeshProUGUI component
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        // Get the TextMeshProUGUI component attached to this GameObject
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Set the TextMeshProUGUI's visibility to false
            textMeshPro.gameObject.SetActive(false);
        }
    }
}
