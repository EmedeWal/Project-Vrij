using UnityEngine;

public class FPMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private PlayerManager _playerManager;

    [Header("VARIABLES")]
    [SerializeField] private float _movementSpeed = 10;
    private Vector3 _movementDirection;
    private float horizontalInput;
    private float verticalInput;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerManager = GetComponent<PlayerManager>();
    }

    private void OnEnable()
    {
        _playerManager.MovementInputValue += PlayerMovement_MovementInputValue;
    }

    private void OnDisable()
    {
        _playerManager.MovementInputValue -= PlayerMovement_MovementInputValue;
    }
    private void Update()
    {
        CalculateMoveDirection();
        Move();
    }

    private void PlayerMovement_MovementInputValue(Vector2 movement)
    {
        horizontalInput = movement.x;
        verticalInput = movement.y;
    }

    private void CalculateMoveDirection()
    {
        _movementDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        _movementDirection = _movementDirection.normalized;
    }

    private void Move()
    {
        _characterController.Move(_movementSpeed * Time.deltaTime * _movementDirection);
    }
}
