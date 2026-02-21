using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{

    public Text TimerText;
    public Timer script;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        TimerText.color = Color.green;
        TimerText.fontSize = 64;
        script.enabled = false;
    }
}
