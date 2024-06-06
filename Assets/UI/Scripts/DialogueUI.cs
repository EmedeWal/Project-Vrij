using UnityEngine;
using TMPro;
using System;

public class DialogueUI : MonoBehaviour
{
    #region Singleton
    public static DialogueUI Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }
    #endregion

    [Header("DIALOGUE REFERENCES")]
    [SerializeField] private GameObject _dialogueBox;
    [SerializeField] private TextMeshProUGUI _dialogueText;

    [Header("FLOWER PORTRAITS")]
    [SerializeField] private GameObject[] _flowerPortraits;

    public event Action DialogueAdvanced;

    private void Start()
    {
        DisablePortraits();
        ManageDialogueBox(false);
    }

    private void OnEnable()
    {
        DialogueSystem.DialogueStarted += DialogueUI_DialogueStarted;
        DialogueSystem.DialogueUpdated += DialogueUI_DialogueUpdated;
        DialogueSystem.DialogueEnded += DialogueUI_DialogueEnded;
    }

    private void OnDisable()
    {
        DialogueSystem.DialogueStarted -= DialogueUI_DialogueStarted;
        DialogueSystem.DialogueUpdated -= DialogueUI_DialogueUpdated;
        DialogueSystem.DialogueEnded -= DialogueUI_DialogueEnded;
    }

    public void AdvanceDialogue()
    {
        OnDialogueAdvanced();
    }

    private void DialogueUI_DialogueStarted(FlowerType flowerType)
    {
        ManageDialogueBox(true);

        switch (flowerType)
        {
            case FlowerType.None:
                DisablePortraits();
                break;

            case FlowerType.Love:
                EnablePortrait(0);
                break;

            case FlowerType.Joy:
                EnablePortrait(1);
                break;

            case FlowerType.Pride:
                EnablePortrait(2);
                break;

            case FlowerType.Fear:
                EnablePortrait(3);
                break;

            case FlowerType.Sadness:
                EnablePortrait(4);
                break;

            case FlowerType.Anger:
                EnablePortrait(5);
                break;

            case FlowerType.Main:
                EnablePortrait(6);
                break;
        }
    }

    private void DialogueUI_DialogueUpdated(string message)
    {
        _dialogueText.text = message;
    }

    private void DialogueUI_DialogueEnded()
    {
        ManageDialogueBox(false);
        DisablePortraits();
    }

    private void OnDialogueAdvanced()
    {
        DialogueAdvanced?.Invoke();
    }

    private void EnablePortrait(int position)
    {
        DisablePortraits();

        _flowerPortraits[position].SetActive(true);
    }

    private void DisablePortraits()
    {
        foreach (var icon in _flowerPortraits)
        {
            icon.SetActive(false);
        }
    }

    private void ManageDialogueBox(bool active)
    {
        _dialogueBox.SetActive(active);
    }
}


