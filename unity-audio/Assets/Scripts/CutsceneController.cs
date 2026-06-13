using UnityEngine;

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
