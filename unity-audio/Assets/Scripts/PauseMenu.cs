using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    [Tooltip("Menu to display")]
    [SerializeField]
    public GameObject PauseCanvas;

    [Tooltip("Script player movement")]
    [SerializeField]
    public PlayerController PlayerScript;

    [Tooltip("Script camera movement")]
    [SerializeField]
    public CameraController CameraScript;

    [Tooltip("Timer to pause")]
    [SerializeField]
    public Timer TimeScript;

    [Tooltip("Button to resume game")]
    [SerializeField]
    public Button ResumeButton;

    [Tooltip("Button to restart game")]
    [SerializeField]
    public Button RestartButton;

    [Tooltip("Button to go to the menu")]
    [SerializeField]
    public Button MenuButton;

    [Tooltip("Button to go to the Option")]
    [SerializeField]
    public Button OptionsButton;
    

    public AudioMixerSnapshot normalSnapshot;
    public AudioMixerSnapshot pausedSnapshot;

    void Start()
    {
        ResumeButton.onClick.AddListener(Resume);
        RestartButton.onClick.AddListener(Restart);
        MenuButton.onClick.AddListener(MainMenu);
        OptionsButton.onClick.AddListener(Options);
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PauseCanvas.activeInHierarchy == true) {
            normalSnapshot.TransitionTo(0.5f);
            Resume();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && PauseCanvas.activeInHierarchy == false)
        {
            pausedSnapshot.TransitionTo(0.5f);
            Pause();
        }
    }

    void Pause()
    {
        CameraScript.enabled = false;
        PlayerScript.enabled = false;
        TimeScript.enabled = false;
        PauseCanvas.gameObject.SetActive(true);
    }

    void Resume()
    {
        CameraScript.enabled = true;
        PlayerScript.enabled = true;
        TimeScript.enabled = true;
        PauseCanvas.gameObject.SetActive(false);
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu() 
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }

    public void Options()
    {
        PlayerPrefs.SetInt("PreviouScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(sceneName: "Options");
    }
}
