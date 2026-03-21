using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WinMenu : MonoBehaviour
{
    public Button NextButton;
    public Button MenuButton;
    public TextMeshProUGUI TimerText;
    public Text time;


    void Start()
    {
        NextButton.onClick.AddListener(Next);
        MenuButton.onClick.AddListener(MainMenu);
        TimerText.text = time.text;
    }

    void MainMenu()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }

    void Next()
    { 
        if (SceneManager.GetActiveScene().buildIndex + 1 < 5)
            SceneManager.LoadScene(sceneBuildIndex: SceneManager.GetActiveScene().buildIndex + 1);
        else
            MainMenu();
    }
}
