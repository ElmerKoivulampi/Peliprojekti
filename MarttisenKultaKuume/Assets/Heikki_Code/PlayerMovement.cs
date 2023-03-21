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

    private IUsableObject lastUsableObject = null;
    void Awake()
    {
        rigBod = GetComponent<Rigidbody>();
        input = GetComponent<InputHandler>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        UpdateAnimator(rigBod.velocity);
    }

    void FixedUpdate()
    {
        rigBod.velocity = new Vector3(input.GetMoveInput().x, 0.0f, input.GetMoveInput().y) * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        lastUsableObject = other.GetComponent<IUsableObject>();
    }

    void OnTriggerExit(Collider other)
    {
        lastUsableObject = null;
    }

    public void OnUse()
    {
        if(lastUsableObject == null)
            return;

        lastUsableObject.Use();
    }

    private void UpdateAnimator(Vector3 movement)
    {
        animator.SetFloat(AnimatorX, movement.x);
        animator.SetFloat(AnimatorZ, movement.z);
        animator.SetFloat(AnimatorSpeed, rigBod.velocity.magnitude);
    }
}
