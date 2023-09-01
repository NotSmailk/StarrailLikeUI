using DG.Tweening;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreMenuPanel : MonoBehaviour
{
    [field: SerializeField] private RectTransform _rect;
    [field: SerializeField] private RectTransform _gridRect;
    [field: SerializeField] private TextMeshProUGUI _titleText;
    [field: SerializeField] private StoreSlotButton _slotPrefab;
    [field: SerializeField] private float _yValueUp;
    [field: SerializeField] private float _yValueShowed;
    [field: SerializeField] private float _yValueDown;
    [field: SerializeField] private float _animationDuration;

    public void Init(StoreData storeData)
    {
        _titleText.text = storeData.name;
        foreach (var slot in storeData.Items)
        {
            var item = Instantiate(_slotPrefab, _gridRect);
            item.Init(slot.slot, slot.quantity);
        }
    }

    public async Task ShowPanel(bool show, PanelAnimationType type)
    {
        if (show)
            await Show(type);
        else
            await Hide(type);
    }

    public void ShowPanel(bool show)
    {

        _rect.gameObject.SetActive(show);
    }

    private async Task Show(PanelAnimationType type)
    {
        _rect.gameObject.SetActive(true);
        var yValue = _yValueShowed;
        var pos = new Vector2(_rect.anchoredPosition.x, yValue);
        _rect.DOAnchorPos(pos, _animationDuration);
        await Task.Delay((int)(_animationDuration * 1000));
    }

    private async Task Hide(PanelAnimationType type)
    {
        var yValue = type.Equals(PanelAnimationType.Up) ? _yValueUp : _yValueDown;
        var pos = new Vector2(_rect.anchoredPosition.x, yValue);
        _rect.DOAnchorPos(pos, _animationDuration);
        await Task.Delay((int)(_animationDuration * 1000));
        _rect.gameObject.SetActive(false);
    }
}
