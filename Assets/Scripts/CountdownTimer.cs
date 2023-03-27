using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

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

    public GameObject UI_Replay;
    public bool moveCursor;

    void Start()
    {
        currentTime = startTime; // set starting time
        isTimerRunning = true; // start the timer
        Cursor.visible = false;
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();

            if (moveCursor == true)
            {
                unlockCursor();
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            ResumeGame();

            if (moveCursor == true)
            {
                unlockCursor();
            }
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverUi.SetActive(true);
        // code to trigger the game over state
    }

    public void ResumeGame()
    {
        if (Time.timeScale == 0)//????????
        {
            Cursor.visible = false;
            UI_Replay.SetActive(false);
            Time.timeScale = 1;
        }
        else if (Time.timeScale > 0)//????????
        {
            Cursor.visible = true;
            UI_Replay.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void unlockCursor()
    {
        if (Time.timeScale == 0)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Time.timeScale > 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}