using UnityEngine;

public class Flower : MonoBehaviour
{
    public FlowerType FlowerType;

    public delegate void Flower_FlowerCollected(FlowerType flowerType);
    public static event Flower_FlowerCollected FlowerCollected;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");

        if (other.CompareTag("Player"))
        {
            OnPickupCollected();
            Destroy(gameObject);
        }
    }

    private void OnPickupCollected()
    {
        FlowerCollected?.Invoke(FlowerType);
    }
}
