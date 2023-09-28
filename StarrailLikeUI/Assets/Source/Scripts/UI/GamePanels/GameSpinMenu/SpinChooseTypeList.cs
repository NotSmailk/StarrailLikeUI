using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class SpinChooseTypeList : ChooseTypeListPanel
{
    [field: SerializeField] private ChooseTypeButton _buttonPrefab;
    [field: SerializeField] private RectTransform _rect;

    [Inject] private DiContainer _container;

    public void CreateButtons(VersionSpinsData spinData, UnityAction<int> action)
    {
        foreach (var data in spinData.Datas)
        {
            var btn = _container.InstantiatePrefab(_buttonPrefab, _rect).GetComponent<ChooseTypeButton>();
            btn.Init();
            btn.Add(() => { action.Invoke(spinData.Datas.IndexOf(data)); });
            btn.Add(() => { ChooseButton(btn); });
            _buttons.Add(btn);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = data.ShortName;
        }

        _selected = _buttons[0];
        _selected.Select();
    }
}
