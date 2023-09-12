using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SpinChooseTypeList : ChooseTypeListPanel
{
    [field: SerializeField] private ChooseTypeButton _buttonPrefab;
    [field: SerializeField] private RectTransform _rect;

    public void CreateButtons(VersionSpinsData spinData, UnityAction<int> action)
    {
        foreach (var data in spinData.Datas)
        {
            var btn = Instantiate(_buttonPrefab, _rect);
            btn.Init();
            btn.Add(() => { action.Invoke(spinData.Datas.IndexOf(data)); });
            btn.Add(() => { ChooseButton(btn); });
            _buttons.Add(btn);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = data.ShortName;
        }

        _selected = _buttons[0];
        _selected.Select();
    }

    public void Clear()
    {
        foreach (var btn in _buttons)
        {
            btn.DestroyButton();
        }

        _buttons.Clear();
    }
}
