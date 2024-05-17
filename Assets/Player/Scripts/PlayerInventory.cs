using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerInputManager _inputManager;
    private bool _isOpen = false;

    public delegate void PlayerInventory_OpenInventory();
    public static event PlayerInventory_OpenInventory OpenInventory;

    public delegate void PlayerInventory_CloseInventory();
    public static event PlayerInventory_CloseInventory CloseInventory;

    private void Awake()
    {
        _inputManager = GetComponent<PlayerInputManager>();
    }

    private void OnEnable()
    {
        _inputManager.InventoryInput_Performed += PlayerInventory_InventoryInput_Performed;
    }

    private void OnDisable()
    {
        _inputManager.InventoryInput_Performed -= PlayerInventory_InventoryInput_Performed;
    }

    private void PlayerInventory_InventoryInput_Performed()
    {
        if (_isOpen)
        {
            _isOpen = false;
            OnCloseInventory();
        }
        else
        {
            _isOpen = true;
            OnOpenInventory();
        }
    }

    private void OnOpenInventory()
    {
        OpenInventory?.Invoke();
    }

    private void OnCloseInventory()
    {
        CloseInventory?.Invoke();
    }
}
