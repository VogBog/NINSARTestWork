using UnityEngine;

public class Tester : MonoBehaviour
{
    private void Start()
    {
        var painter = FindFirstObjectByType<CubesPainter>();
        painter.ColorizeCubes(new int[] { 1, 1, 2, 2, 3, 4, 1, 4, 3});
    }
}