using UnityEngine;

public class JumpController : MonoBehaviour
{
    public bool isGrounded = false;
    public bool onGrass = false;
    public bool onRock = false;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource fallGrass;
    [SerializeField] private AudioSource fallRock;

    void OnTriggerStay(Collider collider)
    {
        animator.SetBool("isJumping", false);
        isGrounded = true;
        if (collider.CompareTag("Rock Plateform"))
        {
            onRock = true;
            onGrass = false;
        }
        else if (collider.CompareTag("Grass Plateform"))
        {
            onGrass = true;
            onRock = false;
        }
        else
        {
            onRock = false;
            onGrass = false;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        animator.SetBool("isJumping", true);
        isGrounded = false;
        onRock = false;
        onGrass = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Rock Plateform"))
        {
            fallRock.Play();
        }
        else if (collider.CompareTag("Grass Plateform"))
        {
            fallGrass.Play();
        }
    }
}