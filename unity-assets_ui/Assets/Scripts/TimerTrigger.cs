using UnityEngine;

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
