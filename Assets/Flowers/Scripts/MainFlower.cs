using UnityEngine;
using UnityEngine.SceneManagement;

public class MainFlower : DialogueSystem
{
    [Header("FLOWER UNIQUE RESPONSES")]
    [SerializeField] private string[] _loveFlowerMessages;
    [SerializeField] private string[] _joyFlowerMessages;
    [SerializeField] private string[] _prideFlowerMessages;
    [SerializeField] private string[] _fearFlowerMessages;
    [SerializeField] private string[] _sadnessFlowerMessages;
    [SerializeField] private string[] _angerFlowerMessages;

    [Header("FINAL DIALOGUE")]
    [SerializeField] private string[] _finalDialogueMessages;

    private int _encounters = 0;

    private void OnEnable()
    {
        Flower.UpdateFlowerType += MainFlower_UpdateFlowerType;
    }

    private void OnDisable()
    {
        Flower.UpdateFlowerType -= MainFlower_UpdateFlowerType;
    }

    private void MainFlower_UpdateFlowerType(FlowerType flowerType)
    {
        switch (flowerType)
        {
            case FlowerType.None:
                break;

            case FlowerType.Love:
                SwapDialogueMessages(_loveFlowerMessages);
                break;

            case FlowerType.Joy:
                SwapDialogueMessages(_joyFlowerMessages);
                break;

            case FlowerType.Pride:
                SwapDialogueMessages(_prideFlowerMessages);
                break;

            case FlowerType.Fear:
                SwapDialogueMessages(_fearFlowerMessages);
                break;

            case FlowerType.Sadness:
                SwapDialogueMessages(_sadnessFlowerMessages);
                break;

            case FlowerType.Anger:
                SwapDialogueMessages(_angerFlowerMessages);
                break;
        }
    }

    protected override void PlayerEntered()
    {
        if (_encounters == 0)
        {
            _encounters++;
            StartDialogue();
        }
        else if (!PlayerInventory.Instance.FlowerTypeIsNone())
        {
            _encounters++;
            StartDialogue();
            PlayerInventory.Instance.SetFlowerType(FlowerType.None);
        }
    }

    protected override void EndDialogue()
    {
        base.EndDialogue();

        if (_encounters == 8)
        {
            SceneManager.LoadScene("End Screen");
        }

        if (_encounters == 7)
        {
            _encounters++;
            SwapDialogueMessages(_finalDialogueMessages);
            StartDialogue();
        }
    }
}
