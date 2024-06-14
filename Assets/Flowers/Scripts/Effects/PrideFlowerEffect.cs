using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class PrideFlowerEffect : FlowerEffect
{
    [Header("BLOOM")]
    [SerializeField] PostProcessVolume _postProcessVolume;
    [SerializeField] private float _bloomIntensity = 25f;
    private Bloom _bloom;

    private void Awake()
    {
        _postProcessVolume.profile.TryGetSettings(out _bloom);
    }

    public override void Activate()
    {
        base.Activate();
        _bloom.intensity.value = _bloomIntensity;
    }

    public override void Deactivate() 
    { 
        base.Deactivate();
        _bloom.intensity.value = 0;
    }
}