using UnityEngine;

public class PrideFlowerEffect : FlowerEffect
{
    [Header("BLOOM")]
    [SerializeField] private float _bloomIntensity = 2;

    public override void Activate()
    {
        base.Activate();
        GlobalVolumeManager.Instance.SetBloomIntensity(_bloomIntensity);
    }

    public override void Deactivate() 
    { 
        base.Deactivate();
        GlobalVolumeManager.Instance.ResetBloomIntensity();
    }
}