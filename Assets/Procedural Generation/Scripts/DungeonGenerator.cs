using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    [Header("TILES")]
    [SerializeField] private List<Tile> _tilePrefabs;

    [Header("GRID SETTINGS")]
    [SerializeField] private int _tileOffset = 1;
    [SerializeField] private int _gridSize = 10;

    private List<Tile> _placedTiles = new List<Tile>();
    private Dictionary<Vector3, Tile> _tilePositions = new Dictionary<Vector3, Tile>();
    private Vector3 _playerTilePosition;

    #region Singleton
    public static DungeonGenerator Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private void Start()
    {
        GenerateInitialGrid();
    }

    private void GenerateInitialGrid()
    {
        for (int x = -_gridSize / 2; x <= _gridSize / 2; x++)
        {
            for (int z = -_gridSize / 2; z <= _gridSize / 2; z++)
            {
                Vector3 newPosition = new Vector3(x * _tileOffset, 0, z * _tileOffset);
                Tile newTile = GetMatchingTile(newPosition);

                if (newTile != null)
                {
                    Tile placedTile = Instantiate(newTile, newPosition, Quaternion.identity);
                    _placedTiles.Add(placedTile);
                    _tilePositions[newPosition] = placedTile;
                }
            }
        }

        _playerTilePosition = Vector3.zero;
    }

    private void UpdateGrid(Vector3 playerTilePosition)
    {
        List<Vector3> positionsToCheck = new List<Vector3>();

        for (int x = -_gridSize / 2; x <= _gridSize / 2; x++)
        {
            for (int z = -_gridSize / 2; z <= _gridSize / 2; z++)
            {
                Vector3 newPosition = playerTilePosition + new Vector3(x * _tileOffset, 0, z * _tileOffset);
                positionsToCheck.Add(newPosition);
            }
        }

        foreach (var position in positionsToCheck)
        {
            if (!_tilePositions.ContainsKey(position))
            {
                Tile newTile = GetMatchingTile(position);

                if (newTile != null)
                {
                    Tile placedTile = Instantiate(newTile, position, Quaternion.identity);
                    _placedTiles.Add(placedTile);
                    _tilePositions[position] = placedTile;
                }
            }
        }

        List<Vector3> positionsToRemove = new List<Vector3>();

        foreach (var position in _tilePositions.Keys)
        {
            if (!positionsToCheck.Contains(position))
            {
                positionsToRemove.Add(position);
            }
        }

        foreach (var position in positionsToRemove)
        {
            Tile tileToRemove = _tilePositions[position];
            _placedTiles.Remove(tileToRemove);
            _tilePositions.Remove(position);
            Destroy(tileToRemove.gameObject);
        }

        _playerTilePosition = playerTilePosition;
    }

    public void OnPlayerEnterTile(Tile tile)
    {
        Vector3 tilePosition = tile.transform.position;

        if (tilePosition != _playerTilePosition)
        {
            UpdateGrid(tilePosition);
        }
    }

    private Tile GetMatchingTile(Vector3 newPosition)
    {
        List<Tile.ExitDirection> requiredExits = new List<Tile.ExitDirection>();

        Tile northTile = GetTileAtPosition(newPosition + new Vector3(0, 0, _tileOffset));
        Tile southTile = GetTileAtPosition(newPosition + new Vector3(0, 0, -_tileOffset));
        Tile eastTile = GetTileAtPosition(newPosition + new Vector3(_tileOffset, 0, 0));
        Tile westTile = GetTileAtPosition(newPosition + new Vector3(-_tileOffset, 0, 0));

        if (northTile != null && northTile.HasExit(Tile.ExitDirection.South))
        {
            requiredExits.Add(Tile.ExitDirection.North);
        }
        if (southTile != null && southTile.HasExit(Tile.ExitDirection.North))
        {
            requiredExits.Add(Tile.ExitDirection.South);
        }
        if (eastTile != null && eastTile.HasExit(Tile.ExitDirection.West))
        {
            requiredExits.Add(Tile.ExitDirection.East);
        }
        if (westTile != null && westTile.HasExit(Tile.ExitDirection.East))
        {
            requiredExits.Add(Tile.ExitDirection.West);
        }

        List<Tile> matchingTiles = new List<Tile>();
        foreach (var tilePrefab in _tilePrefabs)
        {
            if (tilePrefab.HasAllExits(requiredExits))
            {
                matchingTiles.Add(tilePrefab);
            }
        }

        if (matchingTiles.Count > 0)
        {
            int randomIndex = Random.Range(0, matchingTiles.Count);
            return matchingTiles[randomIndex];
        }
        else
        {
            int randomIndex = Random.Range(0, _tilePrefabs.Count);
            return _tilePrefabs[randomIndex];
        }
    }

    private Tile GetTileAtPosition(Vector3 position)
    {
        if (_tilePositions.ContainsKey(position))
        {
            return _tilePositions[position];
        }
        return null;
    }
}