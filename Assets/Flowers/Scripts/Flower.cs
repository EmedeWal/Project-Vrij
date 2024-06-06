using UnityEngine;

public class Flower : DialogueSystem
{
    [Header("FLOWER RELATED")]
    [SerializeField] private FlowerType _flowerType;

    public delegate void Flower_UpdateFlowerType(FlowerType flowerType);
    public static event Flower_UpdateFlowerType UpdateFlowerType;

    protected override void PlayerEntered()
    {
        if (PlayerInventory.Instance.FlowerTypeIsNone() && GameManager.Instance.GetGameState() != GameManager.GameState.Beginning)
        { 
            StartDialogue(_flowerType);
        }
    }

    protected override void EndDialogue()
    { 
        base.EndDialogue();
        OnUpdateFlowerType();
        Destroy(gameObject);
    }

    private void OnUpdateFlowerType()
    {
        UpdateFlowerType?.Invoke(_flowerType);
    }
}
