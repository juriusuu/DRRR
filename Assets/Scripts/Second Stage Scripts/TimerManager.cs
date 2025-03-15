using UnityEngine;
using TMPro; // Include this for TextMeshPro
using System.Collections; // Include this for IEnumerator
using UnityEngine.SceneManagement; // Include this for scene management

public enum GameState
{
    Playing,
    PlayerDead,
    StageCompleted
}

public class TimerManager : MonoBehaviour
{
    public float countdownTime = 60f; // Set the initial countdown time to 60 seconds
    public TMP_Text timerText; // Reference to the UI Text for the timer

    private float timer;
    private GameState currentState;

    void Start()
    {
        currentState = GameState.Playing; // Initialize the state to Playing
        StartCountdown(); // Start the countdown when the game starts
    }

    public void StartCountdown()
    {
        timer = this.countdownTime; // Reset the timer to the countdown time
        StartCoroutine(CountdownCoroutine()); // Start the countdown coroutine
    }

    private IEnumerator CountdownCoroutine()
    {
        while (timer > 0 && currentState == GameState.Playing)
        {
            timer -= Time.deltaTime; // Decrease the timer
            UpdateTimerUI(); // Update the timer UI
            yield return null; // Wait for the next frame
        }

        if (currentState == GameState.Playing)
        {
            timer = 0; // Ensure timer does not go below 0
            UpdateTimerUI(); // Update the UI to show 0
            HandleTimerEnd(); // Handle what happens when the timer ends
        }
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Time Left: " + Mathf.Ceil(timer).ToString(); // Update the text to show remaining time
        }
    }

    private void HandleTimerEnd()
    {
        if (SceneManager.GetActiveScene().name == "FirstScene")
        {
            TransitionToState(GameState.PlayerDead);
        }
        else if (SceneManager.GetActiveScene().name == "SecondScene")
        {
            TransitionToState(GameState.StageCompleted);
        }
    }

    private void TransitionToState(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case GameState.PlayerDead:
                Debug.Log("Player has died.");
                GameManager.Instance.Die(); // Call the Die method from GameManager
                break;

            case GameState.StageCompleted:
                Debug.Log("Player has passed the stage.");
                // Call your stage completion logic here, e.g., LoadNextStage();
                break;
        }
    }

    // Add the StartRespawnCoroutine method
    public void StartRespawnCoroutine(LifeManager lifeManager)
    {
        StartCoroutine(RespawnCoroutine(lifeManager));
    }

    private IEnumerator RespawnCoroutine(LifeManager lifeManager)
    {
        // Add your respawn logic here
        yield return new WaitForSeconds(3); // Example wait time
        lifeManager.Respawn(); // Call the Respawn method in LifeManager
    }
}
/* Without GameState
public class TimerManager : MonoBehaviour
{
    public float countdownTime = 60f; // Set the initial countdown time to 60 seconds
    public TMP_Text timerText; // Reference to the UI Text for the timer

    private float timer;

    void Start()
    {
        StartCountdown(); // Start the countdown when the game starts
    }

    public void StartCountdown()
    {
        timer = this.countdownTime; // Reset the timer to the countdown time
        StartCoroutine(CountdownCoroutine()); // Start the countdown coroutine
    }

    private IEnumerator CountdownCoroutine()
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime; // Decrease the timer
            UpdateTimerUI(); // Update the timer UI
            yield return null; // Wait for the next frame
        }
        timer = 0; // Ensure timer does not go below 0
        UpdateTimerUI(); // Update the UI to show 0
        // Optionally, trigger an event when the timer reaches zero
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Time Left: " + Mathf.Ceil(timer).ToString(); // Update the text to show remaining time
        }
    }

    public void StartRespawnCoroutine(LifeManager lifeManager)
    {
        StartCoroutine(RespawnCoroutine(lifeManager));
    }

    private IEnumerator RespawnCoroutine(LifeManager lifeManager)
    {
        // Add your respawn logic here
        yield return new WaitForSeconds(3); // Example wait time
        lifeManager.Respawn();
    }
}
 */