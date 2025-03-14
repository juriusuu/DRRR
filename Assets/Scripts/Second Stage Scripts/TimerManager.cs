using UnityEngine;
using TMPro; // Include this for TextMeshPro
using System.Collections; // Include this for IEnumerator

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
