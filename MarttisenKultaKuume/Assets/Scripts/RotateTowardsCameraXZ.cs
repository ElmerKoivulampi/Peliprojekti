using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsCameraXZ : MonoBehaviour
{
    Camera cam;
    void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 dir = transform.position - cam.transform.position + cam.transform.forward * 5.0f;
        dir.y = 0.0f;
        transform.LookAt(transform.position + dir);
    }
}
