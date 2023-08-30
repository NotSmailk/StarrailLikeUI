using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameAssignmentsPanel : MonoBehaviour, IGameMenuPanel
{
    [field: SerializeField] private RectTransform _panelRect;
    [field: SerializeField] private Image _panelImg;
    [field: SerializeField] private Button _closeButton;

    [Inject] private GameStateMachine _gameBehaviour;

    private float _alpha;
    private Color _defaultColor;

    public void Init()
    {
        _closeButton.onClick.AddListener(_gameBehaviour.SwitchToPreviousState);
        _defaultColor = _panelImg.color;
        _alpha = _defaultColor.a;
        _panelRect.gameObject.SetActive(false);
    }

    public void ShowPanelForce(bool show)
    {
        _panelRect.gameObject.SetActive(show);
    }

    public async Task ShowPanel(bool show, float duration)
    {
        if (show)
            await ShowPanel(duration);
        else
            await HidePanel(duration);
    }

    public async Task ShowPanel(float duration)
    {
        _panelRect.gameObject.SetActive(true);
        _panelImg.color = _panelImg.color * new Color(1, 1, 1, 0);
        float alpha = _alpha;
        var color = _defaultColor * new Color(1, 1, 1, alpha);

        _panelImg.DOColor(color, duration);
        await Task.Delay((int)(duration * 1000));
    }

    public async Task HidePanel(float duration)
    {
        _panelImg.color = _defaultColor;
        float alpha = 0;
        var color = _defaultColor * new Color(1, 1, 1, alpha);

        _panelImg.DOColor(color, duration / 4);
        await Task.Delay((int)(duration * 1000));
        _panelRect.gameObject.SetActive(false);
    }
}
