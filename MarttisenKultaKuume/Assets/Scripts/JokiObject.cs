using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokiObject : MonoBehaviour
{
    [SerializeField] private Vector3 floatSpeed = Vector3.zero;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void SetFloatSpeed(Vector3 speed)
    {
        floatSpeed = speed;
    }
    private void Update()
    {
        rb.velocity = floatSpeed;
        //transform.position += floatSpeed * Time.deltaTime;
    }
}
