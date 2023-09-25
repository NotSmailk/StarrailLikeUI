using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public abstract class VanishingGamePanel : MonoBehaviour, IGameMenuPanel
{
    [field: SerializeField] protected RectTransform _panelRect;
    [field: SerializeField] protected Image _panelImg;
    [field: SerializeField] protected Button _closeButton;

    protected float _alpha;
    protected Color _defaultColor;

    public bool Enabled => _panelRect.gameObject.activeSelf;

    public virtual void Init()
    {
        _defaultColor = _panelImg.color;
        _alpha = _defaultColor.a;
        _panelRect.gameObject.SetActive(false);
    }

    public virtual void ShowPanelForce(bool show)
    {
        _panelRect.gameObject.SetActive(show);
    }

    public virtual async Task ShowPanel(bool show, float duration)
    {
        if (show)
            await ShowPanel(duration);
        else
            await HidePanel(duration);
    }

    public virtual async Task ShowPanel(float duration)
    {
        _panelRect.gameObject.SetActive(true);
        _panelImg.color = _panelImg.color * new Color(1, 1, 1, 0);
        float alpha = _alpha;
        var color = _defaultColor * new Color(1, 1, 1, alpha);

        _panelImg.DOColor(color, duration);
        await Task.Delay((int)(duration * 1000));
    }

    public virtual async Task HidePanel(float duration)
    {
        _panelImg.color = _defaultColor;
        var color = _defaultColor * new Color(1, 1, 1, 0);

        _panelImg.DOColor(color, duration / 4);
        await Task.Delay((int)(duration * 1000));
        _panelRect.gameObject.SetActive(false);
    }
}
