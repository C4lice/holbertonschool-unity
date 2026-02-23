using UnityEngine;
//// This script is responsible for managing a timer that can be enabled or disabled based on trigger events. When the player exits the trigger, the timer is enabled, allowing it to start tracking time.
public class TimerTrigger : MonoBehaviour
{

    public Timer script;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        script.enabled = true;
    }
}
