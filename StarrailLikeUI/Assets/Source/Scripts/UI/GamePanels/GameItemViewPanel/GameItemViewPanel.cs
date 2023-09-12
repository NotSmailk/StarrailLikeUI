using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameItemViewPanel : VanishingGamePanel
{
    [field: SerializeField] private BlockForPanels _block;
    [field: SerializeField] private Image _spriteImg;
    [field: SerializeField] private TextMeshProUGUI _itemNameTxt;
    [field: SerializeField] private TextMeshProUGUI _itemDescriptionTxt;
    [field: SerializeField] private TextMeshProUGUI _itemQuantityTxt;

    [Inject] private GameStateMachine _machine;
    [Inject] private ItemCollectionProvider _itemCollectionProvider;
    [Inject] private UserProvider _userProvider;

    public override async Task ShowPanel(float duration)
    {
        _block.gameObject.SetActive(true);
        _block.Add(_machine.SwitchToPreviousWithoutEnter);
        _block.Add(_block.RemoveAll);
        ShowPanel(_itemCollectionProvider.ItemToShowId);
        await base.ShowPanel(duration);
    }

    public override async Task HidePanel(float duration)
    {
        HidePanel();
        await base.HidePanel(duration);
    }

    public void ShowPanel(int id)
    {
        var data = _itemCollectionProvider.GetItem(id);
        _spriteImg.sprite = data.Sprite;
        _itemNameTxt.text = data.Name;
        _itemDescriptionTxt.text = data.Description;
        _itemQuantityTxt.text = $"{GameConstants.KeyWords.OWNED_TEXT}: {_userProvider.User.GetItemQuantity(id)}";

        _panelRect.gameObject.SetActive(true);
    }

    public void HidePanel()
    {
        _panelRect.gameObject.SetActive(false);
        _block.gameObject.SetActive(false);
    }
}
