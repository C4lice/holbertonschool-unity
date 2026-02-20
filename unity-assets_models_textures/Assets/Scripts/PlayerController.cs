using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal"); // A / D
        float moveZ = Input.GetAxis("Vertical");   // W / S

        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        Vector3 velocity = movement * moveSpeed;

        Vector3 currentVelocity = rb.linearVelocity;
        rb.linearVelocity = new Vector3(velocity.x, currentVelocity.y, velocity.z);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }
}
