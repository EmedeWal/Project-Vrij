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

    public void StartCameraShake(float shakeMagnitude)
    {
        StartCoroutine(CameraShakeCoroutine(shakeMagnitude));
    }

    public void StopCameraShake()
    {
        StopAllCoroutines();
        transform.localPosition = originalPosition;
    }

    private IEnumerator CameraShakeCoroutine(float shakeMagnitude)
    {
        while (true)
        {
            Vector3 randomPoint = originalPosition + Random.insideUnitSphere * shakeMagnitude;
            transform.localPosition = new Vector3(randomPoint.x, randomPoint.y, originalPosition.z);

            yield return null;
        }
    }
}
