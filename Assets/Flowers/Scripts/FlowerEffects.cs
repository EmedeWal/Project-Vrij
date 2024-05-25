using UnityEngine;

public class FlowerEffects : FlowerUI
{
    [Header("Fear Flower")]
    [SerializeField] private Color _lightColor;
    [SerializeField] private float _newIntensity;

    protected override void LoveFlowerCollected()
    {
        LightManager.Instance.RevertLightColorAndIntensity();
        DisableElements();
        EnableElement(0);
    }

    protected override void FearFlowerCollected()
    {
        LightManager.Instance.SetLightColorAndIntensity(_lightColor, _newIntensity);
        DisableElements();
        EnableElement(1);
    }

    protected override void LonelinessFlowerCollected()
    {
        LightManager.Instance.RevertLightColorAndIntensity();
        DisableElements();
        EnableElement(2);
    }

    protected override void JoyFlowerCollected()
    {
        LightManager.Instance.RevertLightColorAndIntensity();
        DisableElements();
        EnableElement(3);
    }
}
