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

    public void SetGameState(GameState newState)
    {
        _gameState = newState;
    }

    public GameState GetGameState()
    {
        return _gameState;
    }
}
