using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class StoreChooseTypePanel : ChooseTypeListPanel
{
    [field: SerializeField] private RectTransform _chooseRect;
    [field: SerializeField] private ChooseTypeButton _storeChoosePrefab;

    [Inject] private DiContainer _container;

    public void CreateButton(StoreData store, UnityAction action)
    {
        var btn = _container.InstantiatePrefab(_storeChoosePrefab, _chooseRect).GetComponent<ChooseTypeButton>();
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
}
