using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    public float mouseSensitivity = 100f;
    public float distance = 6.25f;
    public float height = 2.5f;

    public bool requireRightClick = false;

    private float xRotation = 9f;
    private float yRotation = 0f;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player").transform;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMouseInput();
        FollowPlayer();
    }

    void HandleMouseInput()
    {
        if (requireRightClick && !Input.GetMouseButton(1))
            return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -30f, 60f);
    }

    void FollowPlayer()
    {
        Vector3 offset = new Vector3(0, height, -distance);
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);

        transform.position = player.position + rotation * offset;
        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}
