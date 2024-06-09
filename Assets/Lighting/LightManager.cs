using UnityEngine;

public class LightManager : MonoBehaviour
{
    private Light _light;
    private Color _defaultColor;
    private float _defaultIntensity;

    public static LightManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        _light = GetComponent<Light>();

        _defaultColor = _light.color;
        _defaultIntensity = _light.intensity;
    }

    public void SetLightColorAndIntensity(Color color, float intensity)
    {
        _light.color = color;
        _light.intensity = intensity;
    }

    public void RevertLightColorAndIntensity()
    {
        _light.intensity = _defaultIntensity;
        _light.color = _defaultColor;
    }
}
