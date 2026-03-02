using System.Linq;
using UnityEngine;

public class DrumLayout_Vertical4 : IDrumLayout
{
    private readonly CellView[] _cells;

    private readonly float _cellHeight;
    private readonly float _spacing;
    private readonly float _step;
    private readonly float _centerY;

    private float _offsetY;
    private int _centerCellIndex;

    public DrumLayout_Vertical4(
        CellView[] cells,
        float spacing = 0f,
        float centerY = 400f)
    {
        _cells = cells;
        _spacing = spacing;
        _centerY = centerY;

        _cellHeight = cells[0].Rect.rect.height;
        _step = _cellHeight + _spacing;

        InitializePositions();
    }

    private void InitializePositions()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            float y = _centerY - i * _step;
            _cells[i].Rect.anchoredPosition = new Vector2(0f, y);
        }

        _offsetY = 0f;
    }

    public void UpdateLayout(float offset)
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i].Rect.anchoredPosition += Vector2.down * offset;
            if (_cells[i].Rect.anchoredPosition.y <= _centerY - _step * _cells.Length)
                _cells[i].Rect.anchoredPosition += Vector2.up * _step * _cells.Length;
        }
    }

    public float GetDistanceToCenter()
    {
        float distance = _step;
        for (int i = 0; i < _cells.Length; i++)
        {
            if (Mathf.Abs(_cells[i].Rect.anchoredPosition.y) < Mathf.Abs(distance)) { 
                distance = _cells[i].Rect.anchoredPosition.y; 
                _centerCellIndex = i;
            }
        }
        return -distance;
    }

    public int GetIndexCenterSlot()
    {
        return _centerCellIndex;
    }
}