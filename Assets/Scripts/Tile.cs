using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField] private TileEnum tileType;
    [SerializeField] private Text rewardText;
    [SerializeField] private Text qValueText;
    
    private double _reward;
    public double Reward
    {
        get => _reward;
        set
        {
             _reward = value;
             rewardText.text = _reward.ToString("F4");
        }
    }
    
    private readonly double[] _qValues = new double[4];

    public void SetQValue(ActionEnum action, double value)
    {
        _qValues[(int)action] = value;
        qValueText.text = _qValues.Average().ToString("F4");
    }

    public double GetQValue(ActionEnum action)
        => _qValues[(int) action];

    public TileEnum TileType => tileType;
    
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
