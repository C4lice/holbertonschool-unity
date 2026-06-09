using UnityEngine;

/// <summary>
/// CutsceneController is responsible for managing the transition from a cutscene to gameplay. When the cutscene animation finishes, it activates the main camera, enables the player controller, and shows the timer canvas. Finally, it deactivates itself to clean up the scene.
/// </summary>
public class CutsceneController : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject timerCanvas;

    public void OnAnimationFinished()
    {
        mainCamera.SetActive(true);
        playerController.enabled = true;
        timerCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
}
