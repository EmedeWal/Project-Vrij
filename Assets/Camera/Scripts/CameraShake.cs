using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    #region Singleton
    public static CameraShake Instance { get; private set; }

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

        originalPosition = transform.localPosition;
    }
    #endregion

    private Vector3 originalPosition;

    public void StartCameraShake(float shakeMagnitude, float frequency)
    {
        StartCoroutine(CameraShakeCoroutine(shakeMagnitude, frequency));
    }

    public void StopCameraShake()
    {
        StopAllCoroutines();
        transform.localPosition = originalPosition;
    }

    private IEnumerator CameraShakeCoroutine(float shakeMagnitude, float frequency)
    {
        while (true)
        {
            Vector3 randomPoint = originalPosition + Random.insideUnitSphere * shakeMagnitude;
            transform.localPosition = Vector3.Lerp(transform.localPosition, randomPoint, Time.deltaTime * frequency);

            yield return null;
        }
    }
}
