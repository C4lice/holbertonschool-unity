using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text TimerText;
    private float actualTime = 0f;
    private float minutes = 0f;
    private float seconds = 0f;
    
    void Start()
    {
        
    }

    void Update()
    {
        minutes = Mathf.FloorToInt(actualTime / 60);
        seconds = actualTime % 60;
        actualTime += Time.deltaTime;
        TimerText.text = $"{minutes}:{seconds:00.00}";
    }
}
