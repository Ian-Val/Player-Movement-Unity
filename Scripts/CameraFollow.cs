using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float sensitivity = 100f;
    float cameraPitch = 0f;
    public Transform playerBody;
    public float minPitch = -10f;
    public float maxPitch = 70f;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; //Get input
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        cameraPitch -= mouseY; //Inverts cameraPitch
        cameraPitch = Mathf.Clamp(cameraPitch, minPitch, maxPitch); // Limit pitch amount

        transform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f); //Set rotation of camera socket
        playerBody.Rotate(Vector3.up * mouseX); //Set rotation of the player
    }
}
