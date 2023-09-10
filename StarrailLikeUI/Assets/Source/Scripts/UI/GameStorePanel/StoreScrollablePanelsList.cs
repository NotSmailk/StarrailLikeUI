using UnityEngine;
using Zenject;

public class StoreScrollablePanelsList : VerticalScrollablePanelList
{
    [field: SerializeField] private RectTransform _storeRect;
    [field: SerializeField] private StoreMenuPanel _menuPanelPrefab;

    [Inject] private DiContainer _container;

    public void CreatePanel(StoreData store)
    {
        var storeData = _container.InstantiatePrefab(_menuPanelPrefab, _storeRect).GetComponent<StoreMenuPanel>();
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
