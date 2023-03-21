using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Vector2 moveInput = Vector2.zero;

    private Animator animator;
    private PlayerMovement player;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
        player = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        
    }
    public void OnMove(InputAction.CallbackContext moveContext)
    {
        moveInput = moveContext.ReadValue<Vector2>();
    }

    public void OnUse(InputAction.CallbackContext ctx)
    {
        if(ctx.phase == InputActionPhase.Started)
        {
            Debug.Log("use");
            player.OnUse();
        }
    }

    public Vector2 GetMoveInput()
    {
        return moveInput;
    }
}
