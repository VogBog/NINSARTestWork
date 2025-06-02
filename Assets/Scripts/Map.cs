using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Map
{
    private int[,] _numbers;
    private readonly int[] _centerArea;
    
    public Vector2Int Center { get; private set; }

    public const int AreaSize = 3;

    public event Action<int[]> AreaChanged;

    public Map()
    {
        _centerArea = new int[AreaSize * AreaSize];
    }

    public Map(int[,] numbers)
    {
        _centerArea = new int[AreaSize * AreaSize];
        SetNumbers(numbers);
    }

    public void SetNumbers(int[,] numbers)
    {
        _numbers = numbers;
        Center = new(
            Random.Range(0, _numbers.GetLength(0)),
            Random.Range(0, _numbers.GetLength(1))
        );
        UpdateCenterArea();
    }

    private void UpdateCenterArea()
    {
        for (int i = 0; i < _centerArea.Length; i++)
        {
            int x = (i % AreaSize) - 1 + Center.x;
            int y = (i / AreaSize) - 1 + Center.y;
            
            x = x < 0 ? _numbers.GetLength(0) - 1 : x % _numbers.GetLength(0);
            y = y < 0 ? _numbers.GetLength(1) - 1 : y % _numbers.GetLength(1);
            
            _centerArea[i] = _numbers[x, y];
        }
        
        AreaChanged?.Invoke(_centerArea);
    }

    public void Move(Vector2Int direction)
    {
        direction.y *= -1;
        
        var totalCenter = Center + direction;
        int length0 = _numbers.GetLength(0);
        int length1 = _numbers.GetLength(1);

        totalCenter.x = totalCenter.x < 0 ? length0 + totalCenter.x : totalCenter.x % length0;
        totalCenter.y = totalCenter.y < 0 ? length1 + totalCenter.y : totalCenter.y % length1;
        
        Center = totalCenter;
        UpdateCenterArea();
    }
}