using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class PlayerInputManager : MonoBehaviour
{
    public event Action MouseClickInputPerformed;
    public event Action MouseClickInputCanceled;

    public static event Action PauseGameInputPerformed;

    public void OnMouseClickInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MouseClickInputPerformed?.Invoke();
        }
        else if (context.canceled)
        {
            MouseClickInputCanceled?.Invoke();
        }
    }

    public void OnPauseGameInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PauseGameInputPerformed?.Invoke();
        }
    }
}
