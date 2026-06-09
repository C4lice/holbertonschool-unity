using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class OptionsMenu  : MonoBehaviour
{

    public Button BackButton;
    public Button ApplyButton;
    public bool isInvert;
    public Toggle toggleButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
       PlayerPrefs.SetInt("ActualScene", 1);
       isInvert = PlayerPrefs.GetInt("isInvert", 0) == 1;
       toggleButton.isOn = isInvert;
       BackButton.onClick.AddListener(Back);
       ApplyButton.onClick.AddListener(Apply);
    }   

    public void Back()
    {
        SceneManager.LoadScene(sceneBuildIndex: PlayerPrefs.GetInt("PreviouScene"));
    }

    public void Apply()
    {
        if (toggleButton.isOn)
            PlayerPrefs.SetInt("isInvert", 1);
        else
            PlayerPrefs.SetInt("isInvert", 0);
    }
}
