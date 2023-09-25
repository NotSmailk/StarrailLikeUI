using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StoreBuyItemPanel : VanishingGamePanel
{
    [field: SerializeField] private BlockForPanels _block;
    [field: SerializeField] private Image _spriteImg;
    [field: SerializeField] private TextMeshProUGUI _itemNameTxt;
    [field: SerializeField] private TextMeshProUGUI _itemDescriptionTxt;
    [field: SerializeField] private TextMeshProUGUI _itemPriceTxt;
    [field: SerializeField] private AnimatedButton _buyButton;
    [field: SerializeField] private AnimatedButton _cancelButton;
    [field: SerializeField] private AnimatedButtonBorders _viewItemButton;

    [Inject] private GameStateMachine _machine;
    [Inject] private ItemCollectionProvider _itemCollectionProvider;

    public override async Task ShowPanel(float duration)
    {
        _block.gameObject.SetActive(true);
        _block.Add(_machine.SwitchToPreviousWithoutEnter);
        _cancelButton.Add(_machine.SwitchToPreviousWithoutEnter);
        ShowPanel(_itemCollectionProvider.ItemToBuyId, _itemCollectionProvider.ItemToBuyPrice);
        await base.ShowPanel(duration);
    }

    public override async Task HidePanel(float duration)
    {
        HidePanel();
        await base.HidePanel(duration);
    }

    public void ShowPanel(int id, int price)
    {
        var data = _itemCollectionProvider.GetItem(id);
        _spriteImg.sprite = data.Sprite;
        _itemNameTxt.text = data.Name;
        _itemDescriptionTxt.text = data.Description;
        _itemPriceTxt.text = $"{GameConstants.KeyWords.PRICE_TEXT}: {price}";
        _viewItemButton.Add(() =>
        {
            _itemCollectionProvider.ItemToShowId = id;
            _machine.SwitchStateWithoutExit<GameItemViewMenuState>();
        });
        _buyButton.Add(() => _itemCollectionProvider.ItemsToGet.Add(id));
        _buyButton.Add(() => _machine.SwitchStateWithoutPush<GameGetNewItemState>());
        _panelRect.gameObject.SetActive(true);
    }

    public void HidePanel()
    {
        _cancelButton.RemoveAll();
        _buyButton.RemoveAll();
        _block.RemoveAll();
        _viewItemButton.RemoveAll();
        _panelRect.gameObject.SetActive(false);
        _block.gameObject.SetActive(false);
    }
}
