using Zenject;
using UnityEngine;
using System.Threading.Tasks;

public class GameFriendsPanel : VanishingGamePanel
{
    [field: SerializeField] private FriendsListPanel _listPanel;

    [Inject] private GameStateMachine _gameBehaviour;

    public override void Init()
    {
        _closeButton.onClick.AddListener(_gameBehaviour.SwitchToPreviousState);
        base.Init();
    }

    public override async Task ShowPanel(float duration)
    {
        _listPanel.ShowList();
        await base.ShowPanel(duration);
    }

    public override async Task HidePanel(float duration)
    {
        _listPanel.HideList();
        await base.HidePanel(duration);
    }
}
