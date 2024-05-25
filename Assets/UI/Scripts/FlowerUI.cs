using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class FlowerUI : MonoBehaviour
{
    [SerializeField] private GameObject[] _elements;

    private void Start()
    {
        DisableElements();
    }

    private void OnEnable()
    {
        Flower.FlowerCollected += BackpackUI_FlowerCollected;
    }

    private void OnDisable()
    {
        Flower.FlowerCollected -= BackpackUI_FlowerCollected;
    }

    private void BackpackUI_FlowerCollected(FlowerType flowerType)
    {
        switch (flowerType)
        {
            case FlowerType.Love:
                LoveFlowerCollected();
                break;

            case FlowerType.Fear:
                FearFlowerCollected();
                break;

            case FlowerType.Loneliness:
                LonelinessFlowerCollected();
                break;

            case FlowerType.Joy:
                JoyFlowerCollected();
                break;
        }
    }

    protected virtual void LoveFlowerCollected()
    {
        EnableElement(0);
    }

    protected virtual void FearFlowerCollected()
    {
        EnableElement(1);
    }

    protected virtual void LonelinessFlowerCollected()
    {
        EnableElement(2);
    }

    protected virtual void JoyFlowerCollected()
    {
        EnableElement(3);
    }

    protected void DisableElements()
    {
        foreach (var icon in _elements)
        {
            icon.SetActive(false);
        }
    }

    protected void EnableElement(int position)
    {
        _elements[position].SetActive(true);
    }
}
