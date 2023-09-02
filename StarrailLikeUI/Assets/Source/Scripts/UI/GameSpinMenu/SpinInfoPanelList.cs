using UnityEngine;

public class SpinInfoPanelList : VerticalScrollablePanelList
{
    [field: SerializeField] private SpinInfoPanel _panelPrefab;
    [field: SerializeField] private RectTransform _rect;

    public void CreatePanels(VersionSpinsData datas)
    {
        foreach (var data in datas.Datas)
        {
            var panel = Instantiate(_panelPrefab, _rect);
            panel.Init(data);
            _panels.Add(panel);
            panel.ShowPanel(false);
        }

        _curPanel = _panels[0];
        _curPanel.ShowPanel(true);
    }
    public void Clear()
    {
        foreach (var pnl in _panels)
        {
            pnl.DestroyPanel();
        }

        _panels.Clear();
    }
}
