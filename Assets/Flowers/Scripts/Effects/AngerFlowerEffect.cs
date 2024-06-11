using UnityEngine;

public class AngerFlowerEffect : FlowerEffect
{
    [Header("CAMERA SHAKE")]
    [SerializeField] private float _shakeMagnitude = 0.5f;
    [SerializeField] private float _shakeFrequency = 5.0f;

    public override void Activate()
    {
        base.Activate();
        CameraShake.Instance.StartCameraShake(_shakeMagnitude, _shakeFrequency);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        CameraShake.Instance.StopCameraShake();
    }
}
