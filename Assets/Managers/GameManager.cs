using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }
    #endregion

    #region Enum
    public enum GameState
    {
        Beginning,
        Middle,
        End
    }

    private GameState _gameState;
    #endregion

    [SerializeField] private FlowerEffects _flowerEffects;

    private void Start()
    {
        _flowerEffects.Initialize();
    }

    public void SetGameState(GameState newState)
    {
        _gameState = newState;
    }

    public GameState GetGameState()
    {
        return _gameState;
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Outro");
    }
}
