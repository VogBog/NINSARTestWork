using UnityEngine;

public class DesktopController : MonoBehaviour
{
    private MapMover _mapMover;
    
    public void Initialize(MapMover mapMover)
    {
        _mapMover = mapMover;
    }

    private void Update()
    {
        int x = 0;
        int y = 0;

        if (Input.GetKeyDown(KeyCode.W))
            y++;
        if (Input.GetKeyDown(KeyCode.S))
            y--;
        if (Input.GetKeyDown(KeyCode.A))
            x--;
        if (Input.GetKeyDown(KeyCode.D))
            x++;

        if (x != 0 || y != 0)
        {
            _mapMover.Move(new Vector2Int(x, y));
        }
    }
}