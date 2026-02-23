using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float jumphigh = 3f;

    private Rigidbody rb;
    public bool isGrounded;
    /// This script is responsible for controlling the player's movement and jumping mechanics based on user input.
    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
    /// This method is called when the player exits a collision with another object, indicating that the player is no longer grounded.
    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
    /// Initializes the player's Rigidbody component and sets constraints to prevent rotation on the X and Z axes, allowing for stable movement and jumping.
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
    /// Updates the player's position based on horizontal and vertical input, and allows the player to jump when the space key is pressed and the player is grounded. Additionally, it checks if the player has fallen below a certain limit and resets their position if necessary.
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
    /// Checks if the player's Y position has fallen below a certain threshold, indicating that they have fallen off the platform or level. If the player's Y position is less than -25, it returns true; otherwise, it returns false.
    public bool FallingLimit()
    {
        if (rb.position.y < -25)
        {
            return true;
        }
        return false;
    }
}
