using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float m_sensitivity = 200f;

    float xRotation;

    [SerializeField]
    Transform player;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        xRotation -= mouseY;

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        player.Rotate(0, mouseX, 0);
    }
}
