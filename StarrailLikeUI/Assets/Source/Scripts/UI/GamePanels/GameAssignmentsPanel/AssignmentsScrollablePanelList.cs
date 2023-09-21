using System.ComponentModel;
using UnityEngine;
using Zenject;

public class AssignmentsScrollablePanelList : VerticalScrollablePanelList
{
    [field: SerializeField] private RectTransform _contentRect;
    [field: SerializeField] private AssignmentPanel _panelPrefab;

    [Inject] private DiContainer _container;

    public void CreatePanels(AssignmentsData data)
    {
        foreach (var assignment in data.Assignments)
        {
            var panel = _container.InstantiatePrefab(_panelPrefab, _contentRect).GetComponent<AssignmentPanel>();
            panel.Init(assignment);
            _panels.Add(panel);
            panel.ShowPanel(false);
        }

        _curPanel = _panels[0];
        _curPanel.ShowPanel(true);
    }

    public void ChoosePanel(int id)
    {
        _curPanel = _panels[id];
        _curPanel.ShowPanel(true);
    }
}
