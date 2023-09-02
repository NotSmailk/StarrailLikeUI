using TMPro;
using UnityEngine;

public class StoreMenuPanel : VerticalScrollablePanel
{
    [field: SerializeField] private RectTransform _gridRect;
    [field: SerializeField] private TextMeshProUGUI _titleText;
    [field: SerializeField] private StoreSlotButton _slotPrefab;

    public void Init(StoreData storeData)
    {
        _titleText.text = storeData.name;
        foreach (var slot in storeData.Items)
        {
            var item = Instantiate(_slotPrefab, _gridRect);
            item.Init(slot.slot, slot.quantity);
        }
    }
}
