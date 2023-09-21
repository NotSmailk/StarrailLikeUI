using Zenject;
using UnityEngine;
using System.Threading.Tasks;

public class GameAssignmentsPanel : VanishingGamePanel
{
    [field: SerializeField] private AssignmentChooseType _chooseList;
    [field: SerializeField] private AssignmentsScrollablePanelList _scrollableList;

    [Inject] private GameStateMachine _gameBehaviour;
    [Inject] private AssignmentsDataProvider _provider;

    public override void Init()
    {
        _closeButton.onClick.AddListener(_gameBehaviour.SwitchToPreviousState);
        base.Init();
    }

    public override async Task ShowPanel(float duration)
    {
        CreatePanels();
        await base.ShowPanel(duration);
    }

    private void CreatePanels()
    {
        _chooseList.CreateButton(_provider.Data, async (int id) => { await _scrollableList.ShowPanel(id); });
        _scrollableList.CreatePanels(_provider.Data);
    }

    public override async Task HidePanel(float duration)
    {
        ResetPanels();
        await base.HidePanel(duration);
    }

    private void ResetPanels()
    {
        _chooseList.Clear();
        _scrollableList.Clear();
    }
}
