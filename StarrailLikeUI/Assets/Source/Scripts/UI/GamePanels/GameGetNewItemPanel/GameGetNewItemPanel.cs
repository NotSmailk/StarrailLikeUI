using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameGetNewItemPanel : VanishingGamePanel
{
    [field: SerializeField] private BlockForPanels _block;
    [field: SerializeField] private RectTransform _content;
    [field: SerializeField] private ItemViewButton _buttonPrefab;

    [Inject] private ItemCollectionProvider _provider;
    [Inject] private GameStateMachine _machine;

    private List<ItemViewButton> _itemButtons = new List<ItemViewButton>();

    public override void Init()
    {
        _block.Add(() => _machine.SwitchToPreviousWithoutEnter());
        base.Init();
    }

    public override async Task ShowPanel(float duration)
    {
        _block.gameObject.SetActive(true);
        CreateButtons();
        await base.ShowPanel(duration);
    }

    public override async Task HidePanel(float duration)
    {
        _block.gameObject.SetActive(false);
        ClearPanel();
        await base.HidePanel(duration);
    }

    private void CreateButtons()
    {
        foreach (var itemId in _provider.ItemsToGet)
        {
            var btn = Instantiate(_buttonPrefab, _content);
            var item = _provider.GetItem(itemId);
            btn.Init(item.Sprite, item.Name);
            btn.Add(() =>
            {
                _provider.ItemToShowId = itemId;
                _machine.SwitchStateWithoutExit<GameItemViewMenuState>();
            });
            _itemButtons.Add(btn);
        }

        _provider.ItemsToGet.Clear();
    }

    private void ClearPanel()
    {
        foreach (var btn in _itemButtons)
            Object.DestroyImmediate(btn.gameObject);

        _itemButtons.Clear();
    }
}
