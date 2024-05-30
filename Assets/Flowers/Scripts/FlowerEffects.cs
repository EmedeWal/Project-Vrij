using UnityEngine;

public class FlowerEffects : MonoBehaviour
{
    [SerializeField] private GameObject[] _flowerIcons;

    private void OnEnable()
    {
        Flower.UpdateFlowerType += FlowerEffects_UpdateFlowerType;
    }

    private void OnDisable()
    {
        Flower.UpdateFlowerType -= FlowerEffects_UpdateFlowerType;
    }

    private void FlowerEffects_UpdateFlowerType(FlowerType flowerType)
    {
        switch (flowerType)
        {
            case FlowerType.None:
                
                break;

            case FlowerType.Love:

                break;

            case FlowerType.Joy:

                break;

            case FlowerType.Pride:

                break;

            case FlowerType.Fear:

                break;

            case FlowerType.Sadness:

                break;

            case FlowerType.Anger:

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
