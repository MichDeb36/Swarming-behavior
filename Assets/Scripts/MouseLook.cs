using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField] private float speed = 3.0f;
    [SerializeField] Transform body;

    private float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    void MoveMouse()
    {
        float x = Input.GetAxis("Mouse X");
        float z = Input.GetAxis("Mouse Y");
        xRotation -= z;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up * x * speed * Time.deltaTime);
    }
    void Update()
    {
        MoveMouse();
    }
}
