using ModestTree;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameStorePanel : VanishingGamePanel
{
    [field: SerializeField] private StoreChooseTypePanel _chooseTypePanel;
    [field: SerializeField] private StoreScrollablePanelsList _scrollablePanelsList;

    [Inject] private GameStateMachine _gameBehaviour;
    [Inject] private StoresDataProvider _storeProvider;

    public override void Init()
    {
        _closeButton.onClick.AddListener(_gameBehaviour.SwitchToPreviousState);
        base.Init();
    }

    public override async Task ShowPanel(float duration)
    {
        LoadStores();
        await base.ShowPanel(duration);
    }

    private void LoadStores()
    {
        foreach (var store in _storeProvider.Stores)
        {
            _chooseTypePanel.CreateButton(store, async () => { await _scrollablePanelsList.ShowPanel(_storeProvider.Stores.IndexOf(store)); });
            _scrollablePanelsList.CreatePanel(store);
        }

        int id = 0;
        _scrollablePanelsList.ChoosePanel(id);
        _chooseTypePanel.ChooseButton(id);
    }

    private void UnloadStores()
    {
        _chooseTypePanel.Clear();
        _scrollablePanelsList.Clear();
    }

    public override async Task HidePanel(float duration)
    {
        UnloadStores();
        await base.HidePanel(duration);
    }
}
