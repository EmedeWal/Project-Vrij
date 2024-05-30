using UnityEngine;

public class BackpackUI : MonoBehaviour
{
    [SerializeField] private GameObject[] _flowerIcons;

    private void OnEnable()
    {
        PlayerInventory.FlowerSet += BackpackUI_FlowerSet;
    }

    private void OnDisable()
    {
        PlayerInventory.FlowerSet -= BackpackUI_FlowerSet;
    }

    private void BackpackUI_FlowerSet(FlowerType flowerType)
    {
        switch (flowerType)
        {
            case FlowerType.None:
                DisableIcons(); 
                break;

            case FlowerType.Love:
                EnableIcon(0);
                break;

            case FlowerType.Joy:
                EnableIcon(1);
                break;

            case FlowerType.Pride:
                EnableIcon(2);
                break;

            case FlowerType.Fear:
                EnableIcon(3);
                break;

            case FlowerType.Sadness:
                EnableIcon(4);
                break;

            case FlowerType.Anger:
                EnableIcon(5);
                break;
        }
    }

    private void EnableIcon(int position)
    {
        DisableIcons();

        _flowerIcons[position].SetActive(true);
    }

    private void DisableIcons()
    {
        foreach (var icon in _flowerIcons)
        {
            icon.SetActive(false);
        }
    }
}


