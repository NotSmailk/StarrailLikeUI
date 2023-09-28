using UnityEngine;
using Zenject;

public class SpinInfoPanelList : VerticalScrollablePanelList
{
    [field: SerializeField] private SpinInfoPanel _panelPrefab;
    [field: SerializeField] private RectTransform _rect;

    [Inject] protected DiContainer _container;

    public void CreatePanels(VersionSpinsData datas)
    {
        foreach (var data in datas.Datas)
        {
            var panel = _container.InstantiatePrefab(_panelPrefab, _rect).GetComponent<SpinInfoPanel>();
            panel.Init(data);
            _panels.Add(panel);
            panel.ShowPanel(false);
        }

        _curPanel = _panels[0];
        _curPanel.ShowPanel(true);
    }
}
