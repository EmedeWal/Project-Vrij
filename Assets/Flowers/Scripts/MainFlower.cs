using System.Collections.Generic;
using UnityEngine;

public class MainFlower : Actor
{
    [Header("FLOWER TYPE")]
    [SerializeField] private FlowerType _flowerType;

    [Header("FLOWER PETALS")]
    [SerializeField] private GameObject[] _petals;

    [Header("FLOWER UNIQUE DIALOGUE")]
    [SerializeField] private Dialogue[] _dialogues;

    [Header("FINAL DIALOGUE")]
    [SerializeField] private Dialogue _finalDialogue;

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
                CollectFlower(flowerType, 0, _dialogues[0]);
                break;

            case FlowerType.Joy:
                CollectFlower(flowerType, 1, _dialogues[1]);
                break;

            case FlowerType.Pride:
                CollectFlower(flowerType, 2, _dialogues[2]);
                break;

            case FlowerType.Fear:
                CollectFlower(flowerType, 3, _dialogues[3]);
                break;

            case FlowerType.Sadness:
                CollectFlower(flowerType, 4, _dialogues[4]);
                break;

            case FlowerType.Anger:
                CollectFlower(flowerType, 5, _dialogues[5]);
                break;
        }
    }

    private void CollectFlower(FlowerType flowerType, int petalIndex, Dialogue dialogue)
    {
        _collectedFlowers.Add(flowerType);
        _petals[petalIndex].SetActive(true);
        UpdateDialogue(dialogue);
    }

    protected override void PlayerEntered()
    {
        if (GameManager.Instance.GetGameState() == GameManager.GameState.Beginning)
        {
            GameManager.Instance.SetGameState(GameManager.GameState.Middle);
            MainFlower_DialogueStarted();
        }
        else if (!PlayerInventory.Instance.FlowerTypeIsNone())
        {
            HandleFlowerCollection(PlayerInventory.Instance.GetFlowerType());
            PlayerInventory.Instance.SetFlowerType(FlowerType.None);
            MainFlower_DialogueStarted();
        }
    }

    private void MainFlower_DialogueStarted()
    {
        DialogueManager.Instance.DialogueEnded += MainFlower_DialogueEnded;
        StartDialogue(_flowerType);
    }

    private void MainFlower_DialogueEnded()
    {
        FlowerPortraitUI.Instance.DisableAllPortraits();
        DialogueManager.Instance.DialogueEnded -= MainFlower_DialogueEnded;

        if (_collectedFlowers.Count == 6)
        {
            if (GameManager.Instance.GetGameState() == GameManager.GameState.End)
            {
                GameManager.Instance.EndGame();
                return;
            }
            else
            {
                GameManager.Instance.SetGameState(GameManager.GameState.End);
            }

            UpdateDialogue(_finalDialogue);
            MainFlower_DialogueStarted();
        }
    }
}
