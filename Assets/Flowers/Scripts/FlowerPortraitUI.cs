using UnityEngine;

public class FlowerPortraitUI : MonoBehaviour
{
    #region Singleton
    public static FlowerPortraitUI Instance;

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

        DisableAllPortraits();
    }
    #endregion

    [Header("FLOWER PORTRAITS")]
    [SerializeField] private GameObject[] _flowerPortraits;

    public void EnableFlowerPortrait(FlowerType flowerType)
    {
        switch (flowerType)
        {
            case FlowerType.None:
                DisableAllPortraits();
                break;

            case FlowerType.Love:
                EnablePortraitAtPosition(0);
                break;

            case FlowerType.Joy:
                EnablePortraitAtPosition(1);
                break;

            case FlowerType.Pride:
                EnablePortraitAtPosition(2);
                break;

            case FlowerType.Fear:
                EnablePortraitAtPosition(3);
                break;

            case FlowerType.Sadness:
                EnablePortraitAtPosition(4);
                break;

            case FlowerType.Anger:
                EnablePortraitAtPosition(5);
                break;

            case FlowerType.Main:
                EnablePortraitAtPosition(6);
                break;
        }
    }

    private void EnablePortraitAtPosition(int position)
    {
        DisableAllPortraits();

        _flowerPortraits[position].SetActive(true);
    }

    public void DisableAllPortraits()
    {
        foreach (var icon in _flowerPortraits)
        {
            icon.SetActive(false);
        }
    }
}
