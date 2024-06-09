using UnityEngine;

public class LoveFlowerEffect : FlowerEffect
{
    [Header("SCREEN")]
    [SerializeField] private GameObject _screenOverlay;

    public override void Activate()
    {
        base.Activate();
        _screenOverlay.SetActive(true);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _screenOverlay.SetActive(false);
    }
}
