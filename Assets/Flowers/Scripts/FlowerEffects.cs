using UnityEngine;

public class FlowerEffects : MonoBehaviour
{
    private FlowerEffect[] _flowerEffects;

    private void Awake()
    {
        _flowerEffects = GetComponentsInChildren<FlowerEffect>();
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
            case FlowerType.Love:
                EnableEffect(0);
                break;

            case FlowerType.Joy:
                EnableEffect(1);
                break;

            case FlowerType.Pride:
                EnableEffect(2);
                break;

            case FlowerType.Fear:
                EnableEffect(3);
                break;

            case FlowerType.Sadness:
                EnableEffect(4);
                break;

            case FlowerType.Anger:
                EnableEffect(5);
                break;
        }
    }

    private void EnableEffect(int position)
    {
        _flowerEffects[position].Activate();
    }

    private void DisableEffects()
    {
        foreach (var effect in _flowerEffects)
        {
            effect.Deactivate();
        }
    }
}
