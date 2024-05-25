using UnityEngine;

public class BackpackUI : FlowerUI
{
    [SerializeField] private GameObject _holder;

    private void Awake()
    {
        ManageHolder(false);
    }

    private void OnEnable()
    {
        PlayerInventory.OpenInventory += BackpackUI_OpenInventory;
        PlayerInventory.CloseInventory += BackpackUI_CloseInventory;
    }

    private void OnDisable()
    {
        PlayerInventory.OpenInventory -= BackpackUI_OpenInventory;
        PlayerInventory.CloseInventory -= BackpackUI_CloseInventory;
    }

    private void BackpackUI_OpenInventory()
    {
        ManageHolder(true);
    }

    private void BackpackUI_CloseInventory()
    {
        ManageHolder(false);
    }

    private void ManageHolder(bool active)
    {
        _holder.SetActive(active);
    }
}


