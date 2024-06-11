using System.Collections.Generic;
using UnityEngine;

public class MainFlower : Actor
{
    [Header("FLOWER TYPE")]
    [SerializeField] private FlowerType _flowerType;

    [Header("PETALS")]
    [SerializeField] private GameObject[] _tornPetals;
    [SerializeField] private GameObject[] _restoredPetals;

    [Header("FLOWER UNIQUE DIALOGUE")]
    [SerializeField] private Dialogue[] _dialogues;

    [Header("FINAL DIALOGUE")]
    [SerializeField] private Dialogue _finalDialogue;

    [Header("FINAL MUSIC")]
    [SerializeField] private AudioClip _finalClip;
    [SerializeField] private float _finalVolume;

    private List<FlowerType> _collectedFlowers = new List<FlowerType>();

    public delegate void MainFlower_FlowerCollected();
    public static event MainFlower_FlowerCollected FlowerCollected;

    private void Awake()
    {
        foreach (var item in _restoredPetals)
        {
            item.SetActive(false);
        }
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
        _restoredPetals[petalIndex].SetActive(true);
        _tornPetals[petalIndex].SetActive(false);
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
            OnFlowerCollected();
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
                AudioManager.Instance.SetNewAudioClip(_finalClip, _finalVolume);
            }

            UpdateDialogue(_finalDialogue);
            MainFlower_DialogueStarted();
        }
    }

    private void OnFlowerCollected()
    {
        FlowerCollected?.Invoke();
    }
}
