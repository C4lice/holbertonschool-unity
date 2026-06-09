using UnityEngine;

public class JumpController : MonoBehaviour
{
    public bool isGrounded = false;
    [SerializeField] private Animator animator;

    void OnTriggerStay(Collider collider)
    {
        animator.SetBool("isJumping", false);
        isGrounded = true;

    }

    void OnTriggerExit(Collider collider)
    {
        animator.SetBool("isJumping", true);
        isGrounded = false;
    }
}