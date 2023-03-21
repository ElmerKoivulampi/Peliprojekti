using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokiObject : MonoBehaviour
{
    private Vector3 startPos;
    [SerializeField] private Vector3 floatSpeed = Vector3.zero;
    private Rigidbody rb;
    private float lifeTimeInDistance = 0.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    public void SetFloatSpeed(Vector3 speed)
    {
        floatSpeed = speed;
    }

    public void SetLifetime(float life)
    {
        lifeTimeInDistance = life;
    }
    private void Update()
    {
        rb.velocity = floatSpeed;
        if(Vector3.Distance(transform.position, startPos) >= lifeTimeInDistance)
        {
            Destroy(gameObject);
        }
    }
}
