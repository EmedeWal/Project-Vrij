using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private PlayerManager _playerManager;

    [Header("VARIABLES")]
    [SerializeField] private float _movementSpeed = 15;
    [SerializeField] private float _smoothTime = 0.25f;
    private float _movementValue;
    private float _smoothMovement;
    private float _smoothVelocity;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerManager = GetComponent<PlayerManager>();
    }

    private void OnEnable()
    {
        _playerManager.MovementInputValue += PlayerMovement_MoveInputPerformed;
    }

    private void OnDisable()
    {
        _playerManager.MovementInputValue -= PlayerMovement_MoveInputPerformed;
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
        _smoothMovement = Mathf.SmoothDamp(_smoothMovement, targetMovement, ref _smoothVelocity, _smoothTime);

        _characterController.Move(_smoothMovement * Time.deltaTime * transform.forward);
    }
}
