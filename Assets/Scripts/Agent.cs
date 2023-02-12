using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public static ActionEnum RndAction()
        => (ActionEnum) Random.Range(0, 4);

    private TilePos _currentPos;
    public TilePos CurrentPos
    {
        get => _currentPos;
        set
        {
            _currentPos = value;
            transform.localPosition = TileGrid.LogicalToLocalPos(_currentPos.X, _currentPos.Y);
        }
    }
}
