using UnityEngine;
using UnityEngine.UI;
/// This script is responsible for managing a timer that tracks the elapsed time in minutes and seconds, and updates a UI Text element to display the current time.
public class Timer : MonoBehaviour
{

    public Text TimerText;
    private float actualTime = 0f;
    private float minutes = 0f;
    private float seconds = 0f;
    /// Initializes the timer. Currently, it does not perform any specific actions on start.
    void Start()
    {
        
    }
    /// Updates the timer by calculating the minutes and seconds based on the elapsed time, and updates the TimerText UI element to display the current time in a formatted string. The actualTime variable is incremented by the time elapsed since the last frame (Time.deltaTime) to keep track of the total elapsed time.
    void Update()
    {
        minutes = Mathf.FloorToInt(actualTime / 60);
        seconds = actualTime % 60;
        actualTime += Time.deltaTime;
        TimerText.text = $"{minutes}:{seconds:00.00}";
    }
}
