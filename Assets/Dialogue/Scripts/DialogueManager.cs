using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    #region Instance
    public static DialogueManager Instance { get; private set; }

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

        HideDialogue();
    }
    #endregion

    [Header("DIALOGUE UI")]
    [SerializeField] private GameObject _dialogueParent;
    [SerializeField] private TextMeshProUGUI _dialogueNameText, _dialogueMessageText;

    [Header("RESPONSE UI")]
    [SerializeField] private Transform _responseButtonParent;
    [SerializeField] private GameObject _responseButtonPrefab;

    // Events
    public event Action DialogueStarted;
    public event Action DialogueEnded;

    // Starts the dialogue with given title and dialogue node
    public void StartDialogue(string title, DialogueNode node)
    {
        ShowDialogue();
        OnDialogueStarted();

        // Set dialogue title and body text
        _dialogueNameText.text = title;
        _dialogueMessageText.text = node.dialogueText;

        // Remove any existing response buttons
        foreach (Transform child in _responseButtonParent)
        {
            Destroy(child.gameObject);
        }

        // Create and setup response buttons based on current dialogue node
        foreach (DialogueResponse response in node.responses)
        {
            GameObject buttonObj = Instantiate(_responseButtonPrefab, _responseButtonParent);
            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = response.responseText;

            // Setup button to trigger SelectResponse when clicked
            buttonObj.GetComponent<Button>().onClick.AddListener(() => SelectResponse(response, title));
        }
    }

    // Handles response selection and triggers next dialogue node
    public void SelectResponse(DialogueResponse response, string title)
    {
        // Check if there's a follow-up node
        if (!response.nextNode.IsLastNode())
        {
            StartDialogue(title, response.nextNode); 
        }
        else
        {
            HideDialogue();
            OnDialogueEnded();
        }
    }

    private void HideDialogue()
    {
        Time.timeScale = 1;
        _dialogueParent.SetActive(false);
    }

    private void ShowDialogue()
    {
        Time.timeScale = 0;
        _dialogueParent.SetActive(true);
    }

    private void OnDialogueStarted()
    {
        DialogueStarted?.Invoke();  
    }

    private void OnDialogueEnded()
    {
        DialogueEnded?.Invoke();
    }
}