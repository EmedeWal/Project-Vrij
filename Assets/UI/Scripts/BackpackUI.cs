using UnityEngine;

public class BackpackUI : MonoBehaviour
{
    [SerializeField] private GameObject _holder;
    [SerializeField] private GameObject[] _icons;

    private void Start()
    {
        ManageHolder(false);
        DisableIcons();
    }

    private void OnEnable()
    {
        Pickup.PickupCollected += BackpackUI_PickupCollected;
        PlayerInventory.OpenInventory += BackpackUI_OpenInventory;
        PlayerInventory.CloseInventory += BackpackUI_CloseInventory;
    }

    private void OnDisable()
    {
        Pickup.PickupCollected -= BackpackUI_PickupCollected;
        PlayerInventory.OpenInventory -= BackpackUI_OpenInventory;
        PlayerInventory.CloseInventory -= BackpackUI_CloseInventory;
    }

    private void BackpackUI_PickupCollected(PickupType pickupType)
    {
        switch (pickupType)
        {
            case PickupType.Blue:
                EnableIcon(0);
                break;

            case PickupType.Cyan:
                EnableIcon(1);
                break;

            case PickupType.Green:
                EnableIcon(2);
                break;

            case PickupType.LightGreen:
                EnableIcon(3);
                break;

            case PickupType.Orange:
                EnableIcon(4);
                break;

            case PickupType.Pink:
                EnableIcon(5);
                break;

            case PickupType.Purple:
                EnableIcon(6);
                break;

            case PickupType.Red:
                EnableIcon(7);
                break;

            case PickupType.Yellow:
                EnableIcon(8);
                break;
        }
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

    private void DisableIcons()
    {
        foreach (var icon in _icons)
        {
            icon.SetActive(false);
        }
    }

    private void EnableIcon(int position)
    {
        _icons[position].SetActive(true);
    }
}


