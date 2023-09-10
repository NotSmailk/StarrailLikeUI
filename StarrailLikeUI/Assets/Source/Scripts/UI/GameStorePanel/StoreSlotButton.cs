using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StoreSlotButton : MonoBehaviour
{
    [field: SerializeField] private TextMeshProUGUI _nameText;
    [field: SerializeField] private TextMeshProUGUI _costText;
    [field: SerializeField] private TextMeshProUGUI _quantityText;
    [field: SerializeField] private Image _spriteImg;
    [field: SerializeField] private Button _button;

    public void Init(ItemData data, int price, int quantity)
    {
        _nameText.text = data.Name;
        _costText.text = price.ToString();
        _quantityText.text = quantity.ToString();
        _spriteImg.sprite = data.Sprite;
    }

    public void Add(UnityAction action)
    {
        _button.onClick.AddListener(action);
    }
}
