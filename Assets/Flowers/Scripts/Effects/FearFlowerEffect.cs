using UnityEngine;

public class FearFlowerEffect : FlowerEffect
{
    [Header("SCREEN")]
    [SerializeField] private float _vignetteIntensity = 1;

    public override void Activate()
    {
        base.Activate();
        GlobalVolumeManager.Instance.SetVignetteIntensity(_vignetteIntensity);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        GlobalVolumeManager.Instance.ResetVignetteIntensity();
    }
}
