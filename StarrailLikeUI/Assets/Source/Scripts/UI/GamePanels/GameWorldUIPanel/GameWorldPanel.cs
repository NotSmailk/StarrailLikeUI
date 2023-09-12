using DG.Tweening;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameWorldPanel : MonoBehaviour, IGameMenuPanel
{
    [field: SerializeField] private CharacterListPanel _listPanel;
    [field: SerializeField] private RectTransform _panel;
    [field: SerializeField] private RectTransform _panelLeft;
    [field: SerializeField] private RectTransform _panelRight;
    [field: SerializeField] private float _xHiddenValue = 0f;
    [field: SerializeField] private float _xShowedValue = 0f;
    [field: SerializeField] private Button _openUIBtn = null;
    [field: SerializeField] private Button _openInvenotryBtn = null;
    [field: SerializeField] private TextMeshProUGUI _uidText;

    [Inject] private UserProvider _userProvider;
    [Inject] private SquadData _squadData;
    [Inject] private GameStateMachine _gameBehaviour;

    public void Init()
    {
        _openUIBtn.onClick.AddListener(_gameBehaviour.SwitchState<GamePhoneMenuState>);
        _openInvenotryBtn.onClick.AddListener(_gameBehaviour.SwitchState<GameInventoryState>);
        _listPanel.Init(_squadData);
        _uidText.text = $"{GameConstants.KeyWords.UID_TEXT}: {_userProvider.User.uid}";
    }

    public void SetActiveCharacter(int id)
    {
        _listPanel.SetActiveIcon(id);
    }

    public async Task ShowPanel(bool activity, float duration)
    {
        await ShowPanelWithTime(activity, duration);
    }

    public void ShowPanelForce(bool activity)
    {
        _panel.gameObject.SetActive(activity);

        var xValue = activity ? _xShowedValue : _xHiddenValue;
        _panelLeft.DOAnchorPosX(xValue, 0f);
        _panelRight.DOAnchorPosX(-xValue, 0f);
    }

    private async Task ShowPanelWithTime(bool activity, float duration)
    {
        var xValue = activity ? _xShowedValue : _xHiddenValue;
        _panelLeft.DOAnchorPosX(xValue, duration);
        _panelRight.DOAnchorPosX(-xValue, duration);

        var delay = activity ? 0 : (int)(duration * 1000);
        await Task.Delay(delay);
        _panel.gameObject.SetActive(activity);
    }
}
