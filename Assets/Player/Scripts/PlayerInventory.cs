using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    #region Singleton
    public static PlayerInventory Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField] private FlowerType _currentFlower = FlowerType.None;

    public delegate void PlayerInventory_FlowerSet(FlowerType flowerType);
    public static event PlayerInventory_FlowerSet FlowerSet;

    private void Start()
    {
        SetFlowerType(_currentFlower);
    }

    private void OnEnable()
    {
        Flower.UpdateFlowerType += PlayerInventory_UpdateFlowerType;
    }

    private void OnDisable()
    {
        Flower.UpdateFlowerType -= PlayerInventory_UpdateFlowerType;
    }

    private void PlayerInventory_UpdateFlowerType(FlowerType flowerType)
    {
        SetFlowerType(flowerType);
    }

    public void SetFlowerType(FlowerType newFlower)
    {
        _currentFlower = newFlower;
        OnFlowerSet(newFlower);
    }

    public FlowerType GetFlowerType()
    {
        return _currentFlower;
    }

    public bool FlowerTypeIsNone()
    {
        return _currentFlower == FlowerType.None;
    }

    private void OnFlowerSet(FlowerType flowerType)
    {
        FlowerSet?.Invoke(flowerType);
    }
}
