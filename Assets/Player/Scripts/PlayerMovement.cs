using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private PlayerInputManager _inputManager;

    [SerializeField] private float _movementSpeed = 15;

    [Header("Higher value results in more movement smoothing")]
    [SerializeField] private float _smoothTime = 10;
    private float _movementValue;
    private float _smoothMovement;
    private float _smoothVelocity;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _inputManager = GetComponent<PlayerInputManager>();
    }

    private void OnEnable()
    {
        _inputManager.MovementInput_Value += PlayerMovement_MoveInputPerformed;
    }

    private void OnDisable()
    {
        _inputManager.MovementInput_Value -= PlayerMovement_MoveInputPerformed;
    }

    private void Update()
    {
        Move();
    }

    private void PlayerMovement_MoveInputPerformed(Vector2 movementValue)
    {
        StoreInput(movementValue);
    }

    private void StoreInput(Vector2 movementValue)
    {
        _movementValue = movementValue.y;
    }

    private void Move()
    {
        float targetMovement = _movementValue * _movementSpeed;
        _smoothMovement = Mathf.SmoothDamp(_smoothMovement, targetMovement, ref _smoothVelocity, _smoothTime * Time.deltaTime);

        _characterController.Move(_smoothMovement * Time.deltaTime * transform.forward);
    }
}
