using System;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public delegate void Delegate_TriggerEnter();
    public static event Delegate_TriggerEnter TriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        TriggerEnter?.Invoke();
        Destroy(gameObject);
    }
}
