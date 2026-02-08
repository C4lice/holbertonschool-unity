using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button PlayButton;

    public Button QuitButton;

    public Button OptionButton;

    public Button BackButton;

    public GameObject MainMenuPage;

    public GameObject OptionPage;

    public Material trapMat;

    public Material goalMat;

    public Toggle colorblindMode;

    // Start est appelé une fois avant la première exécution de Update après la création de MonoBehaviour.
    void Start()
    {
        PlayButton.onClick.AddListener(PlayButtonClicked);
        OptionButton.onClick.AddListener(OptionButtonClicked);
        QuitButton.onClick.AddListener(QuitButtonClicked);
        BackButton.onClick.AddListener(BackButtonClicked);
    }

    // La mise à jour est appelée une fois par image.
    void PlayButtonClicked()
    {
        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
        SceneManager.LoadScene(sceneName:"maze"); 
    }
    // Quitter le jeu
    void QuitButtonClicked()
    {
        Debug.Log("Quit Game");
    }
    // Afficher la page d'options
    void OptionButtonClicked()
    {
        MainMenuPage.gameObject.SetActive(false);
        OptionPage.gameObject.SetActive(true);
    }
    // Retourner à la page principale
    void BackButtonClicked()
    {
        MainMenuPage.gameObject.SetActive(true);
        OptionPage.gameObject.SetActive(false);
    }
}
