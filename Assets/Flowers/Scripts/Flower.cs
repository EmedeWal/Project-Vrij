using UnityEngine;

public class Flower : Actor
{
    [Header("FLOWER RELATED")]
    [SerializeField] private FlowerType _flowerType;

    public delegate void Flower_UpdateFlowerType(FlowerType flowerType);
    public static event Flower_UpdateFlowerType UpdateFlowerType;

    protected override void PlayerEntered()
    {
        if (PlayerInventory.Instance.FlowerTypeIsNone() && GameManager.Instance.GetGameState() != GameManager.GameState.Beginning)
        {
            Flower_DialogueStarted();
        }
    }

    private void Flower_DialogueStarted()
    {
        DialogueManager.Instance.DialogueEnded += Flower_DialogueEnded;
        StartDialogue(_flowerType);
    }

    private void Flower_DialogueEnded()
    {
        DialogueManager.Instance.DialogueEnded -= Flower_DialogueEnded;
        FlowerPortraitUI.Instance.DisableAllPortraits();
        OnUpdateFlowerType();
        Destroy(gameObject);
    }

    private void OnUpdateFlowerType()
    {
        UpdateFlowerType?.Invoke(_flowerType);
    }
}
