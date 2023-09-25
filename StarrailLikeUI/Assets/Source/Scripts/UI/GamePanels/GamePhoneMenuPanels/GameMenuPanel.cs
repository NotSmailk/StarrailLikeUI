using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class GameMenuPanel : MonoBehaviour, IGameMenuPanel
{
    [field: SerializeField] private PlayerPhoneMenuPanel _playerInfoPanel;
    [field: SerializeField] private SystemGameMenuPanel _systemMenuPanel;
    [field: SerializeField] private RectTransform _panel;
    [field: SerializeField] private float _xHiddenValue = 0f;
    [field: SerializeField] private float _xShowedValue = 0f;

    public bool Enabled => _panel.gameObject.activeSelf;

    public void Init()
    {
        _systemMenuPanel.Init();
        _playerInfoPanel.Init();
    }

    public async Task ShowPanel(bool activity, float duration)
    {
        await  ShowPanelWithTime(activity, duration);
    }

    public void ShowPanelForce(bool activity)
    {
        _panel.gameObject.SetActive(activity);

        var xValue = activity ? _xShowedValue : _xHiddenValue;
        _panel.DOAnchorPosX(xValue, 0f);
    }

    public void GameUpdate()
    {
        _playerInfoPanel.GameUpdate();
    }

    private async Task ShowPanelWithTime(bool activity, float duration)
    {
        _playerInfoPanel.ShowPanel();
        var xValue = activity ? _xShowedValue : _xHiddenValue;
        _panel.DOAnchorPosX(xValue, duration);

        var delay = activity ? 0 : (int)(duration * 1000);
        await Task.Delay(delay);
        _panel.gameObject.SetActive(activity);
    }
}
