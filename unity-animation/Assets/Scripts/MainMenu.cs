using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Button QuitButton;
    public Button OptionButton;
    public List<Button> LevelButtons;

    void Start()
    {
        PlayerPrefs.SetInt("PreviouScene", 0);
        OptionButton.onClick.AddListener(Options);
        QuitButton.onClick.AddListener(QuitGame);

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
}
