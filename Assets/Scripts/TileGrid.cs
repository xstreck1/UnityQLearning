// Created by Dr. Adam Streck, 2-123, adam.streck@gmail.com

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TileGrid : MonoBehaviour
{
    [SerializeField] private Tile grassTile;
    [SerializeField] private Tile waterTile;
    [SerializeField] private Tile awardTile;
    [SerializeField] private Agent agentPrefab;
    
    private int[][] _rewards;
    private Tile[][] _tiles;
    private Agent _agent;

    private const float TILE_SIZE = 128f;
    private const int START_X = 2;
    private const int START_Y = 6;

    private void Start()
    {
        GenerateRewards();
        GenerateTiles();
        InstantiateAgent();
        ResetAgentPos();
    }
    
    private Vector3 LogicalToLocalPos(int x, int y) 
        => new(TILE_SIZE * x, -TILE_SIZE * y, 0);
    
    private void ResetAgentPos()
    {
        _agent.transform.localPosition = LogicalToLocalPos(START_X, START_Y);
    }
    
    private void InstantiateAgent()
    {
        _agent = Instantiate(agentPrefab, transform);
    }

    private void GenerateRewards()
    {
        _rewards = new[]
        {
            new[] {-1, -1, -1, -1, -1},
            new[] {-1, 1, 1, 1, -1},
            new[] {-1, 1, 999, 1, -1},
            new[] {-1, 1, 1, 1, -1},
            new[] {-1, -1, 1, -1, -1},
            new[] {-1, 1, 1, 1, -1},
            new[] {-1, 1, 1, 1, -1},
            new[] {-1, 1, 1, 1, -1},
            new[] {-1, -1, -1, -1, -1}
        };
    }

    private Tile GetTileByReward(int reward)
        => reward switch
        {
            -1 => waterTile,
            1 => grassTile,
            999 => awardTile,
            _ => null
        };

    private void GenerateTiles()
    {
        _tiles = new Tile[_rewards.Length][];
        for (int y = 0; y < _rewards.Length; y++)
        {
            _tiles[y] = new Tile[_rewards[y].Length];
            for (int x = 0; x < _rewards[y].Length; x++)
            {
                var tilePrefab = GetTileByReward(_rewards[y][x]);
                var newTile = Instantiate(tilePrefab, transform);
                newTile.transform.localPosition = LogicalToLocalPos(x, y);
                _tiles[y][x] = newTile;
            }
        }
    }
}