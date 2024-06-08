using UnityEngine;

public abstract class DialogueSystem : PlayerTrigger
{
    [Header("ACTOR NAME")]
    [SerializeField] private string _name;

    [Header("ACTOR DIALOGUE")]
    [SerializeField] private Dialogue _dialogue;

    protected override void PlayerEntered()
    {
        StartDialogue();
    }

    public virtual void StartDialogue()
    {
        DialogueManager.Instance.StartDialogue(_name, _dialogue.RootNode);
    }
}

//public static event Action<FlowerType> DialogueStarted;
//public static event Action<string> DialogueUpdated;
//public static event Action DialogueEnded;

//protected virtual void StartDialogue(FlowerType flowerType)
//{

    
//    OnDialogueUpdated();
//    OnDialogueStarted(flowerType);
//}

//protected virtual void EndDialogue()
//{


//    OnDialogueEnded();
//}

//private void DialogueSystem_DialogueAdvanced()
//{
//    _dialogueIndex++;

//    if (_dialogueIndex < _dialogueMessages.Length)
//    {
//        OnDialogueUpdated();
//    }
//    else
//    {
//        EndDialogue();
//    }
//}

//protected void SwapDialogueMessages(string[] newDialogueMessages)
//{
//    _dialogueMessages = newDialogueMessages;
//    _dialogueIndex = 0;
//    OnDialogueUpdated();
//}

//private void OnDialogueStarted(FlowerType flowerType)
//{
//    DialogueStarted?.Invoke(flowerType);
//}

//private void OnDialogueUpdated()
//{
//    DialogueUpdated?.Invoke(_dialogueMessages[_dialogueIndex]);
//}

//private void OnDialogueEnded()
//{
//    DialogueEnded?.Invoke();
//}