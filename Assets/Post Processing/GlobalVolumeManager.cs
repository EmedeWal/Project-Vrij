using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlobalVolumeManager : MonoBehaviour
{
    #region Singleton
    public static GlobalVolumeManager Instance;

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

        _volume = GetComponent<Volume>();

        if (_volume.profile.TryGet<ColorAdjustments>(out _colorAdjustments))
        {
            _defaultSaturationValue = _colorAdjustments.saturation.value;
        }

        if (_volume.profile.TryGet<Bloom>(out _bloom))
        {
            _defaultBloomIntensity = _bloom.intensity.value;
        }

        if (_volume.profile.TryGet<Vignette>(out _vignette))
        {
            _defaultVignetteIntensity = _vignette.intensity.value;
        }
    }
    #endregion

    private Volume _volume;

    // Color Adjustments
    private ColorAdjustments _colorAdjustments;
    private float _defaultSaturationValue;

    // Bloom
    private Bloom _bloom;
    private float _defaultBloomIntensity;

    // Vignette
    private Vignette _vignette;
    private float _defaultVignetteIntensity;

    public void SetSaturationValue(float value)
    {
        _colorAdjustments.saturation.value = value;
    }

    public void ResetSaturationValue()
    {
        _colorAdjustments.saturation.value = _defaultSaturationValue;    
    }

    public void SetBloomIntensity(float intensity)
    {
        _bloom.intensity.value = intensity;
    }

    public void ResetBloomIntensity()
    {
        _bloom.intensity.value = _defaultBloomIntensity;
    }

    public void SetVignetteIntensity(float intensity)
    {
        _vignette.intensity.value = intensity;
    }

    public void ResetVignetteIntensity()
    {
        _vignette.intensity.value = _defaultVignetteIntensity;
    }
}
