using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{

    [Tooltip("Script player movement")]
    [SerializeField]
    public PlayerController PlayerScript;

    [Tooltip("Script camera movement")]
    [SerializeField]
    public CameraController CameraScript;

    [Tooltip("Timer to pause")]
    [SerializeField]
    public Timer TimeScript;

    [Tooltip("Timer to pause")]
    [SerializeField]
    public PauseMenu PauseScript;

    [Tooltip("animation to stop")]
    [SerializeField]
    private Animator animator;

    public GameObject WinPanel;
    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioSource WinBGM;

    void OnTriggerEnter(Collider other)
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isFalling", false);
        CameraScript.enabled = false;
        PlayerScript.enabled = false;
        TimeScript.enabled = false;
        PauseScript.enabled = false;
        WinPanel.gameObject.SetActive(true);
        BGM.Stop();
        WinBGM.Play();
    }
}
