using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerManager : MonoBehaviour
{
    public event Action<Vector2> MovementInput;
    public event Action<Vector2> RotationInput;

    public void OnMovementInput(InputAction.CallbackContext context)
    {
        MovementInput?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnRotationInput(InputAction.CallbackContext context)
    {
        RotationInput?.Invoke(context.ReadValue<Vector2>());
    }
}
