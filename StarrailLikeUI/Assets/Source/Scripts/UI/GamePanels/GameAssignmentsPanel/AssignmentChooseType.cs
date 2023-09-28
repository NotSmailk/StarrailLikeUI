using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class AssignmentChooseType : ChooseTypeListPanel
{
    [field: SerializeField] private RectTransform _chooseRect;
    [field: SerializeField] private ChooseTypeButton _assignmentChooseButton;

    [Inject] private DiContainer _container;

    public void CreateButton(AssignmentsData data, UnityAction<int> action)
    {
        foreach (var assignment in data.Assignments)
        {
            var btn = _container.InstantiatePrefab(_assignmentChooseButton, _chooseRect).GetComponent<ChooseTypeButton>();
            btn.Init();
            btn.Add(() => { action.Invoke(data.Assignments.IndexOf(assignment)); });
            btn.Add(() => { ChooseButton(btn); });
            _buttons.Add(btn);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = assignment.Name; // TEMP
        }

        _selected = _buttons[0];
        _selected.Select();
    }

    public void ChooseButton(int id)
    {
        ChooseButton(_buttons[id]);
    }
}
