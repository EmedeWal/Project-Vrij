using System.Collections;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [Header("REFERENCES")]
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private Transform _target;

    [Header("VARIABLES")]
    [SerializeField] private int _spawnCount = 20;
    [SerializeField] private float _spawnDistance = 30;
    [SerializeField] private float _spawnCD = 10;
    private float _spawnDistanceSubtraction;
    private float _spawnCDSubstraction;

    //private void Awake()
    //{
    //    _target = GameObject.FindGameObjectWithTag("Player").transform;
    //}

    private void Start()
    {
        _spawnDistanceSubtraction = _spawnDistance / _spawnCount;
        _spawnCDSubstraction = _spawnCD / _spawnCount;

        StartCoroutine(WallTimerLoop());
    }

    private IEnumerator WallTimerLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnCD);

            CheckConditions();
        }
    }

    private void CheckConditions()
    {
        //_spawnDistance -= _spawnDistanceSubtraction;
        //_spawnCD -= _spawnCDSubstraction;

        //if (_spawnDistance < 0) Destroy(_target.gameObject);

        SpawnWall();
    }

    private void SpawnWall()
    {
        Vector3 spawnPosition = _spawnDistance * -1 * _target.forward;
        Quaternion rotationModifier = Quaternion.Euler(0, 90, 0);
        Quaternion spawnRotation = _target.rotation * rotationModifier;
        Instantiate(_wallPrefab, spawnPosition, spawnRotation);
    }
}
