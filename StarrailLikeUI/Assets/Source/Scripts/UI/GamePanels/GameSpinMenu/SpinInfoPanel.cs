using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpinInfoPanel : VerticalScrollablePanel
{
    [field: Header("Panel Parametres")]
    [field: SerializeField] private Image _spinPreview;
    [field: SerializeField] private TextMeshProUGUI _spinName;
    [field: SerializeField] private TextMeshProUGUI _spinDescription;
    [field: SerializeField] private Button _spinOneTimeBtn;
    [field: SerializeField] private Button _spinTenTimeBtn;

    public void Init(SpinData data)
    {
        _spinPreview.sprite = data.Sprite;
        _spinName.text = data.Name;
        _spinDescription.text = data.Description;
    }

    public void Add(UnityAction<int> action)
    {
        _spinOneTimeBtn.onClick.AddListener(() => { action.Invoke(1); });
        _spinTenTimeBtn.onClick.AddListener(() => { action.Invoke(10); });
    }
}
