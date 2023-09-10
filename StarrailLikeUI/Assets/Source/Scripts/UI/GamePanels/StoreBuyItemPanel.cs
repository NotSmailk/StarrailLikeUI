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
    [field: SerializeField] private TextMeshProUGUI _itemDexcriptionTxt;
    [field: SerializeField] private TextMeshProUGUI _itemPriceTxt;
    [field: SerializeField] private AnimatedButton _buyButton;
    [field: SerializeField] private AnimatedButton _cancelButton;

    [Inject] private GameStateMachine _machine;

    public override async Task ShowPanel(float duration)
    {
        _block.gameObject.SetActive(true);
        _block.Add(_machine.SwitchToPreviousWithoutEnter);
        _cancelButton.Add(HidePanel);
        _cancelButton.Add(_machine.SwitchToPreviousWithoutEnter);
        await base.ShowPanel(duration);
    }

    public override async Task HidePanel(float duration)
    {
        HidePanel();
        await base.HidePanel(duration);
    }

    public void ShowPanel(ItemData data, int price)
    {
        _spriteImg.sprite = data.Sprite;
        _itemNameTxt.text = data.Name;
        _itemDexcriptionTxt.text = data.Description;
        _itemPriceTxt.text = price.ToString();
        _panelRect.gameObject.SetActive(true);
    }

    public void HidePanel()
    {
        _cancelButton.RemoveAll();
        _buyButton.RemoveAll();
        _block.RemoveAll();
        _panelRect.gameObject.SetActive(false);
        _block.gameObject.SetActive(false);
    }
}
