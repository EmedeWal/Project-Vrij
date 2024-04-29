using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    private CharacterController _characterController;
    private PlayerManager _playerManager;

    [Header("VARIABLES")]
    [SerializeField] private float _jumpForce = 15f;
    [SerializeField] private float _gravity = 30f;
    [SerializeField] private float _maxHeight = 75f;
    private Vector3 _velocity;
    private bool _isJumping = false;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerManager = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        ManageVerticalPosition();
    }

    private void OnEnable()
    {
        _playerManager.JumpInputPerformed += PlayerJumping_JumpInputPerformed;
        _playerManager.JumpInputCanceled += PlayerJumping_JumpInputCanceled;
        JumpManager.DisableJumping += DisableJumping;
    }

    private void OnDisable()
    {
        JumpManager.DisableJumping -= DisableJumping;
        DisableJumping();
    }

    private void PlayerJumping_JumpInputPerformed()
    {
        Jump();
    }

    private void PlayerJumping_JumpInputCanceled()
    {
        StopJumping();
    }

    private void Jump()
    {
        _isJumping = true;
        _velocity.y = _jumpForce;
    }

    private void StopJumping()
    {
        _isJumping = false;
    }

    private void ManageVerticalPosition()
    {
        // Prevent the player from ascending above the MaxHeight
        if (transform.position.y >= _maxHeight && _isJumping) return;

        _characterController.Move(_velocity * Time.deltaTime);

        // Only if the player is not ascending, manage gravity.
        if (_isJumping) return;

        _velocity.y -= _gravity * Time.deltaTime;
    }

    public void DisableJumping()
    {
        _playerManager.JumpInputPerformed -= PlayerJumping_JumpInputPerformed;
        _playerManager.JumpInputCanceled -= PlayerJumping_JumpInputCanceled;
        StopJumping();
    }
}
