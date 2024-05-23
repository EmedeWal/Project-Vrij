using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerInputManager : MonoBehaviour
{
    public event Action<Vector2> MovementInput_Value;

    public event Action<Vector2> RotationInput_Value;

    public event Action<float> SnapRotationInput_Value;

    public event Action InventoryInput_Performed;

    public void OnMovementInput(InputAction.CallbackContext context)
    {
        MovementInput_Value?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnRotationInput(InputAction.CallbackContext context)
    {
        RotationInput_Value?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnSnapRotationInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SnapRotationInput_Value?.Invoke(context.ReadValue<float>());
        }
    }

    public void OnInventoryInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            InventoryInput_Performed?.Invoke();
        }
    }
}
