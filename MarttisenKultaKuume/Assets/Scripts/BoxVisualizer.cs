using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxVisualizer : MonoBehaviour
{
    [SerializeField] float size = 1.0f;
    [SerializeField] Color color = new Color(1.0f, 0.0f, 0.0f, 0.33f);
    void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position, new Vector3(size, size, size));
        Gizmos.color = new Color(color.r, color.g, color.b, 1.0f);
        Gizmos.DrawWireCube(transform.position, new Vector3(size, size, size));
    }
}
