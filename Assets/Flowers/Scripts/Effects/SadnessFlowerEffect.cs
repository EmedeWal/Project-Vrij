using UnityEngine;

public class SadnessFlowerEffect : FlowerEffect
{
    [Header("SCREEN")]
    [SerializeField] private GameObject _rainEffect;

    public override void Activate()
    {
        base.Activate();
        _rainEffect.SetActive(true);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _rainEffect.SetActive(false);
    }
}
