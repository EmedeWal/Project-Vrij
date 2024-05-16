using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerInputManager : MonoBehaviour
{
    public event Action<Vector2> MovementInputValue;
    public event Action<Vector2> RotationInput;

    public void OnMovementInput(InputAction.CallbackContext context)
    {
        MovementInputValue?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnRotationInput(InputAction.CallbackContext context)
    {
        RotationInput?.Invoke(context.ReadValue<Vector2>());
    }
}
