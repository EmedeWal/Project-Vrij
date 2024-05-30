using UnityEngine;
using UnityEngine.AI;

public abstract class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<NavMeshAgent>().SetDestination(other.transform.position);
            PlayerEntered();
        }
    }

    protected abstract void PlayerEntered();
}
