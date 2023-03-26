using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float startTime = 60.0f; // starting time in seconds
    public TextMeshProUGUI countdownText; // UI text object to display countdown
    public Image filledImage1; // first UI image to display countdown progress
    public Image filledImage2; // second UI image to display countdown progress
    public GameObject gameOverUi;

    private float currentTime; // current time left
    private bool isTimerRunning; // flag to check if timer is running
    public bool hasWon = false; // flag to check if player has won the game

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
            countdownText.text = currentTime.ToString("0.00");

            // Update the filled images
            float progress = currentTime / startTime;
            filledImage1.fillAmount = progress;
            filledImage2.fillAmount = progress;

            // Check if the timer has reached zero
            if (currentTime <= 0.0f)
            {
                isTimerRunning = false; // stop the timer
                GameOver(); // call the game over function
            }

            // Check if the player has won the game
            if (hasWon)
            {
                isTimerRunning = false; // stop the timer
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
