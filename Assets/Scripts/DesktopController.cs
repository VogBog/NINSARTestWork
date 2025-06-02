using UnityEngine;

public class DesktopController : MonoBehaviour
{
    private Map _map;
    
    public void Initialize(Map map)
    {
        _map = map;
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
            _map.Move(new Vector2Int(x, y));
        }
    }
}