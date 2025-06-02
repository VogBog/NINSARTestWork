using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CubesPainter : MonoBehaviour
{
    [SerializeField] private Transform _cubesParent;
    [SerializeField] private Material[] _coloredMaterials;

    private MeshRenderer[] _cubes;

    private void Awake()
    {
        _cubes = new MeshRenderer[_cubesParent.childCount];
        for (int i = 0; i < _cubes.Length; i++)
        {
            var child = _cubesParent.GetChild(i);
            if (!child.TryGetComponent<MeshRenderer>(out var meshRenderer))
            {
                throw new Exception("CubesParent must have cubes with MeshRenderer");
            }
            _cubes[i] = meshRenderer;
        }
    }

    public void ColorizeCube(int cubeIndex, int colorIndex)
    {
        if(cubeIndex < 0 || cubeIndex >= _cubes.Length)
            throw new Exception("cubeIndex out of range");
        
        if(colorIndex < 1 || colorIndex >= _coloredMaterials.Length + 1)
            throw new Exception("colorIndex out of range");
        
        _cubes[cubeIndex].sharedMaterial = _coloredMaterials[colorIndex - 1];
    }

    public void ColorizeCubes(int[] colorIndexes)
    {
        if(colorIndexes.Length != _cubes.Length)
            throw new Exception("ColorIndexes length must be equal to the number of cubes");

        for (int i = 0; i < colorIndexes.Length; i++)
        {
            ColorizeCube(i, colorIndexes[i]);
        }
    }
}