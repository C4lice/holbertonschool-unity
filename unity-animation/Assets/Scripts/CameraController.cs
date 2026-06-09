using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CameraController is responsible for controlling the camera's position and rotation based on user input. It allows the player to rotate the camera around a target (lookAt) and adjust the distance from the target. The camera's vertical rotation can be inverted based on user preferences stored in PlayerPrefs.
/// </summary>
public class CameraController : MonoBehaviour
{

    private const float YMin = -50.0f;
    private const float YMax = 50.0f;

    public Transform lookAt;

    public Transform Player;

    public float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensivity = 4.0f;

    public bool isInverted;


    void Start()
    {
      isInverted = PlayerPrefs.GetInt("isInvert", 0) == 1;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X") * sensivity;
            if (isInverted)
                currentY += Input.GetAxis("Mouse Y") * sensivity;
            else
                currentY -= Input.GetAxis("Mouse Y") * sensivity;
        }
        currentY = Mathf.Clamp(currentY, YMin, YMax);

        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        transform.position = lookAt.position + rotation * direction;
        transform.LookAt(lookAt.position);
    }
}
