using UnityEngine;
using System.Collections;
using TMPro;

public class Hand : MonoBehaviour
{
    public GameObject RightUp, LeftUp, LeftDown, RightDown, RightFoot, LeftFoot;
    public TextMeshProUGUI scoreText; // Reference to the UI TextMeshPro element
    public static int score = 0;     // Global static score variable

    void Start()
    {
        // Find the objects by name
        RightUp = GameObject.Find("RightUp(Clone)");
        LeftUp = GameObject.Find("LeftUp(Clone)");
        LeftDown = GameObject.Find("LeftDown(Clone)");
        RightDown = GameObject.Find("RightDown(Clone)");
        RightFoot = GameObject.Find("RightFoot(Clone)");
        LeftFoot = GameObject.Find("LeftFoot(Clone)");

        // Initialize the score display
        UpdateScoreUI();
    }

    void Update()
    {
        RightUp = GameObject.Find("RightUp(Clone)");
        LeftUp = GameObject.Find("LeftUp(Clone)");
        LeftDown = GameObject.Find("LeftDown(Clone)");
        RightDown = GameObject.Find("RightDown(Clone)");
        RightFoot = GameObject.Find("RightFoot(Clone)");
        LeftFoot = GameObject.Find("LeftFoot(Clone)");
    }

    void OnTriggerEnter(Collider collision)
    {
        switch (collision.gameObject.name)
        {
            case "RightDown(Clone)":
                HandleSphereDisappear(RightDown);
                break;
            case "LeftUp(Clone)":
                HandleSphereDisappear(LeftUp);
                break;
            case "RightUp(Clone)":
                HandleSphereDisappear(RightUp);
                break;
            case "LeftDown(Clone)":
                HandleSphereDisappear(LeftDown);
                break;
            case "RightFoot(Clone)":
                HandleSphereDisappear(RightFoot);
                break;
            case "LeftFoot(Clone)":
                HandleSphereDisappear(LeftFoot);
                break;
            default:
                Debug.Log("No matching object");
                break;
        }
    }

    private void HandleSphereDisappear(GameObject sphere)
    {
        if (sphere != null)
        {
            score++;
            
            UpdateScoreUI(); // Update the UI
            sphere.SetActive(false); // Disable the sphere
            sphere.tag = ("Untagged");
            StartCoroutine(ActivateAfterDelay(sphere, 1000f)); // Reactivate it after 3 seconds
        }
    }

    private IEnumerator ActivateAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(true);
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogWarning("Score Text is not assigned in the inspector!");
        }
    }
}
