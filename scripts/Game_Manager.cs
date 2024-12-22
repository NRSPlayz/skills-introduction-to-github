using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    public TextMeshProUGUI time;
    public List<GameObject> targets;  // List of target GameObjects
    public float Spawnrate = 5.0f;    // Spawn rate (5 seconds)
    private GameObject currentTarget; // To track the currently spawned target
    private bool gameStarted = false; // Track whether the game has started
    private int lastTargetIndex = -1; // Index of the last spawned target

    void Start()
    {
        time.text = ""; // Initial UI message
    }

    void Update()
    {
        // Check for spacebar press to start the game
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
            StartCoroutine(SpawnTargets());
            Debug.Log("Game started. Target spawning commenced.");
        }
    }

    // Coroutine to spawn targets
    IEnumerator SpawnTargets()
    {
        while (time.text != "Time: 00:01")  // Loop to spawn targets until timer ends
        {
            yield return new WaitForSeconds(Spawnrate);  // Wait for the defined spawn rate

            // Destroy the previous target if it exists
            if (currentTarget != null)
            {
                Destroy(currentTarget);
            }

            // Get a random index from the list of targets, ensuring it's not the same as the last target
            int index;
            do
            {
                index = Random.Range(0, targets.Count);
            } while (index == lastTargetIndex);

            // Instantiate a new target at the chosen index and set it as the current target
            currentTarget = Instantiate(targets[index]);

            // Update the last target index
            lastTargetIndex = index;
        }

        // Destroy the last target after the loop ends
        if (currentTarget != null)
        {
            Destroy(currentTarget);
        }

        Debug.Log("Target spawning stopped.");
    }
}
