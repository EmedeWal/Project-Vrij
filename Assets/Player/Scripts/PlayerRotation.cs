using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 10;
    private PlayerInputManager _inputManager;
    private float _rotation;


    private void Awake()
    {
        _inputManager = GetComponent<PlayerInputManager>();
    }

    private void OnEnable()
    {
        _inputManager.RotationInput_Value += PlayerRotation_RotationInput;
    }

    private void OnDisable()
    {
        _inputManager.RotationInput_Value -= PlayerRotation_RotationInput;
    }

    private void PlayerRotation_RotationInput(Vector2 rotationInput)
    {
        _rotation = rotationInput.x;
    }

    private void Update()
    {
        // If the player is not pressing the rotation keys, do not execute.
        if (_rotation == 0) return;

        float angle = _rotationSpeed * _rotation * Time.deltaTime * 10;
        Quaternion rotation = Quaternion.Euler(0, angle, 0);

        transform.rotation = transform.rotation * rotation;
    }
}
