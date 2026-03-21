using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{

    public Text TimerText;
    public Timer script;
    public GameObject WinPanel;

    void OnTriggerEnter(Collider other)
    {
        script.enabled = false;
        WinPanel.gameObject.SetActive(true);
    }
}
