using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothTime = 0.15f;

    //private void Awake()
    //{
    //    _target = GameObject.FindGameObjectWithTag("Player").transform;
    //}

    //private void Start()
    //{
    //    transform.position = _target.position + _offset;  
    //}

    private void Update()
    {
        if (_target != null)
        {
            Vector3 targetPosition = _target.position + _offset;

            //transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothTime);
            //transform.rotation = Quaternion.Lerp(transform.rotation, _target.rotation, _smoothTime);
            transform.SetPositionAndRotation(targetPosition, _target.rotation);
        }
    }
}