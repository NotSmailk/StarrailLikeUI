using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class VerticalScrollablePanel : MonoBehaviour, IScrollablePanel
{
    [field: SerializeField] protected RectTransform _rect;
    [field: SerializeField] protected float _yValueUp;
    [field: SerializeField] protected float _yValueShowed;
    [field: SerializeField] protected float _yValueDown;
    [field: SerializeField] protected float _animationDuration;

    public virtual async Task ShowPanel(bool show, PanelAnimationType type)
    {
        if (show)
            await Show(type);
        else
            await Hide(type);
    }

    public virtual void ShowPanel(bool show)
    {
        _rect.gameObject.SetActive(show);
    }

    protected virtual async Task Show(PanelAnimationType type)
    {
        try
        {
            _rect.gameObject.SetActive(true);
            var yValue = _yValueShowed;
            var pos = new Vector2(_rect.anchoredPosition.x, yValue);
            _rect.DOAnchorPos(pos, _animationDuration);
            await Task.Delay((int)(_animationDuration * 1000));
        }
        catch { }
    }

    protected virtual async Task Hide(PanelAnimationType type)
    {
        try
        {
            var yValue = type.Equals(PanelAnimationType.Up) ? _yValueUp : _yValueDown;
            var pos = new Vector2(_rect.anchoredPosition.x, yValue);
            _rect.DOAnchorPos(pos, _animationDuration);
            await Task.Delay((int)(_animationDuration * 1000));
            _rect.gameObject.SetActive(false);
        }
        catch { }
    }

    public virtual void DestroyPanel()
    {
        Destroy(gameObject);
    }
}
