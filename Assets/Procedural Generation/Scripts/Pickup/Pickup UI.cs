using UnityEngine;
using TMPro;

public class PickupUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string _defaultText = $"Flowers: ";
    [SerializeField] private string _lineEnd = "/20";
    private int counter = 0;

    private void Start()
    {
        UpdateUI();   
    }

    private void IncrementCounter()
    {
        counter++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        text.text = _defaultText + counter.ToString() + _lineEnd;
    }
}
