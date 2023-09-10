using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameInventoryPanel : VanishingGamePanel
{
    [field: SerializeField] private InventoryItemsList _itemList;
    [field: SerializeField] private InventoryItemInfoPanel _itemInfoPanel;

    [Inject] private GameStateMachine _gameBehaviour;
    [Inject] private UserProvider _userProvider;

    public override void Init()
    {
        _closeButton.onClick.AddListener(_gameBehaviour.SwitchToPreviousState);
        _itemList.Add(_itemInfoPanel.ShowItem);
        base.Init();
    }

    public override async Task ShowPanel(float duration)
    {
        _itemInfoPanel.ShowPanel();
        _itemList.ShowPanel(_userProvider.User.inventory);
        await base.ShowPanel(duration);
    }

    public override async Task HidePanel(float duration)
    {
        _itemInfoPanel.HidePanel();
        _itemList.HidePanel();
        await base.HidePanel(duration);
    }
}
