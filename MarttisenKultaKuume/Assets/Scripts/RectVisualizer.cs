using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectVisualizer : MonoBehaviour
{
    [SerializeField] Vector3 size = Vector3.one;
    [SerializeField] Color color = new Color(1.0f, 0.0f, 0.0f, 0.33f);
    void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position, size);
        Gizmos.color = new Color(color.r, color.g, color.b, 1.0f);
        Gizmos.DrawWireCube(transform.position, size);
    }
}
