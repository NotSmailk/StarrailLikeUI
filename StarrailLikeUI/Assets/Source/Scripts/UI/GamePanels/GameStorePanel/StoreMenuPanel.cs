using TMPro;
using UnityEngine;
using Zenject;

public class StoreMenuPanel : VerticalScrollablePanel
{
    [field: SerializeField] private RectTransform _gridRect;
    [field: SerializeField] private TextMeshProUGUI _titleText;
    [field: SerializeField] private StoreSlotButton _slotPrefab;

    [Inject] private ItemCollectionProvider _collection;
    [Inject] private GameStateMachine _gameStateMachine;

    public void Init(StoreData storeData)
    {
        _titleText.text = storeData.name;
        foreach (var slot in storeData.Items)
        {
            var item = Instantiate(_slotPrefab, _gridRect);
            item.Init(_collection.GetItem(slot.slot.ItemId), slot.slot.Price, slot.quantity);
            item.Add(() =>
            {
                _collection.ItemToBuyId = slot.slot.ItemId;
                _collection.ItemToBuyPrice = slot.slot.Price;
                _gameStateMachine.SwitchStateWithoutExit<GameStoreBuyItemState>();
            });
        }
    }
}
