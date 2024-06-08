using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("UI REFERENCES")]
    [SerializeField] private GameObject _holder;

    private void Start()
    {
        _holder.SetActive(false);
    }

    private void OnEnable()
    {
        PlayerInputManager.PauseGameInputPerformed += PauseMenu_PauseGameInputPerformed;
    }

    private void OnDisable()
    {
        PlayerInputManager.PauseGameInputPerformed -= PauseMenu_PauseGameInputPerformed;
    }

    private void PauseMenu_PauseGameInputPerformed()
    {
        if (_holder.activeSelf)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0; 
        _holder.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1; 
        _holder.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void Desktop()
    {
        Application.Quit();
    }
}
