using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed = 10.0f;
    private Rigidbody rigBod;
    private InputHandler input;
    private Animator animator;

    private const string AnimatorX = "Look X";
    private const string AnimatorZ = "Look Z";
    private const string AnimatorSpeed = "Speed";

    void Awake()
    {
        rigBod = GetComponent<Rigidbody>();
        input = GetComponent<InputHandler>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateAnimator(rigBod.velocity);
    }

    void FixedUpdate()
    {
        rigBod.velocity = new Vector3(input.GetMoveInput().x, 0, input.GetMoveInput().y) * speed;
    }

    private void UpdateAnimator(Vector3 movement)
    {
        animator.SetFloat(AnimatorX, movement.x);
        animator.SetFloat(AnimatorZ, movement.z);
        animator.SetFloat(AnimatorSpeed, rigBod.velocity.magnitude);
    }
}
