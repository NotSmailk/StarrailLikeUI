using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlot : ChooseTypeButton
{
    [Header("Item Slot Parametres")]
    [field: SerializeField] private Image _spriteImg;
    [field: SerializeField] private TextMeshProUGUI _nameTxt;
    [field: SerializeField] private TextMeshProUGUI _quantityTxt;

    public override void Init()
    {
        base.Init();
        _defaultSize = _rect.sizeDelta;
    }

    public void Init(ItemData data, int quantity)
    {
        Init();
        _spriteImg.sprite = data.Sprite;
        _nameTxt.text = data.Name;
        _quantityTxt.text = quantity.ToString();
    }
}
