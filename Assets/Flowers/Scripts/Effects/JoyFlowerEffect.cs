using UnityEngine;

public class JoyFlowerEffect : FlowerEffect
{
    [Header("LIGHT")]
    [SerializeField] private Color _lightColor;
    [SerializeField] private float _lightIntensity;

    public override void Activate()
    {
        base.Activate();
        LightManager.Instance.SetLightColorAndIntensity(_lightColor, _lightIntensity);
    }

    public override void Deactivate()
    {
        base .Deactivate();
        LightManager.Instance.RevertLightColorAndIntensity();
    }
}
