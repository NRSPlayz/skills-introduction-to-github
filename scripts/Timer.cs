using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject RightUp, LeftUp, LeftDown, RightDown, RightFoot, LeftFoot;

    public float timeRemaining = 60f;  // Set the timer to 60 seconds
    public TextMeshProUGUI time;
    public string text = "Score"; // The name of the UI Text element
    public TextMeshProUGUI scoreText; // Reference to the UI TextMeshPro element

    public GameObject player;
    public GameObject timeBox;

    private bool timerEnded = false;
    private bool gameStarted = false; // Track whether the game has started

    void Start()
    {
        // Optionally, log the initial state
        Debug.Log("Waiting for spacebar to start the game.");

        RightUp = GameObject.Find("RightUp");
        LeftUp = GameObject.Find("LeftUp");
        LeftDown = GameObject.Find("LeftDown");
        RightDown = GameObject.Find("RightDown");
        RightFoot = GameObject.Find("RightFoot");
        LeftFoot = GameObject.Find("LeftFoot");

        time.text = ""; // Initial UI message
        scoreText.gameObject.SetActive(false); // Hide the score box initially
    }

    void Update()
    {
        // Check for spacebar press to start the game
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
            scoreText.gameObject.SetActive(true); // Show the score box when the game starts
            Debug.Log("Game started.");
        }

        if (gameStarted)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;  // Decrease the time each frame
            }
            else if (!timerEnded)
            {
                timerEnded = true;
                HandleTimerEnd();
            }

            float minutes = Mathf.FloorToInt(timeRemaining / 60);
            float seconds = Mathf.FloorToInt(timeRemaining % 60);
            if (minutes > 0 || seconds > 0)
            {
                time.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }
    }

    private void HandleTimerEnd()
    {
        timeBox.SetActive(false);
        Time.timeScale = 0; // Stop the game

        // Center the score text box horizontally
        RectTransform scoreTextRect = scoreText.GetComponent<RectTransform>();
        if (scoreTextRect != null)
        {
            Canvas canvas = scoreText.GetComponentInParent<Canvas>();
            if (canvas != null)
            {
                Vector2 canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;
                scoreTextRect.anchoredPosition = new Vector2(-68, scoreTextRect.anchoredPosition.y); // Center horizontally
            }
        }

        Debug.Log("Timer ended. Score textbox repositioned.");
    }
}
