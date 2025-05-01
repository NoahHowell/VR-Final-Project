using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // optional for game over scene

public class EscapeRoomTimer : MonoBehaviour
{
    public float timeLimit = 600f; // 10 minutes in seconds
    private float remainingTime;

    public TextMeshProUGUI timerText; // Assign in Inspector
    public GameObject loseScreen;     // Optional: assign a UI panel to show on failure

    private bool gameOver = false;

    void Start()
    {
        remainingTime = timeLimit;
    }

    void Update()
    {
        if (gameOver) return;

        remainingTime -= Time.deltaTime;
        remainingTime = Mathf.Max(remainingTime, 0f); // Clamp to 0

        // Update UI
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (remainingTime <= 0f)
        {
            TriggerLoss();
        }
    }

    void TriggerLoss()
    {
        gameOver = true;

        // Show lose screen if assigned
        if (loseScreen != null)
            loseScreen.SetActive(true);

        // Optional: lock doors, stop input, fade out, etc.

        // Or: Load a "Game Over" scene
        // SceneManager.LoadScene("GameOverScene");
    }
}
