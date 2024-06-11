using DigitalRuby.RainMaker;
using UnityEngine;

public class SadnessFlowerEffect : FlowerEffect
{
    [Header("SCREEN")]
    [SerializeField] private GameObject _rainEffect;

    public override void Activate()
    {
        base.Activate();
        _rainEffect.GetComponent<RainScript2D>().RainIntensity = 1f;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _rainEffect.GetComponent<RainScript2D>().RainIntensity = 0f;
    }
}
