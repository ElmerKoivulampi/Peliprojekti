using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokiObject : MonoBehaviour
{
    [SerializeField] private Vector3 floatSpeed = Vector3.zero;

    public void SetFloatSpeed(Vector3 speed)
    {
        floatSpeed = speed;
    }
    private void Update()
    {
        transform.position += floatSpeed * Time.deltaTime;
    }
}
