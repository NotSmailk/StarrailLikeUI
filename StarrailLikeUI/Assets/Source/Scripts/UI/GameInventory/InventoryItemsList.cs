using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class InventoryItemsList : ChooseTypeListPanel
{
    [field: SerializeField] private InventoryItemSlot _slotPrefab;
    [field: SerializeField] private RectTransform _contentTransform;

    [Inject] private ItemCollectionProvider _provider;

    private UnityEvent<ItemData, int> _showData = new UnityEvent<ItemData, int>();

    public void ShowPanel(List<InventoryInfo> inventory)
    {
        foreach (var item in inventory)
        {
            var itemSlot = Instantiate(_slotPrefab, _contentTransform);
            itemSlot.Init(_provider.GetItem(item.ItemId), item.Quantity);
            itemSlot.Add(() => { ChooseButton(itemSlot); });
            itemSlot.Add(() => { _showData.Invoke(_provider.GetItem(item.ItemId), item.Quantity); });
            _buttons.Add(itemSlot);
        }

        ChooseButton(_buttons[0]);
        _showData.Invoke(_provider.GetItem(inventory[0].ItemId), inventory[0].Quantity);
    }

    public void Add(UnityAction<ItemData, int> action)
    {
        _showData.AddListener(action);
    }

    public void HidePanel()
    {
        foreach (var item in _buttons)
            Object.Destroy(item.gameObject);

        _buttons.Clear();
    }
}
