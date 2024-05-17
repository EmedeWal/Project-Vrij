using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum ExitDirection 
    { 
        North, 
        East, 
        South, 
        West 
    }

    [System.Serializable]
    public struct Exit
    {
        public ExitDirection Direction;
    }

    public List<Exit> Exits;

    public bool HasExit(ExitDirection direction)
    {
        foreach (var exit in Exits)
        {
            if (exit.Direction == direction)
            {
                return true;
            }
        }
        return false;
    }

    public bool HasAllExits(List<ExitDirection> requiredExits)
    {
        foreach (var requiredExit in requiredExits)
        {
            if (!HasExit(requiredExit))
            {
                return false;
            }
        }
        return true;
    }
}