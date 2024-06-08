using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour
{
    [Header("Credit Scrolling")]
    [SerializeField] private RectTransform textHolder;
    [SerializeField] private float duration;
    [SerializeField] private float distance;

    private float speed;

    private void Start()
    {
        speed = distance / duration;
    }

    private void Update()
    {
        textHolder.anchoredPosition += Vector2.up * speed * Time.deltaTime;

        if (textHolder.anchoredPosition.y >= distance)
        {
            LoadMainMenu();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMainMenu();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 2;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Title Screen");
    }
}