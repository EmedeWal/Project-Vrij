using UnityEngine;

public class AngerFlowerEffect : FlowerEffect
{
    [Header("CAMERA SHAKE")]
    [SerializeField] private float _shakeMagnitude = 0.1f;

    public override void Activate()
    {
        base.Activate();
        CameraShake.Instance.StartCameraShake(_shakeMagnitude);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        CameraShake.Instance.StopCameraShake();
    }
}
