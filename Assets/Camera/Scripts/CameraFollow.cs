using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target to follow")]
    [SerializeField] private Transform _target;

    [Header("Distance to target")]
    [SerializeField] private Vector3 _offset;

    [Header("Lower value is more smoothing")]
    [SerializeField] private float _smoothTime;

    private void Start()
    {
        transform.position = _target.position + _offset;
    }

    private void Update()
    {
        Vector3 currentPos = transform.position;
        Vector3 targetPos = _target.position + _offset;
        float smoothing = _smoothTime * Time.deltaTime;

        //transform.SetPositionAndRotation(Vector3.Lerp(currentPos, targetPos, smoothing), Quaternion.Lerp(transform.rotation, _target.rotation, smoothing));
        transform.position = Vector3.Lerp(currentPos, targetPos, smoothing);
        //transform.rotation = _target.rotation;
    }
}
