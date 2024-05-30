using TMPro;
using UnityEngine;

public abstract class DialogueSystem : PlayerTrigger
{
    [Header("DIALOGUE RELATED")]
    [SerializeField] private GameObject _dialogueBox;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private string[] _dialogueMessages;
    private int _dialogueIndex = 0;

    private void Awake()
    {
        CloseDialogueBox();
        UpdateDialogue();
    }

    protected virtual void StartDialogue()
    {
        Time.timeScale = 0;
        OpenDialogueBox();
    }

    protected virtual void EndDialogue()
    {
        Time.timeScale = 1; 
        CloseDialogueBox();
    }

    protected void OpenDialogueBox()
    {
        _dialogueBox.SetActive(true);
    }

    protected void CloseDialogueBox()
    {
        _dialogueBox.SetActive(false);
    }

    private void UpdateDialogue()
    {
        _dialogueText.text = _dialogueMessages[_dialogueIndex];
    }

    public void AdvanceDialogue()
    {
        _dialogueIndex++;

        if (_dialogueIndex < _dialogueMessages.Length)
        {
            UpdateDialogue();
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
        UpdateDialogue();
    }
}
