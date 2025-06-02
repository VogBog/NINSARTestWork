using System;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private readonly MapMover _mapMover = new();
    
    private void Awake()
    {
        var cubesPainter = FindFirstObjectByType<CubesPainter>();
        if(cubesPainter == null)
            throw new NullReferenceException("Cannot find cubes painter");
        cubesPainter.Initialize(_mapMover);

        var mapController = FindFirstObjectByType<DesktopController>();
        if(mapController == null)
            throw new NullReferenceException("Cannot find map input controller");
        mapController.Initialize(_mapMover);
        
        _mapMover.SetNumbers(new [,]
        {
            {1, 1, 1, 1, 1},
            {1, 2, 2, 2, 1},
            {1, 2, 3, 2, 1},
            {1, 2, 2, 2, 1},
            {1, 1, 1, 1, 1}
        });
    }
}