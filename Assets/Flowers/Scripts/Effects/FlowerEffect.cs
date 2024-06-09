using UnityEngine;

public class FlowerEffect : MonoBehaviour
{
    [Header("AUDIO")]
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private float _volume;

    public virtual void Activate()
    {
        MainFlower.FlowerCollected += Deactivate;

        AudioManager.Instance.SetNewAudioClip(_audioClip, _volume);
    }

    public virtual void Deactivate()
    {
        MainFlower.FlowerCollected -= Deactivate;

        AudioManager.Instance.ResumeDefaultAudio();
    }
}
