using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,
        Walking,
        Paused
    }

    public PlayerState State;

    public void SetState(PlayerState state)
    {
        State = state; 
    }

    public void SetIdle()
    {
        SetState(PlayerState.Idle);
    }

    public void SetWalking()
    {
        SetState(PlayerState.Walking);
    }

    public void SetPaused()
    {
        SetState(PlayerState.Paused);
    }

    public bool IsIdle()
    {
        return State == PlayerState.Idle;
    }

    public bool IsWalking()
    {
        return State == PlayerState.Walking;
    }

    public bool IsPaused()
    {
        return State == PlayerState.Paused;
    }

    public bool CanWalk()
    {
        return IsIdle() || IsWalking();
    }
}
