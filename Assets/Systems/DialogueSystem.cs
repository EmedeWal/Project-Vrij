using UnityEngine;
using System;

public abstract class DialogueSystem : PlayerTrigger
{
    [Header("DIALOGUE RELATED")]
    [SerializeField] private string[] _dialogueMessages;
    private int _dialogueIndex = 0;

    public static event Action<FlowerType> DialogueStarted;
    public static event Action<string> DialogueUpdated;
    public static event Action DialogueEnded;

    protected virtual void StartDialogue(FlowerType flowerType)
    {
        DialogueUI.Instance.DialogueAdvanced += DialogueSystem_DialogueAdvanced;
        Time.timeScale = 0;
        OnDialogueUpdated();
        OnDialogueStarted(flowerType);
    }

    protected virtual void EndDialogue()
    {
        DialogueUI.Instance.DialogueAdvanced -= DialogueSystem_DialogueAdvanced;
        Time.timeScale = 1; 
        OnDialogueEnded();
    }

    private void DialogueSystem_DialogueAdvanced()
    {
        _dialogueIndex++;

        if (_dialogueIndex < _dialogueMessages.Length)
        {
            OnDialogueUpdated();
        }
        else
        {
            EndDialogue();
        }
    }

    protected void SwapDialogueMessages(string[] newDialogueMessages)
    {
        _dialogueMessages = newDialogueMessages;
        _dialogueIndex = 0;
        OnDialogueUpdated();
    }

    private void OnDialogueStarted(FlowerType flowerType)
    {
        DialogueStarted?.Invoke(flowerType);
    }

    private void OnDialogueUpdated()
    {
        DialogueUpdated?.Invoke(_dialogueMessages[_dialogueIndex]);
    }

    private void OnDialogueEnded()
    {
        DialogueEnded?.Invoke();
    }
}
