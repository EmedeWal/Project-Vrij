using DigitalRuby.RainMaker;
using UnityEngine;

public class SadnessFlowerEffect : FlowerEffect
{
    [Header("SCREEN")]
    [SerializeField] private GameObject _rainEffect;
    [SerializeField] private float _saturationValue = -100;

    public override void Activate()
    {
        base.Activate();
        _rainEffect.GetComponent<RainScript2D>().RainIntensity = 1f;
        GlobalVolumeManager.Instance.SetSaturationValue(_saturationValue);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _rainEffect.GetComponent<RainScript2D>().RainIntensity = 0f;
        GlobalVolumeManager.Instance.ResetSaturationValue();
    }
}
