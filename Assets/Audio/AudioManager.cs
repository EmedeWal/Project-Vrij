using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _audioSource = GetComponent<AudioSource>();
    }
    #endregion

    [SerializeField] private AudioClip _defaultAudioClip;
    [SerializeField] private float _defaultVolume;
    private AudioSource _audioSource;
    private float _defaultClipTime;

    public void StopAudio()
    {
        _audioSource.Stop();
    }

    public void PlayAudio()
    {
        _audioSource.Play();
    }

    public void ResumeDefaultAudio()
    {
        _audioSource.Stop();
        _audioSource.clip = _defaultAudioClip;
        _audioSource.volume = _defaultVolume;
        _audioSource.time = _defaultClipTime;
        _audioSource.Play();
    }

    public void SetNewAudioClip(AudioClip clip, float volume)
    {
        if (_audioSource.clip == _defaultAudioClip)
        {
            _defaultClipTime = _audioSource.time;
        }

        _audioSource.Stop();
        _audioSource.volume = volume;
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
