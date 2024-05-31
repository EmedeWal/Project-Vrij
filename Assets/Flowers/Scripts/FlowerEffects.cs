using UnityEngine;

public class FlowerEffects : MonoBehaviour
{
    [SerializeField] private GameObject[] _effects;

    private void Start()
    {
        DisableEffects();
    }

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
                EnableEffect(0);
                break;

            case FlowerType.Joy:

                break;

            case FlowerType.Pride:

                break;

            case FlowerType.Fear:

                break;

            case FlowerType.Sadness:
                EnableEffect(1);
                break;

            case FlowerType.Anger:

                break;
        }
    }

    private void EnableEffect(int position)
    {
        DisableEffects();

        _effects[position].SetActive(true);
    }

    private void DisableEffects()
    {
        foreach (var icon in _effects)
        {
            icon.SetActive(false);
        }
    }
}
