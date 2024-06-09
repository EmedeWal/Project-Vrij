using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class PrideFlowerEffect : FlowerEffect
{
    [Header("SCREEN")]
    [SerializeField] PostProcessVolume _postProcessVolume;
    private Bloom _bloom;

    private void Start()
    {
        _postProcessVolume.profile.TryGetSettings(out _bloom);
    }

    public override void Activate()
    {
        base.Activate();
        _bloom.intensity.value = 10.0f;
    }

    public override void Deactivate() 
    { 
        base.Deactivate();
        _bloom.intensity.value = 0;
    }
}