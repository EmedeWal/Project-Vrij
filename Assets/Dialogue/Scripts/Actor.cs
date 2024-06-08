using UnityEngine;

public abstract class Actor : PlayerTrigger
{
    [Header("ACTOR NAME")]
    [SerializeField] private string _name;

    [Header("ACTOR DIALOGUE")]
    [SerializeField] private Dialogue _dialogue;

    protected virtual void StartDialogue(FlowerType flowerType)
    {
        FlowerPortraitUI.Instance.EnableFlowerPortrait(flowerType);
        DialogueManager.Instance.StartDialogue(_name, _dialogue.RootNode);
    }

    protected void UpdateDialogue(Dialogue dialogue)
    {
        _dialogue = dialogue;
    }
}

