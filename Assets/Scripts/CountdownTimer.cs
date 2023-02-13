using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float startTime = 60.0f; // starting time in seconds
    public TextMeshProUGUI countdownText; // UI text object to display countdown
    public GameObject gameOverUi;

    private float currentTime; // current time left
    private bool isTimerRunning; // flag to check if timer is running

    void Start()
    {
        currentTime = startTime; // set starting time
        isTimerRunning = true; // start the timer
    }

    void Update()
    {
        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime; // reduce current time by deltaTime

            // Update the countdown UI text
            countdownText.text = "Time Left: " + currentTime.ToString("0");

            // Check if the timer has reached zero
            if (currentTime <= 0.0f)
            {
                isTimerRunning = false; // stop the timer
                GameOver(); // call the game over function
            }
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverUi.SetActive(true);
        // code to trigger the game over state
    }
}
