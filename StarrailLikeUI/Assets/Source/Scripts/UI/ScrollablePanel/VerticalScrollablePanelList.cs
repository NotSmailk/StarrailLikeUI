using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class VerticalScrollablePanelList : MonoBehaviour
{
    protected List<IScrollablePanel> _panels = new List<IScrollablePanel>();
    protected IScrollablePanel _curPanel;

    public async virtual Task ShowPanel(int id)
    {
        if (id < 0 || id >= _panels.Count)
            return;

        if (_panels.IndexOf(_curPanel).Equals(id))
            return;

        var showType = _panels.IndexOf(_curPanel) > id ? PanelAnimationType.Down : PanelAnimationType.Up;
        var hideType = _panels.IndexOf(_curPanel) < id ? PanelAnimationType.Down : PanelAnimationType.Up;
        var temp = _panels[id];
        await _curPanel?.ShowPanel(false, showType);
        _curPanel = temp;
        await _curPanel?.ShowPanel(true, hideType);
    }

    public virtual void Clear()
    {
        foreach (var panel in _panels)
            panel.DestroyPanel();

        _panels.Clear();
    }
}
