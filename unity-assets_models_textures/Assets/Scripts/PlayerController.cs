using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float jumphigh = 3f;

    private Rigidbody rb;
    public bool isGrounded;

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
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

        transform.Translate(move, Space.World);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(new Vector3(0.0f, jumphigh, 0.0f) * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (FallingLimit())
        {
            transform.position = new Vector3(0, 40f, 0);
        }
    }

    public bool FallingLimit()
    {
        if (rb.position.y < -25)
        {
            return true;
        }
        return false;
    }
}
