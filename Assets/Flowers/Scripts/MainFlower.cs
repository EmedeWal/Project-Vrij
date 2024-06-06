using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainFlower : DialogueSystem
{
    [Header("FLOWER TYPE")]
    [SerializeField] private FlowerType _flowerType;

    [Header("FLOWER PETALS")]
    [SerializeField] private GameObject[] _petals;

    [Header("FLOWER UNIQUE RESPONSES")]
    [SerializeField] private string[] _loveFlowerMessages;
    [Space]
    [SerializeField] private string[] _joyFlowerMessages;
    [Space]
    [SerializeField] private string[] _prideFlowerMessages;
    [Space]
    [SerializeField] private string[] _fearFlowerMessages;
    [Space]
    [SerializeField] private string[] _sadnessFlowerMessages;
    [Space]
    [SerializeField] private string[] _angerFlowerMessages;

    [Header("FINAL DIALOGUE")]
    [SerializeField] private string[] _finalDialogueMessages;

    private List<FlowerType> _collectedFlowers = new List<FlowerType>();

    private void Start()
    {
        foreach (var item in _petals) item.SetActive(false);
    }

    private void HandleFlowerCollection(FlowerType flowerType)
    {
        switch (flowerType)
        {
            case FlowerType.None:
                break;

            case FlowerType.Love:
                CollectFlower(flowerType, 0, _loveFlowerMessages);
                break;

            case FlowerType.Joy:
                CollectFlower(flowerType, 1, _joyFlowerMessages);
                break;

            case FlowerType.Pride:
                CollectFlower(flowerType, 2, _prideFlowerMessages);
                break;

            case FlowerType.Fear:
                CollectFlower(flowerType, 3, _fearFlowerMessages);
                break;

            case FlowerType.Sadness:
                CollectFlower(flowerType, 4, _sadnessFlowerMessages);
                break;

            case FlowerType.Anger:
                CollectFlower(flowerType, 5, _angerFlowerMessages);
                break;
        }
    }

    private void CollectFlower(FlowerType flowerType, int petalIndex, string[] dialogueMessages)
    {
        _collectedFlowers.Add(flowerType);
        _petals[petalIndex].SetActive(true);
        SwapDialogueMessages(dialogueMessages);
    }

    protected override void PlayerEntered()
    {
        if (GameManager.Instance.GetGameState() == GameManager.GameState.Beginning)
        {
            GameManager.Instance.SetGameState(GameManager.GameState.Middle);
            StartDialogue(_flowerType);
        }
        else if (!PlayerInventory.Instance.FlowerTypeIsNone())
        {
            HandleFlowerCollection(PlayerInventory.Instance.GetFlowerType());
            PlayerInventory.Instance.SetFlowerType(FlowerType.None);
            StartDialogue(_flowerType);
        }
    }

    protected override void EndDialogue()
    {
        base.EndDialogue();

        if (_collectedFlowers.Count == 6)
        {
            if (GameManager.Instance.GetGameState() == GameManager.GameState.End)
            {
                SceneManager.LoadScene("End Screen");
                return;
            }
            else
            {
                GameManager.Instance.SetGameState(GameManager.GameState.End);
            }

            SwapDialogueMessages(_finalDialogueMessages);
            StartDialogue(_flowerType);
        }
    }
}
