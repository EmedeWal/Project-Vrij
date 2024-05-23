using UnityEngine;

public class PlayerSnapRotation : MonoBehaviour
{
    private PlayerInputManager _inputManager;

    private void Awake()
    {
        _inputManager = GetComponent<PlayerInputManager>();
    }

    private void OnEnable()
    {
        _inputManager.SnapRotationInput_Value += PlayerSnapRotation_SnapRotationInput_Value;
    }

    private void OnDisable()
    {
        _inputManager.SnapRotationInput_Value -= PlayerSnapRotation_SnapRotationInput_Value;
    }

    private void PlayerSnapRotation_SnapRotationInput_Value(float inputValue)
    {
        if (inputValue < 0)
        {
            AdjustRotation(-90);
        }
        else
        {
            AdjustRotation(90);
        }
    }


    private void AdjustRotation(float yRotation)
    {
        Quaternion newRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + yRotation, 0);
        transform.rotation = newRotation;
    }
}
