using UnityEngine;

public class StoreScrollablePanelsList : VerticalScrollablePanelList
{
    [field: SerializeField] private RectTransform _storeRect;
    [field: SerializeField] private StoreMenuPanel _menuPanelPrefab;

    public void CreatePanel(StoreData store)
    {
        var storeData = Instantiate(_menuPanelPrefab, _storeRect);
        storeData.Init(store);
        _panels.Add(storeData);
        storeData.ShowPanel(false);
    }

    public void ChoosePanel(int id)
    {
        _curPanel = _panels[id];
        _curPanel.ShowPanel(true);
    }
}
