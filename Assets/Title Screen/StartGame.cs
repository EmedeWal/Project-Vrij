using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class StartGame : MonoBehaviour
{
    [Header("TITLE REFERENCES")]
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private RectTransform _titleTransform;

    [Header("OTHER REFERENCES")]
    [SerializeField] private RectTransform _targetTransform;
    [SerializeField] private GameObject _mainMenu;

    private Button _button;
    private Image _image;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();

        _mainMenu.SetActive(false);
    }

    public void StartTheGame()
    {
        _button.enabled = false;
        StartCoroutine(MakeImageTransparentCoroutine());
        StartCoroutine(RepositionAndShrinkTitleCoroutine());
    }

    private IEnumerator MakeImageTransparentCoroutine()
    {
        Color imageColor = _image.color;
        float duration = 3.0f; 
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1.0f, 0.0f, elapsedTime / duration);
            _image.color = new Color(imageColor.r, imageColor.g, imageColor.b, alpha);
            yield return null;
        }

        Destroy(_image);    
    }

    private IEnumerator RepositionAndShrinkTitleCoroutine()
    {
        Vector3 startPos = _titleTransform.anchoredPosition;
        Vector3 endPos = _targetTransform.anchoredPosition;
        float startSize = _titleText.fontSize;
        float endSize = startSize * 0.5f; 
        float duration = 3.0f; 
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            _titleTransform.anchoredPosition = Vector3.Lerp(startPos, endPos, t);
            _titleText.fontSize = Mathf.Lerp(startSize, endSize, t);
            yield return null;
        }

        _titleTransform.anchoredPosition = endPos;
        _titleText.fontSize = endSize;

        EnableMainMenu();
    }

    private void EnableMainMenu()
    {
        _mainMenu.SetActive(true);
    }
}
