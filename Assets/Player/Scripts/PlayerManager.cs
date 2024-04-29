using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerManager : MonoBehaviour
{
    public event Action<Vector2> MovementInputValue;
    public event Action<Vector2> RotationInput;
    public event Action<Vector2> RotationInputValue;

    public event Action JumpInputPerformed;
    public event Action JumpInputCanceled;

    public void OnMovementInput(InputAction.CallbackContext context)
    {
        MovementInputValue?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnRotationInput(InputAction.CallbackContext context)
    {
        RotationInput?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnMouseDeltaInput(InputAction.CallbackContext context)
    {
        RotationInputValue?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.performed) JumpInputPerformed?.Invoke();
        if (context.canceled) JumpInputCanceled?.Invoke();
    }
}
