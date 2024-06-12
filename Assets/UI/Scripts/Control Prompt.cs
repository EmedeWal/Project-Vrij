using UnityEngine;

public class ControlPrompt : MonoBehaviour
{
    [Header("VARIABLES")]
    [SerializeField] private float _displayTime = 5f;

    private void Start()
    {
        Invoke(nameof(DisableElements), _displayTime);
    }

    private void DisableElements()
    {
        Destroy(gameObject);
    }
}
