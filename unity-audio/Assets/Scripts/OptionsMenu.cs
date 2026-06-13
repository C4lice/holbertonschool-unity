using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Audio;

public class OptionsMenu  : MonoBehaviour
{

    public Button BackButton;
    public Button ApplyButton;
    public bool isInvert;
    public Toggle toggleButton;
    private float oldValueBGM;
    private float oldvalueSFX;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioMixer mixer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("ActualScene", 1);

        isInvert = PlayerPrefs.GetInt("isInvert", 0) == 1;
        toggleButton.isOn = isInvert;

        BackButton.onClick.AddListener(Back);
        ApplyButton.onClick.AddListener(Apply);

        float savedVolumeBGM = PlayerPrefs.GetFloat("BGMVolume", 1f);
        bgmSlider.value = savedVolumeBGM;
        oldValueBGM = savedVolumeBGM;

        float savedVolumeSFX = PlayerPrefs.GetFloat("SFXVolume", 1f);
        sfxSlider.value = savedVolumeSFX;
        oldvalueSFX = savedVolumeSFX;
        
        sfxSlider.onValueChanged.AddListener(SetVolumeSFX);
        bgmSlider.onValueChanged.AddListener(SetVolumeBGM);
    }   

    public void Back()
    {
        SceneManager.LoadScene(sceneBuildIndex: PlayerPrefs.GetInt("PreviouScene"));
        bgmSlider.value = oldValueBGM;
        sfxSlider.value = oldvalueSFX;
    }

    public void Apply()
    {
        if (toggleButton.isOn)
            PlayerPrefs.SetInt("isInvert", 1);
        else
            PlayerPrefs.SetInt("isInvert", 0);
        oldValueBGM = bgmSlider.value;
        oldvalueSFX = sfxSlider.value;
        Back();
    }

    public void SetVolumeBGM(float value)
    {
        value = Mathf.Clamp(value, 0.0001f, 1f);
        float volume = Mathf.Log10(value) * 20;
        mixer.SetFloat("BGMVolume", volume);

        PlayerPrefs.SetFloat("BGMVolume", value);
    }

    public void SetVolumeSFX(float value)
    {
        value = Mathf.Clamp(value, 0.0001f, 1f);
        float volume = Mathf.Log10(value) * 20;
        mixer.SetFloat("SFXVolume", volume);

        PlayerPrefs.SetFloat("SFXVolume", value);
    }
}
