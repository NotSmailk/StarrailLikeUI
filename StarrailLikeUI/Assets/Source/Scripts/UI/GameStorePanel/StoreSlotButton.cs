using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoreSlotButton : MonoBehaviour
{
    [field: SerializeField] private TextMeshProUGUI _nameText;
    [field: SerializeField] private TextMeshProUGUI _costText;
    [field: SerializeField] private TextMeshProUGUI _quantityText;
    [field: SerializeField] private Image _spriteImg;
    [field: SerializeField] private Button _button;

    public void Init(StoreItemData data, int quantity)
    {
        _nameText.text = data.Item.Name;
        _costText.text = data.Price.ToString();
        _quantityText.text = quantity.ToString();
        _spriteImg.sprite = data.Item.Sprite;
    }
}
