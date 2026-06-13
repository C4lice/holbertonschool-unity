using UnityEngine;

public class MenuSFX : MonoBehaviour
{
    public static MenuSFX instance;
    [SerializeField] private AudioSource audioSourceHover;
    [SerializeField] private AudioSource audioSourceClick;

    void Awake()
    {
        instance = this;
    }

    public void PlayHoverSound()
    {
        audioSourceHover.Play();
    }

    public void PlayClickSound()
    {
        audioSourceClick.Play();
    }
}