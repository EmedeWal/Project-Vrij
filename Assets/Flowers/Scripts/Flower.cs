using UnityEngine;

public class Flower : DialogueSystem
{
    [Header("FLOWER RELATED")]
    [SerializeField] private FlowerType _flowerType;

    public delegate void Flower_UpdateFlowerType(FlowerType flowerType);
    public static event Flower_UpdateFlowerType UpdateFlowerType;

    protected override void PlayerEntered()
    {
        if (PlayerInventory.Instance.FlowerTypeIsNone())
        { 
            StartDialogue();
        }
    }

    protected override void EndDialogue()
    { 
        Time.timeScale = 1;
        CloseDialogueBox();
        OnUpdateFlowerType();
        Destroy(gameObject);
    }

    private void OnUpdateFlowerType()
    {
        UpdateFlowerType?.Invoke(_flowerType);
    }
}
