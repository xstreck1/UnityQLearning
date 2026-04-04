using UnityEngine;
using UnityEngine.UI;

public class VTile : BaseTile
{
    [SerializeField] private Text valueText;
    
    private double _value;
    public double Value
    {
        get => _value;
        set
        {
            _value = value;
            valueText.text = _value.ToString("F4");
            valueText.color = TextColor(value);
        }
    }

    private void Start()
    {
        Value = TileType == TileEnum.Grass ? 0 : Reward;
    }
}