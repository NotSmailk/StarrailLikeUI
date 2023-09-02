using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class StoreChooseTypePanel : ChooseTypeListPanel
{
    [field: SerializeField] private RectTransform _chooseRect;
    [field: SerializeField] private ChooseTypeButton _storeChoosePrefab;

    public void CreateButton(StoreData store, UnityAction action)
    {
        var btn = Instantiate(_storeChoosePrefab, _chooseRect);
        btn.Init();
        btn.Add(() => { ChooseButton(btn); });
        btn.Add(action);
        _buttons.Add(btn);
        btn.GetComponentInChildren<TextMeshProUGUI>().text = store.name; // TEMP
    }

    public void ChooseButton(int id)
    {
        ChooseButton(_buttons[id]);
    }

    public void Clear()
    {
        foreach (var btn in _buttons)
            Destroy(btn.gameObject);

        _buttons.Clear();
    }
}
