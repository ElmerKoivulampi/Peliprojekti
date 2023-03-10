using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed = 10.0f;
    Rigidbody rigBod;
    InputHandler input;
    void Awake()
    {
        rigBod = GetComponent<Rigidbody>();
        input = GetComponent<InputHandler>();
    }

    void FixedUpdate()
    {
        rigBod.velocity = new Vector3(input.GetMoveInput().x, 0, input.GetMoveInput().y) * speed;
    }
}
