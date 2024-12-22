using UnityEngine;

public class Colour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Load materials from the Resources folder
        Material glowMaterial = Resources.Load<Material>("Backgrounds/glowMaterial");
        Material pointsMaterial = Resources.Load<Material>("Backgrounds/points");

        // Check if the materials are successfully loaded
        if (glowMaterial != null && pointsMaterial != null)
        {
            // Debugging: Log to confirm materials are loaded
            Debug.Log("Materials loaded: glowMaterial and pointsMaterial");

            
        }
        else
        {
            Debug.LogError("One or more materials could not be loaded.");
        }
    }

    void Update()
    {
        Material glowMaterial = Resources.Load<Material>("Backgrounds/glowMaterial");
        Material pointsMaterial = Resources.Load<Material>("Backgrounds/points");
        // Check the GameObject's tag and assign the appropriate material
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            if (gameObject.CompareTag("Glowing"))
            {
                renderer.material = glowMaterial; // Assign the glowMaterial to the GameObject
                
            }
            else
            {
                renderer.material = pointsMaterial; // Assign the pointsMaterial to the GameObject
                
            }
        }
        else
        {
            Debug.LogError("Renderer component not found on " + gameObject.name);
        }
    }
}
