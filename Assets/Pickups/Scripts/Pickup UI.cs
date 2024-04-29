using UnityEngine;
using TMPro;

public class PickupUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private int counter = 0;

    private void Start()
    {
        UpdateUI();   
    }

    private void OnEnable()
    {
        Pickup.TriggerEnter += IncrementCounter;
    }

    private void OnDisable()
    {
        Pickup.TriggerEnter -= IncrementCounter;
    }

    private void IncrementCounter()
    {
        counter++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        text.text = $"Flowers: {counter}/20";  
    }
}
