using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float jumphigh = 3f;
    [SerializeField] private float fallDelay = 0.2f;

    private bool falling = false;
    private float fallTimer = 0f;
    private Rigidbody rb;
    public JumpController Jump;

    private Quaternion targetRotation;

    [SerializeField] private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        if (!falling)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 camForward = Camera.main.transform.forward;
            Vector3 camRight = Camera.main.transform.right;

            camForward.y = 0f;
            camRight.y = 0f;

            camForward.Normalize();
            camRight.Normalize();

            Vector3 move = (camForward * v + camRight * h) * speed * Time.deltaTime;

            Vector3 inputDir = camForward * v + camRight * h;
            bool isMoving = inputDir != Vector3.zero;
            animator.SetBool("isRunning", isMoving);  
        
            transform.Translate(move, Space.World);

            if (move != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(move);
                targetRotation *= Quaternion.Euler(0, -90f, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            }

            if(Input.GetKeyDown(KeyCode.Space) && Jump.isGrounded){
                rb.AddForce(new Vector3(0.0f, jumphigh, 0.0f) * jumpForce, ForceMode.Impulse);
            }
        }

        if (rb.linearVelocity.y < -0.1f && !Jump.isGrounded)
        {
            fallTimer += Time.deltaTime;
            if (fallTimer >= fallDelay)
            {
                falling = true;
                animator.SetBool("isFalling", true);
            }
        }
        else
        {
            falling = false;
            fallTimer = 0f;
            animator.SetBool("isFalling", false);
        }
        FallingLimit();
    }

    public void FallingLimit()
    {
        if (rb.position.y < -25)
        {
            transform.position = new Vector3(0, 40f, 0);
        }
    }
}