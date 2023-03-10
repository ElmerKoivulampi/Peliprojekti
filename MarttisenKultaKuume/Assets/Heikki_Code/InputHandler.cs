using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Vector2 moveInput = Vector2.zero;
    public void OnMove(InputAction.CallbackContext moveContext)
    {
        moveInput = moveContext.ReadValue<Vector2>();
    }

    public void OnUse()
    {
        Debug.Log("use");
    }

    public Vector2 GetMoveInput()
    {
        return moveInput;
    }
}
