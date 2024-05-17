using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PickupType PickupType;

    public delegate void Pickup_PickupCollected(PickupType pickupType);
    public static event Pickup_PickupCollected PickupCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPickupCollected();

            DungeonGenerator.Instance.CollectedPickup(this);
            DungeonGenerator.Instance.DestroyPickup(transform.position);
        }
    }

    private void OnPickupCollected()
    {
        PickupCollected?.Invoke(PickupType);
    }
}
