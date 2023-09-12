using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameSpinsMenuPanel : VanishingGamePanel
{
    [field: SerializeField] private SpinChooseTypeList _spinChooseTypeList;
    [field: SerializeField] private SpinInfoPanelList _spinInfoPanelList;

    [Inject] private GameStateMachine _gameBehaviour;
    [Inject] private SpinsDataProvider _spinProvider;

    public override void Init()
    {
        _closeButton.onClick.AddListener(_gameBehaviour.SwitchToPreviousState);
        base.Init();
    }

    public override async Task ShowPanel(float duration)
    {
        CreatePanel();
        await base.ShowPanel(duration);
    }

    public override async Task HidePanel(float duration)
    {
        ClearPanel();
        await base.HidePanel(duration);
    }

    public async void CreatePanel()
    {
        _spinChooseTypeList.CreateButtons(_spinProvider.SpinsData, async (int id) => { await _spinInfoPanelList.ShowPanel(id); });
        _spinInfoPanelList.CreatePanels(_spinProvider.SpinsData);
    }

    public void ClearPanel()
    {
        _spinChooseTypeList.Clear();
        _spinInfoPanelList.Clear();
    }
}
