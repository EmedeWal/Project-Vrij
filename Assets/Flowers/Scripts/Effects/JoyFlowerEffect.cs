using UnityEngine;

public class JoyFlowerEffect : FlowerEffect
{
    [Header("SCREEN")]
    [SerializeField] private GameObject _canvas;

    public override void Activate()
    {
        base.Activate();
        _canvas.SetActive(true);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _canvas.SetActive(false);
    }
}
