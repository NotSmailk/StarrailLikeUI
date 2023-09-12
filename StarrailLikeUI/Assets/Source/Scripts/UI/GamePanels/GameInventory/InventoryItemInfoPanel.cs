using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemInfoPanel : MonoBehaviour
{
    [field: SerializeField] private RectTransform _panel;
    [field: SerializeField] private Image _itemSprite;
    [field: SerializeField] private TextMeshProUGUI _itemName;
    [field: SerializeField] private TextMeshProUGUI _itemDescription;
    [field: SerializeField] private TextMeshProUGUI _itemQuantity;

    public void ShowItem(ItemData data, int quantity)
    {
        _itemSprite.sprite = data.Sprite;
        _itemName.text = data.Name;
        _itemDescription.text = data.Description;
        _itemQuantity.text = $"{GameConstants.KeyWords.OWNED_TEXT}: {quantity}";
    }

    public void ShowPanel()
    {
        _panel.gameObject.SetActive(true);
    }

    public void HidePanel()
    {
        _panel.gameObject.SetActive(false);
    }
}
