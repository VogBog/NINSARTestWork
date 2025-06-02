using System;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private ReadFileView _readFileView;
    
    private readonly Map _map = new();
    private readonly FileReader _fileReader = new();
    
    private void Awake()
    {
        var cubesPainter = FindFirstObjectByType<CubesPainter>();
        if(cubesPainter == null)
            throw new NullReferenceException("Cannot find cubes painter");
        cubesPainter.Initialize(_map);

        var mapController = FindFirstObjectByType<DesktopController>();
        if(mapController == null)
            throw new NullReferenceException("Cannot find map input controller");
        mapController.Initialize(_map);
        
        _readFileView.Initialize(_map, _fileReader);
    }
}