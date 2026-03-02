using UnityEngine;

public class CellView : MonoBehaviour
{
    private RectTransform _rectTransform;
    public RectTransform Rect 
    { 
        get
        {
            if (_rectTransform == null)
                _rectTransform = transform as RectTransform;
            return _rectTransform;
        }
        private set { }
    }

    private void Awake()
    {
        Rect = transform as RectTransform;
    }
}
    