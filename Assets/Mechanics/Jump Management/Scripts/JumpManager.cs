using System;
using UnityEngine;

public class JumpManager : MonoBehaviour
{
    [SerializeField] private GameObject _cubeHolder;

    [Header("VARIABLES")]
    [SerializeField] private bool _active = true;
    [SerializeField] private float _jumpDisableTime = 60f;

    public static event Action DisableJumping;

    private void Start()
    {
        if (_active)
        {
            Invoke(nameof(OnDisableJumping), _jumpDisableTime);
        }
    }

    private void OnDisableJumping()
    {
        _cubeHolder.SetActive(true);
        DisableJumping?.Invoke();
        Destroy(gameObject);
    }
}
