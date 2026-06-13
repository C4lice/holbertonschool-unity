using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    public Button QuitButton;
    public Button OptionButton;
    public List<Button> LevelButtons;
    [SerializeField] private AudioMixer mixer;

    void Start()
    {
        PlayerPrefs.SetInt("PreviouScene", 0);
        OptionButton.onClick.AddListener(Options);
        QuitButton.onClick.AddListener(QuitGame);
        SetVolume();
        for (int i = 0; i < LevelButtons.Count; i++)
        {
            int index = i;
            LevelButtons[i].onClick.AddListener(() => LevelSelect(index));
        }
    }

    void LevelSelect(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < 3)
        {
            SceneManager.LoadScene(sceneName: "Level0" + (levelIndex + 1));
        }
    }

    void Options()
    {
        SceneManager.LoadScene(sceneName: "Options");
    }

    void QuitGame()
    {
        Debug.Log("Quit Game");
    }

    public void SetVolume()
    {
        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        float value = Mathf.Clamp(savedVolume, 0.0001f, 1f);
        float volume = Mathf.Log10(value) * 20;
        mixer.SetFloat("BGMVolume", volume);

        savedVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        value = Mathf.Clamp(savedVolume, 0.0001f, 1f);
        volume = Mathf.Log10(value) * 20;
        mixer.SetFloat("SFXVolume", volume);
    }
}
